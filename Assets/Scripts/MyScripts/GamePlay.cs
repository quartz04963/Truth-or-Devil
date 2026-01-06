using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Cysharp.Text;
using PrimeTween;

public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    public int stageNumber;
    public int questionCount;
    public bool isRunning;
    public GameObject player;
    public Vector3Int posOnMap;

    [Header("질문 상자 관련")]
    public List<int> redBoxData, blueBoxData, greenBoxData;
    public TextMeshProUGUI redBoxText, blueBoxText, greenBoxText;

    [Header("답변 관련")]
    public Image eyeBoxImage;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public TextMeshProUGUI eyeIndexText;
    public TextMeshProUGUI answerBoxText;

    [Header("임시 추가")]
    public TMP_InputField inputField;

    void Awake()
    {
        if (instance == null) instance = this;
        else DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Init();
        MapManager.instance.InitMap(stageNumber);
        LogManager.instance.InitEmptyCategoryLogs();
        ScenarioManager.instance.ActivateScenarios(true);
        ScenarioManager.instance.InitBaseScenario();
        MyCamera.instance.SetOSizeByMap();
    }

    void Init()
    {
        redBoxData = MyUtils.RedDataNull;
        blueBoxData =  MyUtils.BlueDataNull;
        greenBoxData = MyUtils.GreenDataNull;
        eyeBoxImage.enabled = false;
        player.gameObject.SetActive(true);

        // 아래 코드는 임시
        redBoxText.SetText("");
        blueBoxText.SetText("");
        greenBoxText.SetText("");
        eyeIndexText.SetText("");
        answerBoxText.SetText("");
        if (stageNumber == 0) Debug.Log("튜토리얼 - 눈알 A는 악마입니다.");
        else if (stageNumber == 1) Debug.Log("튜토리얼 - 눈알 A는 천사입니다.");
        else Debug.Log("");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (!isRunning) return;

        Vector3Int dir = Vector3Int.zero;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) dir = Vector3Int.up;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) dir = Vector3Int.left;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) dir = Vector3Int.down;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) dir = Vector3Int.right;

        if (CanMove(dir))
        {
            posOnMap += dir;
            Tween.Position(player.transform, posOnMap + MyUtils.offset, 0.1f, Ease.InOutSine);
            
            DataBoxUpdate();
        }

        if(CheckGameOver()) GameOver();
        if(CheckStageClear()) StageClear();
    }

    bool CanMove(Vector3Int dir)
    {
        if (dir == Vector3Int.zero) return false;

        int idx = MapManager.instance.tileList.FindIndex(tile => tile.pos == posOnMap + dir);
        if (idx == -1) return false;

        TDData nextTile = MapManager.instance.tileList[idx];
        if (nextTile.color != TileColor.White || nextTile.data[0] != (int)WhiteData.Gate) return true;

        if (MapManager.instance.gateList.Find(gate => gate.pos == posOnMap + dir).guessedID == ToD.Devil) return false;
        foreach (TDEye eye in MapManager.instance.eyeList)
        {
            if (!eye.isMarked) return false;
        }
        return true;
    }

    public bool CheckQuestion(List<int> redData, List<int> blueData, List<int> greenData)
    {
        if (redData[0] == (int)RedData.Gate && blueData[0] == (int)BlueData.Color && greenData[0] != (int)GreenData.Null) return true;
        if (redData[0] == (int)RedData.Map && blueData[0] == (int)BlueData.Eye && greenData[0] != (int)GreenData.Null) return true;

        return false;
    }

    void DataBoxUpdate()
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
                    Answer(MapManager.instance.eyeList.Find(eye => eye.pos == posOnMap));
                    redBoxData = MyUtils.RedDataNull;
                    blueBoxData = MyUtils.BlueDataNull;
                    greenBoxData = MyUtils.GreenDataNull;
                }
                break;
        }

        redBoxText.SetText(MyUtils.GetTextFromData(TileColor.Red, redBoxData));
        blueBoxText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueBoxData));
        greenBoxText.SetText(MyUtils.GetTextFromData(TileColor.Green, greenBoxData));

        if (tile.color != TileColor.White || tile.data[0] != (int) WhiteData.Eye) {
            eyeBoxImage.enabled = false;
            eyeIndexText.SetText("");
            answerBoxText.SetText("");
        }
    }

    void Answer(TDEye eye)
    {
        questionCount++;
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
        
        eyeBoxImage.enabled = true;
        eyeBoxImage.sprite = eye.guessedID == ToD.Null ? defaultSprite : eye.guessedID == ToD.Truth ? angelSprite : devilSprite;
        eyeIndexText.SetText((char)('A' + eye.index));
        answerBoxText.SetText(answer);

        LogManager.instance.AddLog(redBoxData, blueBoxData, greenBoxData, eye, answer);

        StartCoroutine(WaitForSeconds(1f));
    }

    bool CheckStageClear()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)ToD.Truth) {
            foreach(TDEye eye in MapManager.instance.eyeList)
            {
                if (eye.trueID != eye.guessedID) return false;
            }
            return true;
        }
        
        else return false;
    }

    void StageClear()
    {
        Debug.Log("Stage Clear.");
        isRunning = false;
    }

    bool CheckGameOver()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color != TileColor.White || tile.data[0] != (int)WhiteData.Gate) return false;

        if(tile.data[1] == (int)ToD.Devil) return true;
        
        foreach(TDEye eye in MapManager.instance.eyeList)
        {
            if (eye.trueID != eye.guessedID) return true;
        }

        return false;
    }

    void GameOver()
    {
        Debug.Log("Game Over.");
        isRunning = false;
    }

    IEnumerator WaitForSeconds(float dur)
    {
        isRunning = false;
        yield return new WaitForSeconds(dur);
        isRunning = true;
    }

    public void OnInputSubmit()
    {
        if (!Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyDown(KeyCode.KeypadEnter)) return;
        
        if (int.TryParse(inputField.text, out int num))
        {
            if (1 <= num && num <= 9) {
                stageNumber = num - 1;
                MapManager.instance.tileList.ForEach(tile => MapManager.instance.map.SetTile(tile.pos, null));
                MapManager.instance.objectList.ForEach(obj => Destroy(obj.gameObject));
                LogManager.instance.logList.ForEach(log => Destroy(log.gameObject));
                ScenarioManager.instance.scenarioList.ForEach(scenario => Destroy(scenario.gameObject));
                Start();
                isRunning = true;
            }
            else Debug.Log("스테이지는 1번부터 9번까지 있습니다.");
        }
        else Debug.Log("숫자를 올바르게 입력하세요.");
        inputField.SetTextWithoutNotify("");
    }
}
