using System.Collections.Generic;
using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateTile : TileObject
{
    [SerializeField] int code;
    [SerializeField] bool isExit;
    [SerializeField] bool isMarked = false;
    [SerializeField] GraphicRaycaster raycaster;

    [SerializeField] TextMeshProUGUI codeTmp;
    [SerializeField] GameObject xMark;
    [SerializeField] GameObject entranceCheck;
    [SerializeField] GameObject colorCount;
    [SerializeField] TextMeshProUGUI redCountTmp;
    [SerializeField] TextMeshProUGUI blueCountTmp;
    [SerializeField] TextMeshProUGUI greenCountTmp;
    [SerializeField] TextMeshProUGUI whiteCountTmp;

    public int Code => code;
    public bool IsExit => isExit;
    public bool IsMarked => isMarked;

    void Update()
    {
        if (entranceCheck.activeSelf)
        {
            if (!PuzzleManager.instance.Player.IsEntering)
            {
                entranceCheck.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0) && !Utils.IsClicked(raycaster, entranceCheck))
            {
                entranceCheck.SetActive(false);
            } 
        }
    }

    public override void Init(Vector3Int pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn);
        isExit = data[1] == 1 ? true : false;
    }

    public override void ActivateThorn() { }

    public void SetCode(int code)
    {
        this.code = code;
        codeTmp.SetText(ZString.Concat((char)('A' + code - 1)));
    }

    public void SetColorCount(Map map)
    {
        int red = 0, blue = 0, green = 0, white = 0;

        foreach (Vector3Int delta in map.neighborsPos)
        {
            if (map.mapDict.TryGetValue(pos + delta, out TileObject neighbor) && !neighbor.IsPlaceable)
            {
                switch (neighbor.Color)
                {
                    case TileColor.RED: red++; break;
                    case TileColor.BLUE: blue++; break;
                    case TileColor.GREEN: green++; break;
                    case TileColor.WHITE: white++; break;
                }
            } 
        }
        
        redCountTmp.SetText(red);
        blueCountTmp.SetText(blue);
        greenCountTmp.SetText(green);
        whiteCountTmp.SetText(white);
    }

    public void Mark()
    {
        if (entranceCheck.activeSelf) return;

        isMarked = !isMarked;
        xMark.SetActive(isMarked);
    }

    public void CheckEntrance()
    {
        entranceCheck.SetActive(true);
        colorCount.SetActive(false);
    }

    public void Enter(bool isEntering)
    {
        entranceCheck.SetActive(false);

        if (isEntering) PuzzleManager.instance.CheckResult(this);
    }

    public void OnMouseEnter()
    {
        if (entranceCheck.activeSelf) return;

        colorCount.SetActive(true);
    }

    public void OnMouseExit()
    {
        colorCount.SetActive(false);
    }
}
