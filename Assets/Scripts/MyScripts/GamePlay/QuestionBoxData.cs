using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PrimeTween;

public class QuestionBoxData : MonoBehaviour
{
    public List<int> redBoxData;
    public List<int> blueBoxData;
    public List<int> greenBoxData;
    public TDObject lastRedTile;
    public TDObject lastBlueTile;
    public TDObject lastGreenTile;

    public bool isfull
    {
        get
        {
            return(RedData)redBoxData[0] != RedData.Null && 
                (BlueData)blueBoxData[0] != BlueData.Null && 
                (GreenData)greenBoxData[0] != GreenData.Null;
        }
    }
    public bool isInvalid
    {
        get
        {
            return ((RedData)redBoxData[0] == RedData.Gate && (BlueData)blueBoxData[0] == BlueData.Eye) || 
                ((RedData)redBoxData[0] == RedData.Map && (BlueData)blueBoxData[0] == BlueData.Color);
        }
    }
    
    [SerializeField]  TextMeshProUGUI redBoxText;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetData()
    {
        redBoxData = MyUtils.RedDataNull;
        blueBoxData =  MyUtils.BlueDataNull;
        greenBoxData = MyUtils.GreenDataNull;
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
        redBoxText.SetText(MyUtils.GetTextFromData(TileColor.Red, redBoxData));
        blueBoxText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueBoxData));
        greenBoxText.SetText(MyUtils.GetTextFromData(TileColor.Green, greenBoxData));
    }

    public char GetAnswer()
    {
        if (redBoxData[0] == (int)RedData.Gate && blueBoxData[0] == (int)BlueData.Color)
        {
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: return MapManager.instance.gateColorCount[blueBoxData[1]] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NotEqual: return MapManager.instance.gateColorCount[blueBoxData[1]] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.Greater: return MapManager.instance.gateColorCount[blueBoxData[1]] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.Less: return MapManager.instance.gateColorCount[blueBoxData[1]] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GreaterOrEqual: return MapManager.instance.gateColorCount[blueBoxData[1]] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LessOrEqual: return MapManager.instance.gateColorCount[blueBoxData[1]] <= greenBoxData[1] ? 'O' : 'X';
                default: return '?';
            }
        }
        else if (redBoxData[0] == (int)RedData.Map && blueBoxData[0] == (int)BlueData.Eye)
        {
            switch ((GreenData)greenBoxData[0])
            {
                case GreenData.Equal: return MapManager.instance.mapEyeCount[blueBoxData[1]] == greenBoxData[1] ? 'O' : 'X';
                case GreenData.NotEqual: return MapManager.instance.mapEyeCount[blueBoxData[1]] != greenBoxData[1] ? 'O' : 'X';
                case GreenData.Greater: return MapManager.instance.mapEyeCount[blueBoxData[1]] > greenBoxData[1] ? 'O' : 'X';
                case GreenData.Less: return MapManager.instance.mapEyeCount[blueBoxData[1]] < greenBoxData[1] ? 'O' : 'X';
                case GreenData.GreaterOrEqual: return MapManager.instance.mapEyeCount[blueBoxData[1]] >= greenBoxData[1] ? 'O' : 'X';
                case GreenData.LessOrEqual: return MapManager.instance.mapEyeCount[blueBoxData[1]] <= greenBoxData[1] ? 'O' : 'X';
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

    public void UpdateLastTile(TileColor color, TDObject lastTile)
    {
        switch (color)
        {
            case TileColor.Red: lastRedTile = lastTile; break;
            case TileColor.Blue: lastBlueTile = lastTile; break;
            case TileColor.Green: lastGreenTile = lastTile; break;
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
