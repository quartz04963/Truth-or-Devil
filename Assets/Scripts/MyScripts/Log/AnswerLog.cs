using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Text;

public class AnswerLog : MonoBehaviour
{
    public bool isEmptyCategory;
    public TDEye tdEye;
    public List<int> redTileData, blueTileData, greenTileData;
    public GameObject category;
    public Image categoryBox, redDataBox, blueDataBox, greenDataBox, eyeDataBox, answerDataBox;
    public Image eyeDataImage;
    public Sprite defaultSprite, angelSprite, devilSprite;

    public TextMeshProUGUI categoryText, redDataText, blueDataText, greenDataText, eyeDataText, answerDataText;
    

    public void Init(List<int> _redTileData, List<int> _blueTileData, List<int> _greenTileData, TDEye _tdEye, string answer = "")
    {
        redTileData = _redTileData;
        blueTileData = _blueTileData;
        greenTileData = _greenTileData;
        tdEye = _tdEye;

        redDataText.SetText(MyUtils.GetTextFromData(TileColor.Red, redTileData));
        blueDataText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueTileData));
        greenDataText.SetText(MyUtils.GetTextFromData(TileColor.Green, greenTileData));
        eyeDataText.SetText(MyUtils.ConvertToRoman(tdEye.index + 1));
        answerDataText.SetText(answer);

        UpdateEyeImage();
    }

    public void UpdateEyeImage()
    {
        eyeDataImage.sprite = defaultSprite;
        //eyeDataImage.sprite = tdEye.guessedID == ToD.Null ? defaultSprite : tdEye.guessedID == ToD.Truth ? angelSprite : devilSprite;
    }

    public void UpdateByDropdown(int value)
    {
        if (!isEmptyCategory)
        {
            switch (value)
            {
                case 0: 
                    gameObject.SetActive(true);
                    category.SetActive(false);
                    break;
                case 1:
                    gameObject.SetActive(true);
                    category.SetActive(true);
                    categoryBox.enabled = false;
                    categoryText.enabled = false;
                    break;
                case 2:
                    if (blueTileData[0] == (int)BlueData.Color)
                    {
                        gameObject.SetActive(true);
                        category.SetActive(true);
                        categoryBox.enabled = false;
                        categoryText.enabled = false;
                    }
                    else gameObject.SetActive(false);
                    break;

                case 3: 
                    if (blueTileData[0] == (int)BlueData.Eye)
                    {
                        gameObject.SetActive(true);
                        category.SetActive(true);
                        categoryBox.enabled = false;
                        categoryText.enabled = false;
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
                        AnswerLog answerLog = LogManager.instance.logList.Find(log => !log.isEmptyCategory && log.tdEye.index == tdEye.index);
                        if (answerLog == null) gameObject.SetActive(true);
                        else gameObject.SetActive(false);
                    }
                    else gameObject.SetActive(false);
                    break;
                    
                case 2: 
                    if (blueTileData[0] == (int)BlueData.Color)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(
                            log => !log.isEmptyCategory && log.blueTileData[0] == (int)BlueData.Color && log.blueTileData[1] == blueTileData[1]);
                        if (answerLog == null) gameObject.SetActive(true);
                        else gameObject.SetActive(false);
                    }
                    else gameObject.SetActive(false);
                    break;

                case 3: 
                    if (blueTileData[0] == (int)BlueData.Eye)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(
                            log => !log.isEmptyCategory && log.blueTileData[0] == (int) BlueData.Eye && log.blueTileData[1] == blueTileData[1]);
                        if (answerLog == null) gameObject.SetActive(true);
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

        categoryBox.enabled = true;
        switch ((BlueData)blueTileData[0])
        {
            case BlueData.Null: 
                categoryText.SetText(MyUtils.ConvertToRoman(tdEye.index + 1)); 
                break;

            case BlueData.Color:
                categoryText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueTileData));
                categoryText.color = MyUtils.GetColorFromTileColor((TileColor)blueTileData[1]);
                break;

            case BlueData.Eye:
                categoryText.SetText(MyUtils.GetTextFromData(TileColor.Blue, blueTileData));
                break;
        }

        redDataBox.enabled = false;
        redDataText.enabled = false;
        blueDataBox.enabled = false;
        blueDataText.enabled = false;
        greenDataBox.enabled = false;
        greenDataText.enabled = false;
        eyeDataBox.enabled = false;
        eyeDataImage.enabled = false;
        eyeDataText.enabled = false;
        answerDataBox.enabled = false;
        answerDataText.enabled = false;
    }
}
