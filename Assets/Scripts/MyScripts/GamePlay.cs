using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    
    public List<int> redBoxData;
    public List<int> blueBoxData;
    public List<int> greenBoxData;
    public TextMeshProUGUI redBoxText;
    public TextMeshProUGUI blueBoxText;
    public TextMeshProUGUI greenBoxText;

    public Sprite defaultSprite;
    public Sprite angelSprite;
    public Sprite devilSprite;
    public GameObject answerBox;
    public Image eyeBoxImage;
    public TextMeshProUGUI eyeIndexText;
    public TextMeshProUGUI answerBoxText;

    public TextMeshProUGUI stageNumberText;
    public TextMeshProUGUI enteringCheckTMP;
    public GameObject enteringCheckWindow;
    public GameObject stageClearWindow;
    public GameObject gameOverWindow;
    public GameObject nextButton;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        Init();
        MapManager.instance.InitMap();
        LogManager.instance.InitEmptyCategoryLogs();
        prevBlockedPos = posOnMap; //임시
        ScenarioManager.instance.ActivateScenarios(true);
        ScenarioManager.instance.InitBaseScenario();
        MyCamera.instance.SetOSizeByMap();
        
        Tutorial.instance.RevisedInit();

        isRunning = true;
        
        TDDialog dialog = TDStory.dialogList.Find(dialog => dialog.stage == GameManager.instance.CurrentStage && dialog.isProlog == true);
        DialogManager.instance.StartDialog(dialog);
    }

    void Init()
    {
        redBoxData = MyUtils.RedDataNull;
        blueBoxData =  MyUtils.BlueDataNull;
        greenBoxData = MyUtils.GreenDataNull;

        if (GameManager.instance.CurrentStage <= TDStage.Ch1StageCount) 
        {
            stageNumberText.SetText(ZString.Concat("1 - ", GameManager.instance.CurrentStage));
        }
        else if (GameManager.instance.CurrentStage <= TDStage.Ch1StageCount + TDStage.Ch2StageCount) 
        {
            stageNumberText.SetText(ZString.Concat("2 - ", GameManager.instance.CurrentStage - TDStage.Ch1StageCount));
        }

        if (14 <= GameManager.instance.CurrentStage && GameManager.instance.CurrentStage <= 17) 
        {
            movingRule = MovingRule.CantStop;
        }
        if (18 <= GameManager.instance.CurrentStage && GameManager.instance.CurrentStage <= 20)
        {
            movingRule = MovingRule.CantGoStraight; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (OptionManager.instance.IsOptionOpened) OptionManager.instance.OnOptionClicked(false);
            else if (isChecking) OnNoClicked();
            else OnExitClicked();
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isChecking) OnYesClicked();
        }

        if (!isRunning) return;
        
        Vector3Int dir = GetDirectionFromKey();
        if (CanMove(dir))
        {
            if (Tutorial.instance.BreakEnteringPos(posOnMap + dir)) return;

            TDData nextTile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap + dir);
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

    bool CanMove(Vector3Int dir)
    {
        if (dir == Vector3Int.zero) return false;

        int idx = MapManager.instance.tileList.FindIndex(tile => tile.pos == posOnMap + dir);
        if (idx == -1) return false;

        TDData nextTile = MapManager.instance.tileList[idx];
        if (nextTile.color != TileColor.White || nextTile.data[0] != (int)WhiteData.Gate) return CheckGoingstraight(dir);

        if (MapManager.instance.gateList.Find(gate => gate.pos == posOnMap + dir).guessedID == ToD.Devil) return false;
        foreach (TDEye eye in MapManager.instance.eyeList)
        {
            if (!eye.isMarked) return false;
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
        Tween.Position(player.transform, posOnMap + MyUtils.offset, 0.1f, Ease.InOutSine);

        DataBoxUpdate(dir);

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

        if (GameManager.instance.doCheckBeforeEnteringGate)
        {
            isRunning = false;
            isChecking = true;
            enteringCheckWindow.SetActive(true);
            
            TDData gate = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap + dir);
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

    public bool CheckQuestion(List<int> redData, List<int> blueData, List<int> greenData)
    {
        if (redData[0] == (int)RedData.Gate && blueData[0] == (int)BlueData.Color && greenData[0] != (int)GreenData.Null) return true;
        if (redData[0] == (int)RedData.Map && blueData[0] == (int)BlueData.Eye && greenData[0] != (int)GreenData.Null) return true;

        return false;
    }

    void DataBoxUpdate(Vector3Int dir)
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);

        switch (tile.color)
        {
            case TileColor.Red: redBoxData = tile.data; break;
            case TileColor.Blue: blueBoxData = tile.data; break;
            case TileColor.Green: greenBoxData = tile.data; break;
            case TileColor.White:
                if(tile.data[0] == (int)WhiteData.Eye && CheckQuestion(redBoxData, blueBoxData, greenBoxData))
                {
                    if (movingRule != MovingRule.CantStop || !CanMove(dir) || CheckFrontTileIsGate(dir)) 
                    {
                        Answer(MapManager.instance.eyeList.Find(eye => eye.pos == posOnMap));
                        redBoxData = MyUtils.RedDataNull;
                        blueBoxData = MyUtils.BlueDataNull;
                        greenBoxData = MyUtils.GreenDataNull;
                    }
                }
                break;
        }

        redBoxText.SetText(MyUtils.GetTextFromData(TileColor.Red, redBoxData));
        blueBoxText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueBoxData));
        greenBoxText.SetText(MyUtils.GetTextFromData(TileColor.Green, greenBoxData));

        if (tile.color != TileColor.White || tile.data[0] != (int) WhiteData.Eye) answerBox.SetActive(false);
    }

    void Answer(TDEye eye)
    {
        char answer = '?';
        if (redBoxData[0] == (int)RedData.Gate && blueBoxData[0] == (int)BlueData.Color)
        {
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: answer = MapManager.instance.gateColorCount[blueBoxData[1]] == greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.NotEqual: answer = MapManager.instance.gateColorCount[blueBoxData[1]] != greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.Greater: answer = MapManager.instance.gateColorCount[blueBoxData[1]] > greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.Less: answer = MapManager.instance.gateColorCount[blueBoxData[1]] < greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.GreaterOrEqual: answer = MapManager.instance.gateColorCount[blueBoxData[1]] >= greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.LessOrEqual: answer = MapManager.instance.gateColorCount[blueBoxData[1]] <= greenBoxData[1] ? 'O' : 'X'; break;
            }
        }
        else if (redBoxData[0] == (int)RedData.Map && blueBoxData[0] == (int)BlueData.Eye)
        {
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: answer = MapManager.instance.mapEyeCount[blueBoxData[1]] == greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.NotEqual: answer = MapManager.instance.mapEyeCount[blueBoxData[1]] != greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.Greater: answer = MapManager.instance.mapEyeCount[blueBoxData[1]] > greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.Less: answer = MapManager.instance.mapEyeCount[blueBoxData[1]] < greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.GreaterOrEqual: answer = MapManager.instance.mapEyeCount[blueBoxData[1]] >= greenBoxData[1] ? 'O' : 'X'; break;
                case GreenData.LessOrEqual: answer = MapManager.instance.mapEyeCount[blueBoxData[1]] <= greenBoxData[1] ? 'O' : 'X'; break;
            }
        }
        if (eye.trueID == ToD.Devil) answer = answer == 'O' ? 'X' : 'O'; 
        

        answerBox.SetActive(true);
        eyeBoxImage.sprite = eye.guessedID == ToD.Null ? defaultSprite : eye.guessedID == ToD.Truth ? angelSprite : devilSprite;
        eyeIndexText.SetText(MyUtils.ConvertToRoman(eye.index + 1));
        answerBoxText.SetText(answer);

        LogManager.instance.AddLog(redBoxData, blueBoxData, greenBoxData, eye, answer);
    }

    void CheckStageClear()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)ToD.Truth) {
            foreach(TDEye eye in MapManager.instance.eyeList)
            {
                if (eye.trueID != eye.guessedID) return;
            }
            
            isCleared = true;
            DialogManager.instance.StartDialog(TDStory.stageClearLineList);
        }
    }
    
    public void StageClear()
    {
        isRunning = false;
        stageClearWindow.SetActive(true);
        if (GameManager.instance.CurrentStage == GameManager.instance.maxStage) GameManager.instance.maxStage++;
    }

    void CheckGameOver()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color != TileColor.White || tile.data[0] != (int)WhiteData.Gate) return;

        if(tile.data[1] == (int)ToD.Devil)
        {
            isOver = true;
            DialogManager.instance.StartDialog(TDStory.gameOverLineList);
            return;
        }
        
        foreach(TDEye eye in MapManager.instance.eyeList)
        {
            if (eye.trueID != eye.guessedID) 
            {
                isOver = true;
                DialogManager.instance.StartDialog(TDStory.gameOverLineList);
                return;
            }
        }
    }

    public void GameOver()
    {
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
    public void OnDontCheckEnteringChanged(bool isOn) => GameManager.instance.doCheckBeforeEnteringGate = !isOn;
    public void OnRetryClicked() => SceneManager.LoadScene("GamePlay");
    public void OnNextClicked()
    {
        GameManager.instance.CurrentStage++;
        SceneManager.LoadScene("GamePlay");
    }
}
