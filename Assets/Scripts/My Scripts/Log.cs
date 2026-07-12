using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject logItemPrf;
    [SerializeField] TMP_Dropdown dropdown;

    private List<LogItem> logItemList = new List<LogItem>();

    public void AddItem(EyeTile eyeTile, TileObject redTileObj, TileObject blueTileObj, TileObject greenTileObj, string answerText)
    {
        GameObject logItemObj = Instantiate(logItemPrf, content);
        logItemObj.TryGetComponent(out LogItem logItem);

        logItem.Init(eyeTile, redTileObj, blueTileObj, greenTileObj, answerText);

        if (!logItemList.Contains(logItem)) logItemList.Add(logItem);
        else Destroy(logItemObj);

        SortItem(dropdown.value);
    }

    public void AddItem(EyeTile eyeTile, Question question, string answerText)
    {
        AddItem(eyeTile, question.RedTileObj, question.BlueTileObj, question.GreenTileObj, answerText);
    }

    public void SortItem(int num)
    {
        List<LogItem> sorted;

        switch (num)
        {
            case 0: 
                for (int i = 0; i < logItemList.Count; i++)
                {
                    logItemList[i].transform.SetSiblingIndex(i);
                    logItemList[i].gameObject.SetActive(true);
                }
                break;

            case 1:
                sorted = logItemList.OrderByDescending(item => item.BlueTileObj.IsHiding)
                                    .ThenBy(item => item.BlueTileObj.Data[0])
                                    .ThenBy(item => item.BlueTileObj.Data[1]).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    sorted[i].transform.SetSiblingIndex(i);
                    sorted[i].gameObject.SetActive(sorted[i].RedTileObj.Data[0] == (int)RedData.EXIT);
                }
                break;

            case 2:
                sorted = logItemList.OrderByDescending(item => item.BlueTileObj.IsHiding)
                                    .ThenBy(item => item.BlueTileObj.Data[1]).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    sorted[i].transform.SetSiblingIndex(i);
                    sorted[i].gameObject.SetActive(sorted[i].RedTileObj.Data[0] == (int)RedData.MAP);
                }
                break;

            case 3:
                sorted = logItemList.OrderBy(item => item.EyeTile.Code).ToList();
                for (int i = 0; i < sorted.Count; i++)
                {
                    sorted[i].transform.SetSiblingIndex(i);
                    sorted[i].gameObject.SetActive(true);
                }
                break;
        }
    }


}
