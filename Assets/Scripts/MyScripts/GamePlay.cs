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

    public int questionCount = 0;
    public bool isRunning = true;
    public bool isLogShowing = true;
    public GameObject player;
    public Vector3Int posOnMap;
    public List<int> redData, blueData, greenData;
    public TextMeshProUGUI redBox, blueBox, greenBox;

    public ScrollRect scrollRect;
    public GameObject scrollView;
    public GameObject answerLogPrf;
    public RectTransform content;
    public RectTransform showLogButton;
    public TextMeshProUGUI showLogButtonTMP;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        redData = MyUtils.RedDataNull;
        blueData =  MyUtils.BlueDataNull;
        greenData = MyUtils.GreenDataNull;
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
            
            DataUpdate();
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

    void DataUpdate()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);

        switch (tile.color)
        {
            case TileColor.Red: redData = tile.data; break;
            case TileColor.Blue: blueData = tile.data; break;
            case TileColor.Green: greenData = tile.data; break;
            case TileColor.White:
                if(tile.data[0] == (int)WhiteData.Eye && CheckQuestion(redData, blueData, greenData))
                {
                    Answer(tile.data[1], tile.data[2]);
                    redData = MyUtils.RedDataNull;
                    blueData = MyUtils.BlueDataNull;
                    greenData = MyUtils.GreenDataNull;
                }
                break;
        }

        redBox.SetText(MyUtils.GetTextFromData(TileColor.Red, redData));
        blueBox.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueData));
        greenBox.SetText(MyUtils.GetTextFromData(TileColor.Green, greenData));
    }

    void Answer(int id, int code)
    {
        questionCount++;
        char answer = '?';
        if (redData[0] == (int)RedData.Gate && blueData[0] == (int)BlueData.Color)
        {
            switch ((GreenData)greenData[0])
            {
                case GreenData.Equal: answer = MapManager.instance.gateColorCount[blueData[1]] == greenData[1] ? 'O' : 'X'; break;
                case GreenData.NotEqual: answer = MapManager.instance.gateColorCount[blueData[1]] != greenData[1] ? 'O' : 'X'; break;
                case GreenData.Greater: answer = MapManager.instance.gateColorCount[blueData[1]] > greenData[1] ? 'O' : 'X'; break;
                case GreenData.Less: answer = MapManager.instance.gateColorCount[blueData[1]] < greenData[1] ? 'O' : 'X'; break;
                case GreenData.GreaterOrEqual: answer = MapManager.instance.gateColorCount[blueData[1]] >= greenData[1] ? 'O' : 'X'; break;
                case GreenData.LessOrEqual: answer = MapManager.instance.gateColorCount[blueData[1]] <= greenData[1] ? 'O' : 'X'; break;
            }
        }
        else if (redData[0] == (int)RedData.Map && blueData[0] == (int)BlueData.Eye)
        {
            switch ((GreenData)greenData[0])
            {
                case GreenData.Equal: answer = MapManager.instance.mapEyeCount[blueData[1]] == greenData[1] ? 'O' : 'X'; break;
                case GreenData.NotEqual: answer = MapManager.instance.mapEyeCount[blueData[1]] != greenData[1] ? 'O' : 'X'; break;
                case GreenData.Greater: answer = MapManager.instance.mapEyeCount[blueData[1]] > greenData[1] ? 'O' : 'X'; break;
                case GreenData.Less: answer = MapManager.instance.mapEyeCount[blueData[1]] < greenData[1] ? 'O' : 'X'; break;
                case GreenData.GreaterOrEqual: answer = MapManager.instance.mapEyeCount[blueData[1]] >= greenData[1] ? 'O' : 'X'; break;
                case GreenData.LessOrEqual: answer = MapManager.instance.mapEyeCount[blueData[1]] <= greenData[1] ? 'O' : 'X'; break;
            }
        }
        if (id == (int)ToD.Devil) answer = answer == 'O' ? 'X' : 'O'; 

        TextMeshProUGUI answerLog = Instantiate(answerLogPrf, content).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        answerLog.SetText(
            ZString.Format("Q{0}. {1} {2} {3}\n   A. Eye {4} : {5}", questionCount, redBox.text, blueBox.text, greenBox.text, (char)('A' + code), answer)
        );
        StartCoroutine(ScrollToBottom());
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
            showLogButton.anchoredPosition = new Vector3(-20, 0, 0);
            showLogButtonTMP.SetText("<");
        }
        else
        {
            showLogButton.anchoredPosition = new Vector3(-154, 0, 0);
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
}
