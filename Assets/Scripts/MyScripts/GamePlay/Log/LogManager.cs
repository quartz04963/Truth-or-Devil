using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Text;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public static LogManager instance;

    public List<AnswerLog> logList;
    public GameObject answerLogPrf;
    public RectTransform content;
    public TMP_Dropdown dropdown;
    public ScrollRect LogScrollRect;

    public bool isShowing = true;
    public bool isSliding;
    public RectTransform logRT;
    public RectTransform showLogRT;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void InitEmptyCategoryLogs()
    {
        logList = new List<AnswerLog>();

        for (int i = 0; i < MapManager.instance.mapEyeCount.Values.Sum(); i++)
        {
            AnswerLog log = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
            TDEye tdEye = MapManager.instance.eyes.Find(eye => eye.code == i);
            log.Init(TileData.Null, TileData.Null, TileData.Null, tdEye);
            log.SetAsEmptyCategory();
            log.UpdateByDropdown(dropdown.value);
            logList.Add(log);
        }

        TDEye defaultEye = MapManager.instance.eyes.Find(eye => eye.code == 0);
        if (defaultEye == null) return;

        for (int i = (int)TileColor.Red; i <= (int)TileColor.White; i++)
        {
            AnswerLog log = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
            TileData blueData = new TileData(Vector3Int.zero, TileColor.Null, new List<int>{(int)BlueData.Color, i}, false, -1);
            log.Init(TileData.Null, blueData, TileData.Null, defaultEye);
            log.SetAsEmptyCategory();
            log.UpdateByDropdown(dropdown.value);
            logList.Add(log);
        }

        for (int i = (int)ToD.Truth; i <= (int)ToD.Devil; i++)
        {
            AnswerLog log = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
            TileData blueData = new TileData(Vector3Int.zero, TileColor.Null, new List<int>{(int)BlueData.Eye, i}, false, -1);
            log.Init(TileData.Null, blueData, TileData.Null, defaultEye);
            log.SetAsEmptyCategory();
            log.UpdateByDropdown(dropdown.value);
            logList.Add(log);
        }
    }

    public void AddLog(QuestionBoxData qustion, TDEye tdEye, char answer)
    {
        foreach (AnswerLog log in logList)
        {
            if (log.tdEye == tdEye &&
                log.redTileData.data.SequenceEqual(qustion.lastRedTile.tileData.data) && 
                log.blueTileData.data.SequenceEqual(qustion.lastBlueTile.tileData.data) && 
                log.greenTileData.data.SequenceEqual(qustion.lastGreenTile.tileData.data)
            ) return;
        }

        AnswerLog answerlog = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
        answerlog.Init(qustion.lastRedTile.tileData, qustion.lastBlueTile.tileData, qustion.lastGreenTile.tileData, tdEye, ZString.Concat(answer));
        logList.Add(answerlog);

        OnDropdownChanged();
        StartCoroutine(ScrollToBottom());
    }

    public void OnDropdownChanged()
    {
        foreach (AnswerLog log in logList) log.UpdateByDropdown(dropdown.value);

        List<AnswerLog> sortedLogList = new List<AnswerLog>();
        switch (dropdown.value)
        {
            case 0: sortedLogList = logList; break;
            case 1: sortedLogList = logList.OrderBy(log => log.tdEye.code).ToList(); break;
            case 2: sortedLogList = logList.OrderBy(log => log.blueTileData.data[1]).ToList(); break;
            case 3: sortedLogList = logList.OrderBy(log => log.blueTileData.data[1]).ToList(); break;
        }
        
        for (int i = 0; i < sortedLogList.Count; i++)
        {
            sortedLogList[i].transform.SetSiblingIndex(i);
        }

        // SetExistingCategory();
    }

    // void SetExistingCategory()
    // {
    //     switch (dropdown.value)
    //     {
    //         case 1: 
    //             for (int i = 1; i < MapManager.instance.mapEyeCount.Sum(); i++)
    //             {
    //                 AnswerLog log = logList.Find(log => !log.isEmptyCategory && log.tdEye.index == i);
    //                 if (log != null)
    //                 {
    //                     // log.categoryBox.enabled = true;
    //                     // log.categoryText.enabled = true;
    //                     // log.categoryText.SetText(MyUtils.ConvertToRoman(i + 1));
    //                     // log.categoryText.color = Color.white;
    //                 }
    //             }
    //             break;

    //         case 2: 
    //             for (int i = 1; i <= (int)TileColor.White; i++)
    //             {
    //                 AnswerLog log = logList.Find(
    //                         log => !log.isEmptyCategory && log.blueTileData[0] == (int)BlueData.Color && log.blueTileData[1] == i);
    //                 if (log != null)
    //                 {
    //                     // log.categoryBox.enabled = true;
    //                     // log.categoryText.enabled = true;
    //                     // log.categoryText.color = MyUtils.GetColorFromTileColor((TileColor)log.blueTileData[1]);
    //                     // log.categoryText.SetText(MyUtils.GetTextFromData(TileColor.Blue, log.blueTileData));
    //                 }
    //             }
    //             break;
                
    //         case 3:
    //             for (int i = 2; i <= (int)ToD.Devil; i++)
    //             {
    //                 AnswerLog log = logList.Find(
    //                         log => !log.isEmptyCategory && log.blueTileData[0] == (int)BlueData.Eye && log.blueTileData[1] == i);
    //                 if (log != null)
    //                 {
    //                     // log.categoryBox.enabled = true;
    //                     // log.categoryText.enabled = true;
    //                     // log.categoryText.color = Color.white;
    //                     // log.categoryText.SetText(MyUtils.GetTextFromData(TileColor.Blue, log.blueTileData));
    //                 }
    //             }
    //             break;
    //     }
    // }

    IEnumerator ScrollToBottom()
    {
        yield return null;
        LogScrollRect.verticalNormalizedPosition = 0f;
    }

    public void OnShowLogClicked()
    {
        if (isSliding) return;

        isShowing = !isShowing;

        Sequence seq = Sequence.Create();
        seq.ChainCallback(() => isSliding = true);

        if (isShowing)
        {
            seq.Chain(Tween.UIAnchoredPosition(showLogRT, endValue: new Vector3(120, 40, 0), duration: 0.2f));
            seq.ChainDelay(0.1f);
            seq.Chain(Tween.UIAnchoredPosition(logRT, endValue: new Vector3(-215, 520, 0), duration: 0.2f));
        }
        else
        {
            seq.Chain(Tween.UIAnchoredPosition(logRT, endValue: new Vector3(215, 520, 0), duration: 0.2f));
            seq.ChainDelay(0.1f);
            seq.Chain(Tween.UIAnchoredPosition(showLogRT, endValue: new Vector3(-120, 40, 0), duration: 0.2f));
        }
        seq.ChainCallback(() => isSliding = false);
    }
}
