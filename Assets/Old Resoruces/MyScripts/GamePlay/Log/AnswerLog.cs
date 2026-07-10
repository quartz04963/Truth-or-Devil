using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Text;
using System.Linq;

public class AnswerLog : MonoBehaviour
{
    public bool isEmptyCategory;
    public TDEye tdEye;
    public TDTileData redTileData;
    public TDTileData blueTileData;
    public TDTileData greenTileData;

    public GameObject ring;
    public GameObject background;
    public GameObject line;
    public LayoutElement layoutElement;
    public Image eyeImg;
    public Sprite defaultSprite, angelSprite, devilSprite;

    // public TextMeshProUGUI categoryText; 
    public TextMeshProUGUI redDataTMP, blueDataTMP, greenDataTMP, eyeIndexTMP, answerTMP;
    

    public void Init(TDTileData redTileData, TDTileData blueTileData, TDTileData greenTileData, TDEye _tdEye, string answer = "")
    {
        this.redTileData = redTileData;
        this.blueTileData = blueTileData;
        this.greenTileData = greenTileData;
        tdEye = _tdEye;

        redDataTMP.SetText(TDTileData.GetText(redTileData));
        blueDataTMP.SetText(TDTileData.GetText(blueTileData));
        greenDataTMP.SetText(TDTileData.GetText(greenTileData));
        eyeIndexTMP.SetText(MyUtils.ConvertToRoman(tdEye.code + 1));
        answerTMP.SetText(answer);

        UpdateEyeImage();
    }

    public void UpdateEyeImage()
    {
        eyeImg.sprite = tdEye.guessedID == Species.NULL ? defaultSprite : tdEye.guessedID == Species.ANGEL ? angelSprite : devilSprite;
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
                    if (blueTileData.data[0] == (int)BlueData.COLOR)
                    {
                        gameObject.SetActive(true);
                        // category.SetActive(true);
                        // categoryBox.enabled = false;
                        // categoryText.enabled = false;
                    }
                    else gameObject.SetActive(false);
                    break;

                case 3: 
                    if (blueTileData.data[0] == (int)BlueData.SPECIES)
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
                    if (blueTileData.data[0] == (int)BlueData.NULL)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(log => !log.isEmptyCategory && log.tdEye.code < tdEye.code);
                        if (answerLog != null) 
                        {
                            answerLog = LogManager.instance.logList.Find(log => !log.isEmptyCategory && log.tdEye.code == tdEye.code);
                            if (answerLog != null) 
                            {
                                gameObject.SetActive(true);
                                break;
                            }
                        }
                    }

                    gameObject.SetActive(false);
                    break;
                    
                case 2: 
                    if (blueTileData.data[0] == (int)BlueData.COLOR)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(
                            log => !log.isEmptyCategory && log.blueTileData.data[0] == (int)BlueData.COLOR && log.blueTileData.data[1] < blueTileData.data[1]);
                        if (answerLog != null) 
                        {
                            answerLog = LogManager.instance.logList.Find(
                                log => !log.isEmptyCategory && log.blueTileData.data[0] == (int)BlueData.COLOR && log.blueTileData.data[1] == blueTileData.data[1]);
                            if (answerLog != null) 
                            {
                                gameObject.SetActive(true);
                                break;
                            }
                        }
                    }

                    gameObject.SetActive(false);
                    break;

                case 3: 
                    if (blueTileData.data[0] == (int)BlueData.SPECIES)
                    {
                        AnswerLog answerLog = LogManager.instance.logList.Find(
                            log => !log.isEmptyCategory && log.blueTileData.data[0] == (int) BlueData.SPECIES && log.blueTileData.data[1] < blueTileData.data[1]);
                        if (answerLog != null) 
                        {
                            answerLog = LogManager.instance.logList.Find(
                                log => !log.isEmptyCategory && log.blueTileData.data[0] == (int) BlueData.SPECIES && log.blueTileData.data[1] == blueTileData.data[1]);
                            if (answerLog != null)
                            {
                                gameObject.SetActive(true);
                                break;
                            }
                        }
                    }

                    gameObject.SetActive(false);
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
