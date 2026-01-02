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
    public int questionCount = 0;
    public bool isRunning = true;
    public bool isLogShowing = true;
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

    [Header("로그 관련")]
    public ScrollRect scrollRect;
    public GameObject scrollView;
    public RectTransform showLogButton;
    public TextMeshProUGUI showLogButtonTMP;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        Init();
        MapManager.instance.InitMap(stageNumber);
        LogManager.instance.InitEmptyCategoryLogs();
        ScenarioManager.instance.SetBaseScenario();
    }

    void Init()
    {
        redBoxData = MyUtils.RedDataNull;
        blueBoxData =  MyUtils.BlueDataNull;
        greenBoxData = MyUtils.GreenDataNull;
        eyeBoxImage.enabled = false;
        player.gameObject.SetActive(true);
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

        foreach (TDObject obj in MapManager.instance.objectList)
        {
            if (obj is TDEye eye && !eye.isMarked) return false;
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
                    Answer((TDEye)MapManager.instance.objectList.Find(eye => eye.pos == posOnMap));
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
        StartCoroutine(ScrollToBottom());
        StartCoroutine(WaitForSeconds(1f));
    }

    IEnumerator ScrollToBottom()
    {
        yield return null;
        scrollRect.verticalNormalizedPosition = 0f;
    }

    public void OnShowLogClicked()
    {
        if (isLogShowing)
        {
            showLogButton.anchoredPosition = new Vector3(-10, 30, 0);
            showLogButtonTMP.SetText("<");
        }
        else
        {
            showLogButton.anchoredPosition = new Vector3(-190, 30, 0);
            showLogButtonTMP.SetText(">");
        }

        isLogShowing = !isLogShowing;
        scrollView.SetActive(isLogShowing);
    }

    bool CheckStageClear()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)ToD.Truth) {
            foreach(TDObject obj in MapManager.instance.objectList)
            {
                if (obj is TDEye eye && eye.trueID != eye.guessedID) return false;
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
        
        foreach(TDObject obj in MapManager.instance.objectList)
        {
            if (obj is TDEye eye && eye.trueID != eye.guessedID) return true;
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
}
