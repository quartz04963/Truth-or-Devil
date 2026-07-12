using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject logItemPrf;
    
    private List<LogItem> logItemList = new List<LogItem>();

    public void AddLog(EyeTile eyeTile, TileObject redTileObj, TileObject blueTileObj, TileObject greenTileObj, string answerText)
    {
        GameObject logItemObj = Instantiate(logItemPrf, content);
        logItemObj.TryGetComponent(out LogItem logItem);

        logItem.Init(eyeTile, redTileObj, blueTileObj, greenTileObj, answerText);

        if (!logItemList.Contains(logItem)) logItemList.Add(logItem);
        else Destroy(logItemObj);
    }

    public void AddLog(EyeTile eyeTile, Question question, string answerText)
    {
        AddLog(eyeTile, question.RedTileObj, question.BlueTileObj, question.GreenTileObj, answerText);
    }
}
