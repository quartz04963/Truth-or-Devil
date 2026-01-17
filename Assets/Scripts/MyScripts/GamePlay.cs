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

    public bool isRunning;
    public GameObject player;
    public Vector3Int posOnMap;

    public List<int> redBoxData;
    public List<int> blueBoxData;
    public List<int> greenBoxData;
    public TextMeshProUGUI redBoxText;
    public TextMeshProUGUI blueBoxText;
    public TextMeshProUGUI greenBoxText;

    public Image eyeBoxImage;
    public Sprite defaultSprite;
    public Sprite angelSprite;
    public Sprite devilSprite;
    public TextMeshProUGUI eyeIndexText;
    public TextMeshProUGUI answerBoxText;

    public GameObject stageClearWindow;
    public GameObject gameOverWindow;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        Init();
        MapManager.instance.InitMap();
        LogManager.instance.InitEmptyCategoryLogs();
        ScenarioManager.instance.ActivateScenarios(true);
        ScenarioManager.instance.InitBaseScenario();
        MyCamera.instance.SetOSizeByMap();

        isRunning = true;
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
        if (GameManager.instance.currentStage == 1) Debug.Log("튜토리얼 - 눈알 A는 악마입니다.");
        else if (GameManager.instance.currentStage == 2) Debug.Log("튜토리얼 - 눈알 A는 천사입니다.");
        else Debug.Log("");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Main Menu");
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("GamePlay");

        if (!isRunning) return;

        Vector3Int dir = GetDirectionFromKey();
        if (CanMove(dir))
        {
            posOnMap += dir;
            Tween.Position(player.transform, posOnMap + MyUtils.offset, 0.1f, Ease.InOutSine);
            
            DataBoxUpdate();
        }

        if(CheckGameOver()) GameOver();
        if(CheckStageClear()) StageClear();
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
        isRunning = false;
        stageClearWindow.SetActive(true);
        if (GameManager.instance.currentStage == GameManager.instance.maxStage) GameManager.instance.maxStage++;
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
        isRunning = false;
        gameOverWindow.SetActive(true);
    }

    IEnumerator WaitForSeconds(float dur)
    {
        isRunning = false;
        yield return new WaitForSeconds(dur);
        isRunning = true;
    }

    public void OnMenuClicked() => SceneManager.LoadScene("Main Menu");

    public void OnRetryClicked() => SceneManager.LoadScene("GamePlay");

    public void OnNextClicked()
    {
        GameManager.instance.currentStage++;
        SceneManager.LoadScene("GamePlay");
    }
}
