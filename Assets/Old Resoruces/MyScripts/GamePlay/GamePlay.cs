using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
using Cysharp.Text;
using PrimeTween;

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

        myCamera.InitOSize();

        SoundManager.Instance.StopBgm();
        SoundManager.Instance.PlayBGM("gameplay");
        
        TDDialog dialog = DialogData.DialogList.Find(dialog => dialog.stage == GameManager.Instance.currentStage && dialog.isProlog == true);
        DialogSystem.instance.StartDialog(dialog);

        Tutorial.instance.RevisedInit();
    }

    void Init()
    {
        StageData currentStage = StageDataList.stages[GameManager.Instance.currentStage - 1];
        stageNumberText.SetText(ZString.Concat(currentStage.chapter, " - ", currentStage.stage));

        // if (14 <= GameManager.Instance.CurrentStage && GameManager.Instance.CurrentStage <= 17) 
        // {
        //     movingRule = MovingRule.CantStop;
        // }
        // if (18 <= GameManager.Instance.CurrentStage && GameManager.Instance.CurrentStage <= 20)
        // {
        //     movingRule = MovingRule.CantGoStraight; 
        // }

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

            TDTileData nextTile = MapManager.instance.map.Find(obj => obj.pos == posOnMap + dir).tileData;
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

        int idx = MapManager.instance.map.FindIndex(obj => obj.pos == posOnMap + dir);
        if (idx == -1) return false;

        if (MapManager.instance.map[idx] is TDPlaceableObject pobj && pobj.IsDragging)
        {
            return false;
        }

        TDTileData nextTile = MapManager.instance.map[idx].tileData;
        if (nextTile.color != TileColor.White || nextTile.data[0] != (int)WhiteData.Gate) 
        {
            return CheckGoingstraight(dir);
        }

        TDGate gate = MapManager.instance.gates.Find(gate => gate.pos == posOnMap + dir);
        if (gate.isMarked) return false;

        bool isNotAllMarked = false;
        foreach (TDEye eye in MapManager.instance.eyes)
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
        return MapManager.instance.gates.Any(tile => tile.pos == posOnMap + dir);
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
            TDObject prevObj = MapManager.instance.map.Find(obj => obj.pos == prevBlockedPos);
            if (prevObj != null) prevObj.BlockTile(false); 

            TDObject frontObj = MapManager.instance.map.Find(obj => obj.pos == posOnMap + dir);
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
            
            TDTileData gate = MapManager.instance.map.Find(obj => obj.pos == posOnMap + dir).tileData;
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
        TDObject obj = MapManager.instance.map.Find(obj => obj.pos == posOnMap);

        switch (obj.tileData.color)
        {
            case TileColor.Red: questionBoxData.lastRedTile = obj.stack != 0 ? obj : null; break;
            case TileColor.Blue: questionBoxData.lastBlueTile = obj.stack != 0 ? obj : null; break;
            case TileColor.Green: questionBoxData.lastGreenTile = obj.stack != 0 ? obj : null; break;
            case TileColor.White:
                if (obj.stack == 0) questionBoxData.ResetData();
                else if (obj.tileData.data[0] == (int)WhiteData.Eye)
                {
                    if (movingRule != MovingRule.CantStop || !CanMove(dir) || CheckFrontTileIsGate(dir)) 
                    {
                        Answer(MapManager.instance.eyes.Find(eye => eye.pos == posOnMap));
                    }
                }
                break;
        }

        // // 튜토리얼 연출 - 질문 상자 강조
        // if (GameManager.Instance.CurrentStage == 1)
        // {
        //     questionBoxData.Highlight(tile.color);
        // }

        questionBoxData.ChangeBrightness();
        questionBoxData.SetAllText();
        
        // Tutorial.instance.HighlightTiles(questionBoxData.redBoxData, questionBoxData.blueBoxData);

        if (obj.tileData.color != TileColor.White || obj.tileData.data[0] != (int) WhiteData.Eye) answerBox.SetActive(false);
    }

    void Answer(TDEye eye)
    {
        if (!questionBoxData.isfull) return;

        char answer = questionBoxData.GetAnswer();
        if (answer == '?') return;

        if (eye.trueID == Species.Devil) answer = answer == 'O' ? 'X' : 'O'; 
        
        answerBox.SetActive(true);
        eyeBoxImage.sprite = eye.guessedID == Species.Null ? defaultSprite : eye.guessedID == Species.Angel ? angelSprite : devilSprite;
        eyeIndexText.SetText(MyUtils.ConvertToRoman(eye.code + 1));
        answerBoxText.SetText(answer);

        LogManager.instance.AddLog(questionBoxData, eye, answer);

        questionBoxData.DecreaseCount(eye);
        questionBoxData.ResetData();
    }

    void CheckStageClear()
    {
        TDTileData tile = MapManager.instance.map.Find(obj => obj.pos == posOnMap).tileData;
        if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)Species.Angel) {
            foreach(TDEye eye in MapManager.instance.eyes)
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
        
        if (GameManager.Instance.currentStage == GameManager.Instance.maxStage) GameManager.Instance.maxStage++;
    }

    void CheckGameOver()
    {
        TDTileData tile = MapManager.instance.map.Find(obj => obj.pos == posOnMap).tileData;
        if (tile.color != TileColor.White || tile.data[0] != (int)WhiteData.Gate) return;

        if(tile.data[1] == (int)Species.Devil)
        {
            isOver = true;
            DialogSystem.instance.StartDialog(DialogData.GameOver);
            return;
        }
        
        foreach(TDEye eye in MapManager.instance.eyes)
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
        GameManager.Instance.currentStage++;
        SceneManager.LoadScene("GamePlay");
    }
}
