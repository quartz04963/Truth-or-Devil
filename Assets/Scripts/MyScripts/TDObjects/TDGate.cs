using System;
using TMPro;
using Cysharp.Text;
using UnityEngine;
using UnityEngine.UI;

public class TDGate : TDObject
{
    public int index;
    
    public bool isMarked;
    public Button button;
    public Image XmarkImg;

    public GameObject infoBox;
    public TextMeshProUGUI redCountText, blueCountText, greenCountText, whiteCountText;

    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite, heavenSprite, hellSprite;

    public void Init(Vector3Int _pos, int _index)
    {
        index = _index;
        base.Init(_pos, ZString.Format("{0}", (char)('A' + _index)));
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
        
        redCountText.gameObject.SetActive(MapManager.instance.canAskRed); 
        blueCountText.gameObject.SetActive(MapManager.instance.canAskBlue);
        greenCountText.gameObject.SetActive(MapManager.instance.canAskGreen);
        whiteCountText.gameObject.SetActive(MapManager.instance.canAskWhite);
    }

    public static void SetTDGateState(TDGate gate, bool _isMarked)
    {
        gate.isMarked = _isMarked;
        gate.XmarkImg.enabled = _isMarked;
    }

    public void OnClicked()
    {
        isMarked = !isMarked;
        XmarkImg.enabled = isMarked;
    }

    void OnMouseEnter()
    {
        if (!GamePlay.instance.IsRunning) return;
        
        if (MapManager.instance.tileList.FindIndex(tile => tile.color == TileColor.Blue && tile.data[0] == (int)BlueData.Color) != -1)
            infoBox.SetActive(true);
    }

    void OnMouseExit()
    {
        infoBox.SetActive(false);
    }
}
