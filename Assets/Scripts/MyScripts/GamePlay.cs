using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using Cysharp.Text;
using PrimeTween;
using UnityEditor.Experimental.GraphView;

public enum MovingRule
{
    Normal = 0, CantStop = 1, CantGoStraight = 2,
}

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    [SerializeField] private bool isRunning;
    public bool IsRunning { get => isRunning; set => isRunning = value; }
    public bool isCleared;
    public bool isOver;
    public bool isYes, isNo;
    public bool isChecking;
    public MovingRule movingRule;
    public Vector3Int posOnMap;
    public Vector3Int prevDirection;
    public Vector3Int prevBlockedPos;
    public GameObject player;
    
    [SerializeField] QuestionBoxData questionBoxData;

    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite angelSprite;
    [SerializeField] Sprite devilSprite;
    [SerializeField] GameObject answerBox;
    [SerializeField] Image eyeBoxImage;
    [SerializeField] TextMeshProUGUI eyeIndexText;
    [SerializeField] TextMeshProUGUI answerBoxText;

    [SerializeField] TextMeshProUGUI stageNumberText;
    [SerializeField] TextMeshProUGUI enteringCheckTMP;
    [SerializeField] GameObject enteringCheckWindow;
    [SerializeField] GameObject stageClearWindow;
    [SerializeField] GameObject gameOverWindow;
    public GameObject nextButton;

    [SerializeField] MyCamera myCamera;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        Init();
        
        MapManager.instance.InitMap();
        prevBlockedPos = posOnMap; //임시

        LogManager.instance.InitEmptyCategoryLogs();
        
        ScenarioManager.instance.ActivateScenarios(true);
        ScenarioManager.instance.InitBaseScenario();

        myCamera.SetOSizeByMap(MapManager.instance.tileList);

        SoundManager.Instance.StopBgm();
        SoundManager.Instance.PlayBGM("gameplay");
        
        TDDialog dialog = DialogData.DialogList.Find(dialog => dialog.stage == GameManager.Instance.CurrentStage && dialog.isProlog == true);
        DialogSystem.instance.StartDialog(dialog);

        Tutorial.instance.RevisedInit();
    }

    void Init()
    {

        if (GameManager.Instance.CurrentStage <= StageData.Ch1StageCount) 
        {
            stageNumberText.SetText(ZString.Concat("1 - ", GameManager.Instance.CurrentStage));
        }
        else if (GameManager.Instance.CurrentStage <= StageData.Ch1StageCount + StageData.Ch2StageCount) 
        {
            stageNumberText.SetText(ZString.Concat("2 - ", GameManager.Instance.CurrentStage - StageData.Ch1StageCount));
        }

        if (14 <= GameManager.Instance.CurrentStage && GameManager.Instance.CurrentStage <= 17) 
        {
            movingRule = MovingRule.CantStop;
        }
        if (18 <= GameManager.Instance.CurrentStage && GameManager.Instance.CurrentStage <= 20)
        {
            movingRule = MovingRule.CantGoStraight; 
        }

        isRunning = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !OptionManager.instance.IsOptionOpened)
        {
            if (isChecking) OnNoClicked();
            else if (Guidebook.instance.IsGuidebookOpened) Guidebook.instance.OnGuidebookClicked(false);
            else if (DialogSystem.instance.IsPastDialogOpened) DialogSystem.instance.OnReviewClicked(false);
            else OnExitClicked();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isChecking) OnYesClicked();
        }

        if (!isRunning) return;
        
        Vector3Int dir = GetDirectionFromKey();
        if (CanMove(dir, true))
        {
            if (Tutorial.instance.BreakEnteringPos(posOnMap + dir)) return;

            TDTileData nextTile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap + dir);
            if (nextTile.color == TileColor.White && nextTile.data[0] == (int)WhiteData.Gate)
            {
                StartCoroutine(CheckEnteringGate(dir));
            }
            else Move(dir);
        }

        CheckGameOver();
        CheckStageClear();
    }

    Vector3Int GetDirectionFromKey()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) return Vector3Int.up;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) return Vector3Int.left;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) return Vector3Int.down;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) return Vector3Int.right;
        else return Vector3Int.zero;
    }

    bool CanMove(Vector3Int dir, bool isByInput = false)
    {
        if (dir == Vector3Int.zero) return false;

        int idx = MapManager.instance.tileList.FindIndex(tile => tile.pos == posOnMap + dir);
        if (idx == -1) return false;

        TDTileData nextTile = MapManager.instance.tileList[idx];
        if (nextTile.color != TileColor.White || nextTile.data[0] != (int)WhiteData.Gate) return CheckGoingstraight(dir);

        TDGate gate = MapManager.instance.gateList.Find(gate => gate.pos == posOnMap + dir);
        if (gate.isMarked) return false;

        bool isNotAllMarked = false;
        foreach (TDEye eye in MapManager.instance.eyeList)
        {
            if (!eye.isMarked)
            {
                isNotAllMarked = true;
                if (isByInput) eye.Shake(Vector3.left * 0.1f, 0.05f);
                if (!isByInput && isNotAllMarked) break; 
            }
        }
        if (isNotAllMarked)
        {
            if (isByInput) gate.Shake(Vector3.left * 0.1f, 0.05f);
            return false;
        }

        return CheckGoingstraight(dir);
    }

    bool CheckGoingstraight(Vector3Int dir)
    {
        if (movingRule != MovingRule.CantGoStraight) return true;
        
        if (dir == prevDirection) return false;
        else 
        {
            prevDirection = dir;
            return true;
        }
    }

    bool CheckFrontTileIsGate(Vector3Int dir)
    {
        return MapManager.instance.gateList.Any(tile => tile.pos == posOnMap + dir);
    }

    void Move(Vector3Int dir, bool isEnteringGate = false)
    {
        posOnMap += dir;
        Tween.Position(player.transform, posOnMap + MyUtils.Offset, 0.1f, Ease.InOutSine);

        DataBoxUpdate(dir);

        HandleMovingRule(dir, isEnteringGate);
    }

    void HandleMovingRule(Vector3Int dir, bool isEnteringGate)
    {
        if (movingRule == MovingRule.CantStop)
        {
            if (CanMove(dir) && !CheckFrontTileIsGate(dir) && !isEnteringGate) Move(dir);
        }

        else if (movingRule == MovingRule.CantGoStraight)
        {
            //임시 음영 처리
            TDObject prevObj = MapManager.instance.objectList.Find(obj => obj.pos == prevBlockedPos);
            if (prevObj != null) prevObj.BlockTile(false); 

            TDObject frontObj = MapManager.instance.objectList.Find(obj => obj.pos == posOnMap + dir);
            if (frontObj != null)
            {
                frontObj.BlockTile(true);
                prevBlockedPos = frontObj.pos;
            }
        }
    }

    IEnumerator CheckEnteringGate(Vector3Int dir)
    {
        if (Tutorial.instance.BreakEnteringGate(dir)) yield break;

        if (GameManager.Instance.doCheckBeforeEnteringGate)
        {
            EventSystem.current.SetSelectedGameObject(null);
            
            isRunning = false;
            isChecking = true;
            enteringCheckWindow.SetActive(true);
            
            TDTileData gate = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap + dir);
            enteringCheckTMP.SetText(ZString.Format("정말 문 {0}(으)로\n진입하시겠습니까?", (char)('A' + gate.data[2])));

            yield return new WaitUntil(() => isYes || isNo);

            if (isYes) Move(dir, true);

            isRunning = true;
            isChecking = false;
            isYes = isNo = false;
            enteringCheckWindow.SetActive(false);
        }
        else Move(dir);
    }

    void DataBoxUpdate(Vector3Int dir)
    {
        TDTileData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);

        switch (tile.color)
        {
            case TileColor.Red: questionBoxData.redBoxData = tile.count != 0 ? tile.data : MyUtils.RedDataNull; break;
            case TileColor.Blue: questionBoxData.blueBoxData = tile.count != 0 ? tile.data : MyUtils.BlueDataNull; break;
            case TileColor.Green: questionBoxData.greenBoxData = tile.count != 0 ? tile.data : MyUtils.GreenDataNull; break;
            case TileColor.White:
                if (tile.count == 0) questionBoxData.ResetData();
                else if (tile.data[0] == (int)WhiteData.Eye)
                {
                    if (movingRule != MovingRule.CantStop || !CanMove(dir) || CheckFrontTileIsGate(dir)) 
                    {
                        Answer(MapManager.instance.eyeList.Find(eye => eye.pos == posOnMap));
                    }
                }
                break;
        }

        // 튜토리얼 연출 - 질문 상자 강조
        if (GameManager.Instance.CurrentStage == 1)
        {
            questionBoxData.Highlight(tile.color);
        }

        questionBoxData.ChangeBrightness();
        questionBoxData.SetAllText();
        
        Tutorial.instance.HighlightTiles(questionBoxData.redBoxData, questionBoxData.blueBoxData);

        if (tile.color != TileColor.White || tile.data[0] != (int) WhiteData.Eye) answerBox.SetActive(false);
    }

    void Answer(TDEye eye)
    {
        if (!questionBoxData.isfull) return;

        char answer = questionBoxData.GetAnswer();
        if (answer == '?') return;

        if (eye.trueID == ToD.Devil) answer = answer == 'O' ? 'X' : 'O'; 
        
        answerBox.SetActive(true);
        eyeBoxImage.sprite = eye.guessedID == ToD.Null ? defaultSprite : eye.guessedID == ToD.Truth ? angelSprite : devilSprite;
        eyeIndexText.SetText(MyUtils.ConvertToRoman(eye.code + 1));
        answerBoxText.SetText(answer);

        LogManager.instance.AddLog(questionBoxData, eye, answer);

        questionBoxData.ResetData();
    }

    void CheckStageClear()
    {
        TDTileData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)ToD.Truth) {
            foreach(TDEye eye in MapManager.instance.eyeList)
            {
                if (eye.trueID != eye.guessedID) return;
            }
            
            isCleared = true;
            DialogSystem.instance.StartDialog(DialogData.StageClear);
        }
    }
    
    public void StageClear()
    {
        EventSystem.current.SetSelectedGameObject(null);

        isRunning = false;
        stageClearWindow.SetActive(true);
        
        if (GameManager.Instance.CurrentStage == GameManager.Instance.maxStage) GameManager.Instance.maxStage++;
    }

    void CheckGameOver()
    {
        TDTileData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color != TileColor.White || tile.data[0] != (int)WhiteData.Gate) return;

        if(tile.data[1] == (int)ToD.Devil)
        {
            isOver = true;
            DialogSystem.instance.StartDialog(DialogData.GameOver);
            return;
        }
        
        foreach(TDEye eye in MapManager.instance.eyeList)
        {
            if (eye.trueID != eye.guessedID) 
            {
                isOver = true;
                DialogSystem.instance.StartDialog(DialogData.GameOver);
                return;
            }
        }
    }

    public void GameOver()
    {
        EventSystem.current.SetSelectedGameObject(null);

        isRunning = false;
        gameOverWindow.SetActive(true);
    }

    IEnumerator WaitForSeconds(float dur)
    {
        isRunning = false;
        yield return new WaitForSeconds(dur);
        isRunning = true;
    }

    public void OnExitClicked() => SceneManager.LoadScene("Main Menu");
    public void OnYesClicked() => isYes = true;
    public void OnNoClicked() => isNo = true;
    public void OnDontCheckEnteringChanged(bool isOn) => GameManager.Instance.doCheckBeforeEnteringGate = !isOn;
    public void OnRetryClicked() => SceneManager.LoadScene("GamePlay");
    public void OnNextClicked()
    {
        GameManager.Instance.CurrentStage++;
        SceneManager.LoadScene("GamePlay");
    }
}
