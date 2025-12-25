using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

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

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        redData = RedData.Default;
        blueData = BlueData.Default;
        greenData = GreenData.Default;
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
            player.transform.DOMove(posOnMap + MyUtils.offset, 0.1f).SetEase(Ease.InSine);
            
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
        if (nextTile.color != TileColor.White || nextTile.data[0] != WhiteData.Gate) return true;

        foreach (TDObject obj in MapManager.instance.objectList)
        {
            if (obj is TDEye eye && !eye.isMarked) return false;
        }

        return true;
    }

    public bool CheckQuestion(List<int> redData, List<int> blueData, List<int> greenData)
    {
        if (redData[0] == RedData.Gate && blueData[0] == BlueData.Color && greenData[0] != GreenData.Null) return true;
        if (redData[0] == RedData.Map && blueData[0] == BlueData.Eye && greenData[0] != GreenData.Null) return true;

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
                if(tile.data[0] == WhiteData.Eye && CheckQuestion(redData, blueData, greenData))
                {
                    Answer(tile.data[1], tile.data[2]);
                    redData = RedData.Default;
                    blueData = BlueData.Default;
                    greenData = GreenData.Default;
                }
                break;
        }

        redBox.text = MyUtils.GetTextFromData(TileColor.Red, redData);
        blueBox.text = MyUtils.GetTextFromData(TileColor.Blue, blueData);
        greenBox.text = MyUtils.GetTextFromData(TileColor.Green, greenData);
    }

    void Answer(int id, int code)
    {
        questionCount++;
        char answer = '?';
        if (redData[0] == RedData.Gate && blueData[0] == BlueData.Color)
        {
            switch (greenData[0])
            {
                case GreenData.Equal: answer = MapManager.instance.gateColorCount[blueData[1]] == greenData[1] ? 'O' : 'X'; break;
                case GreenData.NotEqual: answer = MapManager.instance.gateColorCount[blueData[1]] != greenData[1] ? 'O' : 'X'; break;
                case GreenData.Greater: answer = MapManager.instance.gateColorCount[blueData[1]] > greenData[1] ? 'O' : 'X'; break;
                case GreenData.Less: answer = MapManager.instance.gateColorCount[blueData[1]] < greenData[1] ? 'O' : 'X'; break;
                case GreenData.GreaterOrEqual: answer = MapManager.instance.gateColorCount[blueData[1]] >= greenData[1] ? 'O' : 'X'; break;
                case GreenData.LessOrEqual: answer = MapManager.instance.gateColorCount[blueData[1]] <= greenData[1] ? 'O' : 'X'; break;
            }
        }
        else if (redData[0] == RedData.Map && blueData[0] == BlueData.Eye)
        {
            switch (greenData[0])
            {
                case GreenData.Equal: answer = MapManager.instance.mapEyeCount[blueData[1]] == greenData[1] ? 'O' : 'X'; break;
                case GreenData.NotEqual: answer = MapManager.instance.mapEyeCount[blueData[1]] != greenData[1] ? 'O' : 'X'; break;
                case GreenData.Greater: answer = MapManager.instance.mapEyeCount[blueData[1]] > greenData[1] ? 'O' : 'X'; break;
                case GreenData.Less: answer = MapManager.instance.mapEyeCount[blueData[1]] < greenData[1] ? 'O' : 'X'; break;
                case GreenData.GreaterOrEqual: answer = MapManager.instance.mapEyeCount[blueData[1]] >= greenData[1] ? 'O' : 'X'; break;
                case GreenData.LessOrEqual: answer = MapManager.instance.mapEyeCount[blueData[1]] <= greenData[1] ? 'O' : 'X'; break;
            }
        }
        if (id == ToD.Devil) answer = answer == 'O' ? 'X' : 'O'; 

        TextMeshProUGUI answerLog = Instantiate(answerLogPrf, content).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        answerLog.text = $"Q{questionCount}. {redBox.text} {blueBox.text} {greenBox.text}\n" + $"   A. Eye {(char)('A' + code)} : {answer}";
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
            showLogButton.GetChild(0).GetComponent<TextMeshProUGUI>().text = "<";
        }
        else
        {
            showLogButton.anchoredPosition = new Vector3(-154, 0, 0);
            showLogButton.GetChild(0).GetComponent<TextMeshProUGUI>().text = ">";
        }

        isLogShowing = !isLogShowing;
        scrollView.SetActive(isLogShowing);
    }

    bool CheckStageClear()
    {
        TDData tile = MapManager.instance.tileList.Find(tile => tile.pos == posOnMap);
        if (tile.color == TileColor.White && tile.data[0] == WhiteData.Gate && tile.data[1] == ToD.Truth) {
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
        if (tile.color != TileColor.White || tile.data[0] != WhiteData.Gate) return false;

        if(tile.data[1] == ToD.Devil) return true;
        
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
