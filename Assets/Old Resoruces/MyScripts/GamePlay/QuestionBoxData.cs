using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PrimeTween;

public class QuestionBoxData : MonoBehaviour
{
    public TDObject lastRedTile;
    public TDObject lastBlueTile;
    public TDObject lastGreenTile;

    public bool isfull
    {
        get
        {
            return lastRedTile != null && lastBlueTile != null && lastGreenTile != null;
        }
    }
    public bool isInvalid
    {
        get
        {
            if (lastRedTile == null || lastBlueTile == null) return false;
            RedData redData = (RedData)lastRedTile.tileData.data[0];
            BlueData blueData = (BlueData)lastBlueTile.tileData.data[0];
            return (redData == RedData.EXIT && blueData == BlueData.SPECIES) || 
                   (redData == RedData.MAP && (blueData == BlueData.COLOR || blueData == BlueData.POSITION));
        }
    }
    
    [SerializeField] TextMeshProUGUI redBoxText;
    [SerializeField] TextMeshProUGUI blueBoxText;
    [SerializeField] TextMeshProUGUI greenBoxText;
    [SerializeField] Image redBoxImg;
    [SerializeField] Image blueBoxImg;
    [SerializeField] Image greenBoxImg;
    [SerializeField] Sprite redBoxBrightSprite;
    [SerializeField] Sprite blueBoxBrightSprite;
    [SerializeField] Sprite greenBoxBrightSprite;
    [SerializeField] Sprite redBoxDarkSprite;
    [SerializeField] Sprite blueBoxDarkSprite;
    [SerializeField] Sprite greenBoxDarkSprite;
    [SerializeField] RectTransform questionBoxRT;
    [SerializeField] RectTransform highlightRimRT;

    void Start()
    {
        ResetData();
    }

    public void ResetData()
    {
        lastRedTile = lastBlueTile = lastGreenTile = null;
    }

    public void Highlight(TileColor color)
    {
        switch (color)
        {
            case TileColor.RED: highlightRimRT.gameObject.SetActive(true); highlightRimRT.anchoredPosition = new Vector2(-260, 0); break;
            case TileColor.BLUE: highlightRimRT.gameObject.SetActive(true); highlightRimRT.anchoredPosition = new Vector2(0, 0); break;
            case TileColor.GREEN: highlightRimRT.gameObject.SetActive(true); highlightRimRT.anchoredPosition = new Vector2(260, 0); break;
            case TileColor.WHITE: highlightRimRT.gameObject.SetActive(false); break;
        }
    }

    public void ChangeBrightness()
    {
        if (isInvalid)
        {
            redBoxImg.sprite = redBoxDarkSprite;
            blueBoxImg.sprite = blueBoxDarkSprite;
            greenBoxImg.sprite = greenBoxDarkSprite;
        }
        else
        {
            redBoxImg.sprite = redBoxBrightSprite;
            blueBoxImg.sprite = blueBoxBrightSprite;
            greenBoxImg.sprite = greenBoxBrightSprite;
        }
    }

    public void SetAllText()
    {
        if (lastRedTile == null) redBoxText.SetText("");
        else redBoxText.SetText(TDTileData.GetText(lastRedTile.tileData));

        if (lastBlueTile == null) blueBoxText.SetText("");
        else blueBoxText.SetText(TDTileData.GetText(lastBlueTile.tileData));
        
        if (lastGreenTile == null) greenBoxText.SetText("");
        else greenBoxText.SetText(TDTileData.GetText(lastGreenTile.tileData));
    }

    public char GetAnswer()
    {
        if (isInvalid) return '?';

        List<int> redBoxData = lastRedTile.tileData.data;
        List<int> blueBoxData = lastBlueTile.tileData.data;
        List<int> greenBoxData = lastGreenTile.tileData.data;
        if (redBoxData[0] == (int)RedData.EXIT && blueBoxData[0] == (int)BlueData.COLOR)
        {
            TileColor color = (TileColor)blueBoxData[1];
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.EQ: return MapManager.instance.exitColorCount[color] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NE: return MapManager.instance.exitColorCount[color] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.GT: return MapManager.instance.exitColorCount[color] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.LT: return MapManager.instance.exitColorCount[color] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GE: return MapManager.instance.exitColorCount[color] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LE: return MapManager.instance.exitColorCount[color] <= greenBoxData[1] ? 'O' : 'X';
                default: return '?';
            }
        }
        else if (redBoxData[0] == (int)RedData.EXIT && blueBoxData[0] == (int)BlueData.POSITION)
        {
            Position garoSero = (Position)blueBoxData[1];
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.EQ: return MapManager.instance.exitGaroSero[garoSero] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NE: return MapManager.instance.exitGaroSero[garoSero] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.GT: return MapManager.instance.exitGaroSero[garoSero] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.LT: return MapManager.instance.exitGaroSero[garoSero] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GE: return MapManager.instance.exitGaroSero[garoSero] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LE: return MapManager.instance.exitGaroSero[garoSero] <= greenBoxData[1] ? 'O' : 'X';
                default: return '?';
            }
        }
        else if (redBoxData[0] == (int)RedData.MAP && blueBoxData[0] == (int)BlueData.SPECIES)
        {
            Species eye = (Species)blueBoxData[1];
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.EQ: return MapManager.instance.mapEyeCount[eye] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NE: return MapManager.instance.mapEyeCount[eye] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.GT: return MapManager.instance.mapEyeCount[eye] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.LT: return MapManager.instance.mapEyeCount[eye] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GE: return MapManager.instance.mapEyeCount[eye] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LE: return MapManager.instance.mapEyeCount[eye] <= greenBoxData[1] ? 'O' : 'X';
                default: return '?';
            }
        }
        else
        {
            Sequence seq = Sequence.Create()
                .Chain(Tween.LocalPositionX(questionBoxRT, -25, 0.05f))
                .Chain(Tween.LocalPositionX(questionBoxRT, 0, 0.05f))
                .Chain(Tween.LocalPositionX(questionBoxRT, 25, 0.05f))
                .Chain(Tween.LocalPositionX(questionBoxRT, 0, 0.05f));

            return '?';
        }
    }

    public void DecreaseCount(TDEye eye)
    {
        lastRedTile.DecreaseCount();
        lastBlueTile.DecreaseCount();
        lastGreenTile.DecreaseCount();
        eye.DecreaseCount();
    }
}
