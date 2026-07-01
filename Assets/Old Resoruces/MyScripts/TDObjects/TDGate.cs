using System;
using TMPro;
using Cysharp.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TDGate : TDObject
{
    public int code;
    
    public bool isMarked;

    public Button button;
    public Image XmarkImg;
    public Image areaBG;
    public GameObject areaRim;
    
    public GameObject infoBox;
    public TextMeshProUGUI redCountText, blueCountText, greenCountText, whiteCountText;

    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite, heavenSprite, hellSprite;

    public void Init(TileData tileData)
    {
        code = tileData.data[2];
        base.Init(tileData, ZString.Format("{0}", (char)('A' + code)));
    }

    public void SetInfoBox()
    {
        Dictionary<TileColor, int> gateColorCount = new Dictionary<TileColor, int>();
        gateColorCount[TileColor.Red] = 0;
        gateColorCount[TileColor.Blue] = 0;
        gateColorCount[TileColor.Green] = 0;
        gateColorCount[TileColor.White] = 0;

        foreach (TileData tile in MapManager.instance.currentStageData.tiles)
        {
            if (Math.Abs(tile.pos.x - pos.x) <= 1 && Math.Abs(tile.pos.y - pos.y) <= 1) {
                gateColorCount[tile.color]++;
            }
        }
        gateColorCount[TileColor.White]--;

        redCountText.SetText(ZString.Concat("RED : ", gateColorCount[TileColor.Red]));
        blueCountText.SetText(ZString.Concat("BLUE : ", gateColorCount[TileColor.Blue]));
        greenCountText.SetText(ZString.Concat("GREEN : ", gateColorCount[TileColor.Green]));
        whiteCountText.SetText(ZString.Concat("WHITE : ", gateColorCount[TileColor.White]));
        
        redCountText.gameObject.SetActive(MapManager.instance.canAskRed); 
        blueCountText.gameObject.SetActive(MapManager.instance.canAskBlue);
        greenCountText.gameObject.SetActive(MapManager.instance.canAskGreen);
        whiteCountText.gameObject.SetActive(MapManager.instance.canAskWhite);
    }

    public void SetSprite(ToD tod)
    {
        switch (tod)
        {
            case ToD.Null: spriteRenderer.sprite = defaultSprite; break;
            case ToD.Truth: spriteRenderer.sprite = heavenSprite; break;
            case ToD.Devil: spriteRenderer.sprite = hellSprite; break;
        }
    }

    public static void SetTDGateState(TDGate gate, bool _isMarked)
    {
        gate.isMarked = _isMarked;
        gate.XmarkImg.enabled = _isMarked;
    }

    public void HighlightArea(bool isOn, bool isfilled = true)
    {
        areaRim.SetActive(isOn);
        areaBG.enabled = isfilled;
    }

    public void OnClicked()
    {
        isMarked = !isMarked;
        XmarkImg.enabled = isMarked;
    }

    void OnMouseEnter()
    {
        if (!GamePlay.instance.IsRunning) return;
        
        if (MapManager.instance.map.Find(obj => obj.tileData.color == TileColor.Blue && obj.tileData.data[0] == (int)BlueData.Color) != null)
            infoBox.SetActive(true);
    }

    void OnMouseExit()
    {
        infoBox.SetActive(false);
    }
}
