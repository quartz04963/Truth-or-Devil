using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guidebook : MonoBehaviour
{
    public static Guidebook instance;
    
    [SerializeField] private bool isGuidebookOpened;
    public bool IsGuidebookOpened => isGuidebookOpened;
    [SerializeField] GameObject guidebook;
    [SerializeField] Image contentImg;
    [SerializeField] List<Button> catergoryButtons;

    [Header("설명 이미지")]
    [SerializeField] Sprite[] basicSprites; //기본 규칙
    [SerializeField] Sprite[] moveSprites; //이동 방식
    [SerializeField] Sprite[] questionSprites; //질문 구성
    [SerializeField] Sprite[] resultSprites; //결과 판정
    [SerializeField] Sprite[] functionSprites; //편의 기능

    public enum GuideCategory
    {
        Basic, Move, Question, Result, Function
    }

    private GuideCategory category;
    private Sprite[] spritesToDisplay;
    
    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        UpdateSpritesToDisplay();
    }

    public void UpdateSpritesToDisplay()
    {
        spritesToDisplay = new Sprite[]
        {
            basicSprites[0], moveSprites[0], questionSprites[0], resultSprites[0], functionSprites[0],
        };

        if (GameManager.instance.maxStage >= 5) spritesToDisplay[(int)GuideCategory.Function] = functionSprites[1];
        if (GameManager.instance.maxStage >= 8) spritesToDisplay[(int)GuideCategory.Question] = questionSprites[1];
        if (GameManager.instance.maxStage >= TDStage.Ch1StageCount + 1) spritesToDisplay[(int)GuideCategory.Move] = moveSprites[1];
    }

    public void OnGuideCategoryClicked(int num)
    {
        contentImg.sprite = spritesToDisplay[num];

        for (int i = 0; i < catergoryButtons.Count; i++)
        {
            if (i != num) catergoryButtons[i].image.color = new Color(0.7f, 0.7f, 0.7f);
            else catergoryButtons[i].image.color = Color.white;
        }
    }

    public void OnGuidebookClicked(bool isOpening)
    {
        isGuidebookOpened = isOpening;
        guidebook.SetActive(isOpening);

        if (!GamePlay.instance.isOver && !GamePlay.instance.isCleared) GamePlay.instance.IsRunning = !isOpening;
    }
}
