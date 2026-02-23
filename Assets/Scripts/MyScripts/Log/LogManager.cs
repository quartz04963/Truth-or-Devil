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
        
        TDEye defaultEye = MapManager.instance.eyeList.Find(eye => eye.index == 0);

        for (int i = 1; i < MapManager.instance.mapEyeCount.Sum(); i++)
        {
            AnswerLog log = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
            TDEye tdEye = MapManager.instance.eyeList.Find(eye => eye.index == i);
            log.Init(MyUtils.RedDataNull, MyUtils.BlueDataNull, MyUtils.GreenDataNull, tdEye);
            log.SetAsEmptyCategory();
            log.UpdateByDropdown(dropdown.value);
            logList.Add(log);
        }

        for (int i = 1; i <= (int)TileColor.White; i++)
        {
            AnswerLog log = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
            log.Init(MyUtils.RedDataNull, new List<int>{(int)BlueData.Color, i}, MyUtils.GreenDataNull, defaultEye);
            log.SetAsEmptyCategory();
            log.UpdateByDropdown(dropdown.value);
            logList.Add(log);
        }

        for (int i = 2; i <= (int)ToD.Devil; i++)
        {
            AnswerLog log = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
            log.Init(MyUtils.RedDataNull, new List<int>{(int)BlueData.Eye, i}, MyUtils.GreenDataNull, defaultEye);
            log.SetAsEmptyCategory();
            log.UpdateByDropdown(dropdown.value);
            logList.Add(log);
        }
    }

    public void AddLog(List<int> redTileData, List<int> blueTileData, List<int> greenTileData, TDEye tdEye, char answer)
    {
        foreach (AnswerLog log in logList)
        {
            if (log.redTileData.SequenceEqual(redTileData) && log.blueTileData.SequenceEqual(blueTileData) && log.greenTileData.SequenceEqual(greenTileData) 
                && log.tdEye == tdEye) return;
        }

        AnswerLog answerlog = Instantiate(answerLogPrf, content).GetComponent<AnswerLog>();
        answerlog.Init(redTileData, blueTileData, greenTileData, tdEye, ZString.Concat(answer));
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
            case 1: sortedLogList = logList.OrderBy(log => log.tdEye.index).ToList(); break;
            case 2: sortedLogList = logList.OrderBy(log => log.blueTileData[1]).ToList(); break;
            case 3: sortedLogList = logList.OrderBy(log => log.blueTileData[1]).ToList(); break;
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
