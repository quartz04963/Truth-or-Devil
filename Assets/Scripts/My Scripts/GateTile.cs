using System.Collections.Generic;
using Cysharp.Text;
using TMPro;
using UnityEngine;

public class GateTile : TileObject
{
    [SerializeField] bool isExit;
    [SerializeField] bool isMarked = false;
    [SerializeField] TextMeshProUGUI codeText;
    [SerializeField] TextMeshProUGUI redCountText;
    [SerializeField] TextMeshProUGUI blueCountText;
    [SerializeField] TextMeshProUGUI greenCountText;
    [SerializeField] TextMeshProUGUI whiteCountText;
    [SerializeField] GameObject redCount;
    [SerializeField] GameObject blueCount;
    [SerializeField] GameObject greenCount;
    [SerializeField] GameObject whiteCount;
    [SerializeField] GameObject colorInfo;
    [SerializeField] GameObject xMark;

    public bool IsExit => isExit;
    public bool IsMarked => isMarked;

    public override void Init(Vector3Int pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false, Sprite thornSprite = null)
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn, thornSprite);
        isExit = data[1] == 1 ? true : false;
    }

    public void SetCode(int num)
    {
        codeText.SetText(ZString.Concat((char)('A' + num - 1)));
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
