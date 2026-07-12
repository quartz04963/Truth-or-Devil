using System.Collections.Generic;
using Cysharp.Text;
using TMPro;
using UnityEngine;

public class GateTile : TileObject
{
    [SerializeField] int code;
    [SerializeField] bool isExit;
    [SerializeField] bool isMarked = false;

    [SerializeField] TextMeshProUGUI codeTmp;
    [SerializeField] TextMeshProUGUI redCountTmp;
    [SerializeField] TextMeshProUGUI blueCountTmp;
    [SerializeField] TextMeshProUGUI greenCountTmp;
    [SerializeField] TextMeshProUGUI whiteCountTmp;
    [SerializeField] GameObject redCount;
    [SerializeField] GameObject blueCount;
    [SerializeField] GameObject greenCount;
    [SerializeField] GameObject whiteCount;
    [SerializeField] GameObject colorInfo;

    [SerializeField] GameObject xMark;

    public int Code => code;
    public bool IsExit => isExit;
    public bool IsMarked => isMarked;

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

    public void SetCountTexts()
    {
        
    }

    public void Mark()
    {
        isMarked = !isMarked;
        xMark.SetActive(isMarked);
    }

    public void OnMouseEnter()
    {
        colorInfo.SetActive(true);
    }

    public void OnMouseExit()
    {
        colorInfo.SetActive(false);
    }
}
