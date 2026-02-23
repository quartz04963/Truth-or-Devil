using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Text;

public class AnswerLog : MonoBehaviour
{
    public bool isEmptyCategory;
    public TDEye tdEye;
    public List<int> redTileData;
    public List<int> blueTileData;
    public List<int> greenTileData;

    // public GameObject category;
    // public Image categoryBox, redDataBox, blueDataBox, greenDataBox, eyeDataBox, answerDataBox;
    public GameObject ring;
    public GameObject background;
    public GameObject line;
    public LayoutElement layoutElement;
    public Image eyeImg;
    public Sprite defaultSprite, angelSprite, devilSprite;

    // public TextMeshProUGUI categoryText; 
    public TextMeshProUGUI redDataTMP, blueDataTMP, greenDataTMP, eyeIndexTMP, answerTMP;
    

    public void Init(List<int> _redTileData, List<int> _blueTileData, List<int> _greenTileData, TDEye _tdEye, string answer = "")
    {
        redTileData = _redTileData;
        blueTileData = _blueTileData;
        greenTileData = _greenTileData;
        tdEye = _tdEye;

        redDataTMP.SetText(MyUtils.GetTextFromData(TileColor.Red, redTileData));
        blueDataTMP.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueTileData));
        greenDataTMP.SetText(MyUtils.GetTextFromData(TileColor.Green, greenTileData));
        eyeIndexTMP.SetText(MyUtils.ConvertToRoman(tdEye.index + 1));
        answerTMP.SetText(answer);

        UpdateEyeImage();
    }

    public void UpdateEyeImage()
    {
        eyeImg.sprite = tdEye.guessedID == ToD.Null ? defaultSprite : tdEye.guessedID == ToD.Truth ? angelSprite : devilSprite;
    }

    public void UpdateByDropdown(int value)
    {
        if (!isEmptyCategory)
        {
            switch (value)
            {
                case 0: 
                    gameObject.SetActive(true);
                    // category.SetActive(false);
                    break;
                case 1:
                    gameObject.SetActive(true);
                    // category.SetActive(true);
                    // categoryBox.enabled = false;
                    // categoryText.enabled = false;
                    break;
                case 2:
                    if (blueTileData[0] == (int)BlueData.Color)
                    {
                        gameObject.SetActive(true);
                        // category.SetActive(true);
                        // categoryBox.enabled = false;
                        // categoryText.enabled = false;
                    }
                    else gameObject.SetActive(false);
                    break;

                case 3: 
                    if (blueTileData[0] == (int)BlueData.Eye)
                    {
                        gameObject.SetActive(true);
                        // category.SetActive(true);
                        // categoryBox.enabled = false;
                        // categoryText.enabled = false;
                    }
                    else gameObject.SetActive(false);
                    break;
            }
        }

        else
        {
            switch (value)
            {
                case 0: 
                    gameObject.SetActive(false); 
                    break;

                case 1: 
                    if (blueTileData[0] == (int)BlueData.Null)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(log => !log.isEmptyCategory && log.tdEye.index < tdEye.index);
                        if (answerLog != null) gameObject.SetActive(true);
                        else gameObject.SetActive(false);
                    }
                    else gameObject.SetActive(false);
                    break;
                    
                case 2: 
                    if (blueTileData[0] == (int)BlueData.Color)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(
                            log => !log.isEmptyCategory && log.blueTileData[0] == (int)BlueData.Color && log.blueTileData[1] < blueTileData[1]);
                        if (answerLog != null) gameObject.SetActive(true);
                        else gameObject.SetActive(false);
                    }
                    else gameObject.SetActive(false);
                    break;

                case 3: 
                    if (blueTileData[0] == (int)BlueData.Eye)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(
                            log => !log.isEmptyCategory && log.blueTileData[0] == (int) BlueData.Eye && log.blueTileData[1] < blueTileData[1]);
                        if (answerLog != null) gameObject.SetActive(true);
                        else gameObject.SetActive(false);
                    }
                    else gameObject.SetActive(false);
                    break;

            }
        }
    }

    public void SetAsEmptyCategory()
    {
        isEmptyCategory = true;

        // categoryBox.enabled = true;
        // switch ((BlueData)blueTileData[0])
        // {
        //     case BlueData.Null: 
        //         // categoryText.SetText(MyUtils.ConvertToRoman(tdEye.index + 1)); 
        //         break;

        //     case BlueData.Color:
        //         // categoryText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueTileData));
        //         // categoryText.color = MyUtils.GetColorFromTileColor((TileColor)blueTileData[1]);
        //         break;

        //     case BlueData.Eye:
        //         // categoryText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueTileData));
        //         break;
        // }

        layoutElement.preferredHeight = 20;

        ring.SetActive(false);
        background.SetActive(false);
        line.SetActive(true);

        redDataTMP.enabled = false;
        blueDataTMP.enabled = false;
        greenDataTMP.enabled = false;
        eyeImg.enabled = false;
        eyeIndexTMP.enabled = false;
        answerTMP.enabled = false;
    }
}
