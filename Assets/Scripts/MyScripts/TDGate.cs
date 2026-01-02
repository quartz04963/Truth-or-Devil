using UnityEngine;
using System;
using TMPro;
using Cysharp.Text;

public class TDGate : TDObject
{
    public int index;
    public GameObject infoBox;
    public TextMeshProUGUI redCountText, blueCountText, greenCountText, whiteCountText;
    public void Init(Vector3Int _pos, int _index)
    {
        index = _index;
        base.Init(_pos, ZString.Format("{0}", (char)('A' + index)));
        tmp.rectTransform.position = _pos + MyUtils.offset + new Vector3(0.3f, -0.3f, 0);
        SetInfoBox();
    }

    public void SetInfoBox()
    {
        int[] gateColorCount = new[]{0, 0, 0, 0};
        foreach (TDData tile in MapManager.instance.tileList)
        {
            if (Math.Abs(tile.pos.x - pos.x) <= 1 && Math.Abs(tile.pos.y - pos.y) <= 1) gateColorCount[(int)tile.color]++;
        }
        gateColorCount[(int)TileColor.White]--;

        redCountText.SetText(ZString.Concat("RED : ", gateColorCount[(int)TileColor.Red]));
        blueCountText.SetText(ZString.Concat("BLUE : ", gateColorCount[(int)TileColor.Blue]));
        greenCountText.SetText(ZString.Concat("GREEN : ", gateColorCount[(int)TileColor.Green]));
        whiteCountText.SetText(ZString.Concat("WHITE : ", gateColorCount[(int)TileColor.White]));
    }

    void OnMouseEnter()
    {
        infoBox.SetActive(true);
    }

    void OnMouseExit()
    {
        infoBox.SetActive(false);
    }
}
