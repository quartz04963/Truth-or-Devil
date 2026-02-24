using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    [SerializeField] Sprite[] makeQuestionSprites; //질문 구성
    [SerializeField] Sprite[] askQuestionSprites; //질문 실행
    [SerializeField] Sprite[] resultSprites; //결과 판정
    [SerializeField] Sprite[] functionSprites; //편의 기능

    public enum GuideCategory
    {
        Basic, Move, MakeQuestion, AskQuestion, Result, Function
    }

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
            basicSprites[0], moveSprites[0], makeQuestionSprites[0], askQuestionSprites[0], resultSprites[0], functionSprites[0],
        };

        if (GameManager.instance.maxStage >= 5) spritesToDisplay[(int)GuideCategory.Function] = functionSprites[1];
        if (GameManager.instance.maxStage >= 8) spritesToDisplay[(int)GuideCategory.MakeQuestion] = makeQuestionSprites[1];
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
        EventSystem.current.SetSelectedGameObject(null);

        isGuidebookOpened = isOpening;
        guidebook.SetActive(isOpening);

        if (!GamePlay.instance.isOver && !GamePlay.instance.isCleared && !DialogManager.instance.isTalking) GamePlay.instance.IsRunning = !isOpening;
    }
}
