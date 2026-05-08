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
            return (redData == RedData.Exit && blueData == BlueData.Eye) || 
                   (redData == RedData.Map && (blueData == BlueData.Color || blueData == BlueData.GaroSero));
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
            case TileColor.Red: highlightRimRT.gameObject.SetActive(true); highlightRimRT.anchoredPosition = new Vector2(-260, 0); break;
            case TileColor.Blue: highlightRimRT.gameObject.SetActive(true); highlightRimRT.anchoredPosition = new Vector2(0, 0); break;
            case TileColor.Green: highlightRimRT.gameObject.SetActive(true); highlightRimRT.anchoredPosition = new Vector2(260, 0); break;
            case TileColor.White: highlightRimRT.gameObject.SetActive(false); break;
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
        else redBoxText.SetText(TileData.GetText(lastRedTile.tileData));

        if (lastBlueTile == null) blueBoxText.SetText("");
        else blueBoxText.SetText(TileData.GetText(lastBlueTile.tileData));
        
        if (lastGreenTile == null) greenBoxText.SetText("");
        else greenBoxText.SetText(TileData.GetText(lastGreenTile.tileData));
    }

    public char GetAnswer()
    {
        if (isInvalid) return '?';

        List<int> redBoxData = lastRedTile.tileData.data;
        List<int> blueBoxData = lastBlueTile.tileData.data;
        List<int> greenBoxData = lastGreenTile.tileData.data;
        if (redBoxData[0] == (int)RedData.Exit && blueBoxData[0] == (int)BlueData.Color)
        {
            TileColor color = (TileColor)blueBoxData[1];
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: return MapManager.instance.exitColorCount[color] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NotEqual: return MapManager.instance.exitColorCount[color] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.Greater: return MapManager.instance.exitColorCount[color] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.Less: return MapManager.instance.exitColorCount[color] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GreaterOrEqual: return MapManager.instance.exitColorCount[color] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LessOrEqual: return MapManager.instance.exitColorCount[color] <= greenBoxData[1] ? 'O' : 'X';
                default: return '?';
            }
        }
        else if (redBoxData[0] == (int)RedData.Exit && blueBoxData[0] == (int)BlueData.GaroSero)
        {
            GaroSero garoSero = (GaroSero)blueBoxData[1];
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: return MapManager.instance.exitGaroSero[garoSero] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NotEqual: return MapManager.instance.exitGaroSero[garoSero] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.Greater: return MapManager.instance.exitGaroSero[garoSero] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.Less: return MapManager.instance.exitGaroSero[garoSero] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GreaterOrEqual: return MapManager.instance.exitGaroSero[garoSero] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LessOrEqual: return MapManager.instance.exitGaroSero[garoSero] <= greenBoxData[1] ? 'O' : 'X';
                default: return '?';
            }
        }
        else if (redBoxData[0] == (int)RedData.Map && blueBoxData[0] == (int)BlueData.Eye)
        {
            ToD eye = (ToD)blueBoxData[1];
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: return MapManager.instance.mapEyeCount[eye] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NotEqual: return MapManager.instance.mapEyeCount[eye] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.Greater: return MapManager.instance.mapEyeCount[eye] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.Less: return MapManager.instance.mapEyeCount[eye] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GreaterOrEqual: return MapManager.instance.mapEyeCount[eye] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LessOrEqual: return MapManager.instance.mapEyeCount[eye] <= greenBoxData[1] ? 'O' : 'X';
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
