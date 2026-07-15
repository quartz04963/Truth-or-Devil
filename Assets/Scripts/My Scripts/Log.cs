using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Log : MonoBehaviour
{
    [SerializeField] Map map;
    [SerializeField] Transform content;
    [SerializeField] GameObject logItemPrf;
    [SerializeField] GameObject logSeparatorPrf;
    [SerializeField] GameObject logSeparatorLinePrf;
    [SerializeField] TMP_Dropdown dropdown;

    private bool isMapAvailable = true;
    private EyeTile dummyEyeTile;
    private List<LogItem> logItems = new List<LogItem>();

    public void Init()
    {
        InitSeparators();
        InitDropdown();
    }

    void InitDropdown()
    {
        if (PuzzleManager.instance.Chapter < 1)
        {
            dropdown.options.RemoveAt(3);
            dropdown.options[1] = new TMP_Dropdown.OptionData("EXIT + 색깔");
        }

        if (PuzzleManager.instance.Chapter < 2)
        {
            isMapAvailable = false;
            dropdown.options.RemoveAt(2);
        }
        
        dropdown.RefreshShownValue();
    }

    public void InitSeparators()
    {
        dummyEyeTile = (EyeTile)map.dummyDict["dummyEyeTile"];

        TileObject dummyGreenTileObj = map.dummyDict["dummyGreenTileObj"],
                   dummyExit = map.dummyDict["EXIT"],
                   dummyMap = map.dummyDict["MAP"];

        bool isPosition = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.POSITION);
        bool isColor = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.COLOR);
        
        bool isRed = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.COLOR && tile.Data[1] == (int)TileColor.RED);
        bool isBlue = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.COLOR && tile.Data[1] == (int)TileColor.BLUE);
        bool isGreen = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.COLOR && tile.Data[1] == (int)TileColor.GREEN);
        bool isWhite = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.COLOR && tile.Data[1] == (int)TileColor.WHITE);

        bool isAngel = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.SPECIES && tile.Data[1] == (int)Species.ANGEL);
        bool isDevil = map.blueTiles.Exists(tile => !tile.IsHiding && tile.Data[0] == (int)BlueData.SPECIES && tile.Data[1] == (int)Species.DEVIL);

        bool isHidden = map.blueTiles.Exists(tile => tile.IsHiding);

        if (isPosition) AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["POSITION"], dummyGreenTileObj, "<위치>");
        if (isColor) AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["COLOR"], dummyGreenTileObj, "<색깔>");

        if (isRed) AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["RED"], dummyGreenTileObj, "RED");
        if (isBlue) AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["BLUE"], dummyGreenTileObj, "BLUE");
        if (isGreen) AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["GREEN"], dummyGreenTileObj, "GREEN");
        if (isWhite) AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["WHITE"], dummyGreenTileObj, "WHITE");

        if (isAngel) AddSeparator(dummyEyeTile, dummyMap, map.dummyDict["ANGEL"], dummyGreenTileObj, "천사");
        if (isDevil) AddSeparator(dummyEyeTile, dummyMap, map.dummyDict["DEVIL"], dummyGreenTileObj, "악마");

        if (isHidden) 
        {
            AddSeparator(dummyEyeTile, dummyExit, map.dummyDict["???"], dummyGreenTileObj, "???");
            AddSeparator(dummyEyeTile, dummyMap, map.dummyDict["???"], dummyGreenTileObj, "???");
        }

        foreach (EyeTile eye in map.eyes) // 눈알 타일은 이동 불가능 전제
        {
            AddSeparator(eye, map.dummyDict["dummyRedTileObj"], map.dummyDict["ANGEL"], dummyGreenTileObj);
        }

        SortItem(dropdown.value);
    }

    void AddSeparator(EyeTile eyeTile, TileObject redTileObj, TileObject blueTileObj, TileObject greenTileObj, string separatorText = null)
    {
        GameObject logSeparator = separatorText == null ? Instantiate(logSeparatorLinePrf, content) : Instantiate(logSeparatorPrf, content);
        logSeparator.TryGetComponent(out LogItem logItem);

        logItem.InitAsSeparator(eyeTile, redTileObj, blueTileObj, greenTileObj, separatorText);
        
        if (!logItems.Contains(logItem)) logItems.Add(logItem);
        else Destroy(logSeparator);
    }

    public void AddItem(EyeTile eyeTile, TileObject redTileObj, TileObject blueTileObj, TileObject greenTileObj, string answerText)
    {
        GameObject logItemObj = Instantiate(logItemPrf, content);
        logItemObj.TryGetComponent(out LogItem logItem);

        logItem.Init(eyeTile, redTileObj, blueTileObj, greenTileObj, answerText);

        if (!logItems.Contains(logItem)) logItems.Add(logItem);
        else Destroy(logItemObj);

        SortItem(dropdown.value);
    }

    public void AddItem(EyeTile eyeTile, Question question, string answerText)
    {
        AddItem(eyeTile, question.RedTileObj, question.BlueTileObj, question.GreenTileObj, answerText);
    }

    public void SortItem(int criteria)
    {
        List<LogItem> sorted;

        int latest = 0;
        int exit = 1;
        int map = isMapAvailable ? 2 : 3;
        int eye = isMapAvailable ? 3 : 2;
        
        if (criteria == latest)
        {
            for (int i = 0; i < logItems.Count; i++)
            {
                logItems[i].transform.SetSiblingIndex(i);
                logItems[i].gameObject.SetActive(!logItems[i].IsSeparator);
            }
        }
        else if (criteria == exit)
        {
            sorted = logItems.OrderByDescending(item => item.BlueTileObj.IsHiding)
                                .ThenBy(item => item.BlueTileObj.Data[0])
                                .ThenBy(item => item.BlueTileObj.Data[1]).ToList();
            for (int i = 0; i < sorted.Count; i++)
            {
                sorted[i].transform.SetSiblingIndex(i);
                sorted[i].gameObject.SetActive(sorted[i].RedTileObj.Data[0] == (int)RedData.EXIT);
            }
        }
        else if (criteria == map)
        {
            sorted = logItems.OrderByDescending(item => item.BlueTileObj.IsHiding)
                                .ThenBy(item => item.BlueTileObj.Data[1]).ToList();
            for (int i = 0; i < sorted.Count; i++)
            {
                sorted[i].transform.SetSiblingIndex(i);
                sorted[i].gameObject.SetActive(sorted[i].RedTileObj.Data[0] == (int)RedData.MAP);
            }
        }
        else if (criteria == eye)
        {
            sorted = logItems.OrderBy(item => item.EyeTile.Index).ToList();
            for (int i = 0; i < sorted.Count; i++)
            {
                sorted[i].transform.SetSiblingIndex(i);
                sorted[i].gameObject.SetActive(sorted[i].EyeTile != dummyEyeTile);
            }
        }   
    }

    public void UpdateEyeImages()
    {
        foreach (LogItem item in logItems)
        {
            item.UpdateEyeImage();
        }
    }
}
