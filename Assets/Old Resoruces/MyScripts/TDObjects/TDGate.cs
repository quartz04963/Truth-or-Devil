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

    public void Init(TDTileData tileData)
    {
        code = tileData.data[2];
        base.Init(tileData, ZString.Format("{0}", (char)('A' + code)));
    }

    public void SetInfoBox()
    {
        Dictionary<TileColor, int> gateColorCount = new Dictionary<TileColor, int>();
        gateColorCount[TileColor.RED] = 0;
        gateColorCount[TileColor.BLUE] = 0;
        gateColorCount[TileColor.GREEN] = 0;
        gateColorCount[TileColor.WHITE] = 0;

        foreach (TDTileData tile in MapManager.instance.currentStageData.tiles)
        {
            if (Math.Abs(tile.pos.x - pos.x) <= 1 && Math.Abs(tile.pos.y - pos.y) <= 1) {
                gateColorCount[tile.color]++;
            }
        }
        gateColorCount[TileColor.WHITE]--;

        redCountText.SetText(ZString.Concat("RED : ", gateColorCount[TileColor.RED]));
        blueCountText.SetText(ZString.Concat("BLUE : ", gateColorCount[TileColor.BLUE]));
        greenCountText.SetText(ZString.Concat("GREEN : ", gateColorCount[TileColor.GREEN]));
        whiteCountText.SetText(ZString.Concat("WHITE : ", gateColorCount[TileColor.WHITE]));
        
        redCountText.gameObject.SetActive(MapManager.instance.canAskRed); 
        blueCountText.gameObject.SetActive(MapManager.instance.canAskBlue);
        greenCountText.gameObject.SetActive(MapManager.instance.canAskGreen);
        whiteCountText.gameObject.SetActive(MapManager.instance.canAskWhite);
    }

    public void SetSprite(Species tod)
    {
        switch (tod)
        {
            case Species.NULL: spriteRenderer.sprite = defaultSprite; break;
            case Species.ANGEL: spriteRenderer.sprite = heavenSprite; break;
            case Species.DEVIL: spriteRenderer.sprite = hellSprite; break;
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
        
        if (MapManager.instance.map.Find(obj => obj.tileData.color == TileColor.BLUE && obj.tileData.data[0] == (int)BlueData.COLOR) != null)
            infoBox.SetActive(true);
    }

    void OnMouseExit()
    {
        infoBox.SetActive(false);
    }
}
