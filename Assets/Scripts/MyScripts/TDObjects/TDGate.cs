using System;
using TMPro;
using Cysharp.Text;
using UnityEngine;
using UnityEngine.UI;

public class TDGate : TDObject
{
    public int index;
    public ToD guessedID;
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite, heavenSprite, hellSprite;
    public Button button;
    public GameObject infoBox;
    public TextMeshProUGUI redCountText, blueCountText, greenCountText, whiteCountText;

    public void Init(Vector3Int _pos, int _index)
    {
        index = _index;
        base.Init(_pos, ZString.Format("{0}", (char)('A' + _index)));
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
        
        redCountText.gameObject.SetActive(MapManager.instance.canAskRed); 
        blueCountText.gameObject.SetActive(MapManager.instance.canAskBlue);
        greenCountText.gameObject.SetActive(MapManager.instance.canAskGreen);
        whiteCountText.gameObject.SetActive(MapManager.instance.canAskWhite);
    }

    public static void SetTDGateState(TDGate gate, ToD _guessedID)
    {
        gate.guessedID = _guessedID;
        switch (_guessedID)
        {
            case ToD.Null: gate.spriteRenderer.sprite = gate.defaultSprite; break;
            case ToD.Truth: gate.spriteRenderer.sprite = gate.heavenSprite; break;
            case ToD.Devil: gate.spriteRenderer.sprite = gate.hellSprite; break;
        }

    }

    public void OnClicked()
    {
        if (!GamePlay.instance.isRunning) return;

        guessedID = (ToD)(((int)guessedID + 1) % 3);
        SetTDGateState(this, guessedID);
    }

    void OnMouseEnter()
    {
        if (!GamePlay.instance.isRunning) return;
        
        if (MapManager.instance.tileList.FindIndex(tile => tile.color == TileColor.Blue && tile.data[0] == (int)BlueData.Color) != -1)
            infoBox.SetActive(true);
    }

    void OnMouseExit()
    {
        infoBox.SetActive(false);
    }
}
