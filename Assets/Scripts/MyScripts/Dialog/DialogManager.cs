using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using PrimeTween;
using Cysharp.Text;

public readonly struct TDLine
{
    public readonly string name;
    public readonly string text;

    public TDLine(string _name, string _text)
    {
        name = _name;
        text = _text;
    }
}

public readonly struct TDDialog
{
    public readonly int stage;
    public readonly bool isProlog;
    public readonly List<TDLine> lineList;

    public TDDialog(int _stage, bool _isProlog, List<TDLine> _lineList)
    {
        stage = _stage;
        isProlog = _isProlog;
        lineList = _lineList;
    }
}

public static class TDStory
{
    public static TDDialog videlPressure = new TDDialog(0, false, new List<TDLine>
    {
        new TDLine("비델", "..."),
    });

    public static TDDialog gameOverLineList = new TDDialog(0, false, new List<TDLine>
    {
        new TDLine("비델", "자, 참가자 님의 결과는...!"),
        new TDLine("비델", "아쉽게도 실패입니다! 안녕히 계세요!"),
    });

    public static TDDialog stageClearLineList = new TDDialog(0, false, new List<TDLine>
    {
        new TDLine("비델", "자, 참가자 님의 결과는...!"),
        new TDLine("비델", "성공입니다! 축하드립니다!"),
    });

    public static List<TDDialog> dialogList = new List<TDDialog>();
}

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public bool isTalking; //대화 중 여부
    public bool isSkipping; //대사 출력 중 스킵 여부
    public bool isEpilogShowed;
    public bool isClicked;
    public float interval;
    public int currentLineNumber;
    private TDDialog currentDialog;
    private Coroutine saying;

    [SerializeField] GameObject dialog;
    [SerializeField] GameObject skipButton;
    public void SetSkipButtonActive(bool isActive) => skipButton.SetActive(isActive);
    [SerializeField] Image background;
    [SerializeField] Image videl;
    [SerializeField] Image nagel;
    [SerializeField] Image picture;
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI dialogTMP;
    [SerializeField] GameObject nameBox;
    [SerializeField] GameObject dialogBox;
    [SerializeField] GameObject reviewButton;
    [SerializeField] GameObject reviewInGamePlayButton;
    public void SetReviewInGamePlayActive(bool isActive) => reviewInGamePlayButton.SetActive(isActive);
    [SerializeField] GameObject pastDialogs;
    [SerializeField] GameObject pastDialogPrf;
    [SerializeField] ScrollRect pastDialogSR;
    [SerializeField] RectTransform pastDialogContent;
    
    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        if (currentDialog.Equals(default(TDDialog)) || !isTalking) return;

        if (!OptionManager.instance.IsOptionOpened && Input.GetKeyDown(KeyCode.Return)) OnClicked();
    }

    public void StartDialog(TDDialog _currentDialog)
    {
        currentDialog = _currentDialog;
        if (currentDialog.Equals(default(TDDialog))) return;

        isTalking = true;
        GamePlay.instance.IsRunning = false;
        dialog.SetActive(true);
        SetCharacter();
        Fade(1f, 0f);

        currentLineNumber = 0;
        saying = StartCoroutine(SayLine(currentDialog.lineList[currentLineNumber]));

        if (_currentDialog.Equals(TDStory.stageClearLineList) || _currentDialog.Equals(TDStory.gameOverLineList))
        {
            skipButton.SetActive(false);
            reviewButton.SetActive(false);
            if (GameManager.instance.CurrentStage == 1) reviewInGamePlayButton.SetActive(false);
        }
        else
        {
            skipButton.SetActive(true);
            reviewButton.SetActive(true);
            foreach (RectTransform rt in pastDialogContent) Destroy(rt.gameObject);
        }
    }

    public void ContinueDialog()
    {
        isTalking = true;
        GamePlay.instance.IsRunning = false;
        dialog.SetActive(true);

        currentLineNumber++;
        saying = StartCoroutine(SayLine(currentDialog.lineList[currentLineNumber]));
    }

    public void ExitDialog()
    {
        if (saying != null) 
        {
            StopCoroutine(saying);
            saying = null;
        }

        isTalking = false;
        GamePlay.instance.IsRunning = true;
        dialog.SetActive(false);

        if (GamePlay.instance.isCleared) 
        {
            TDDialog dialog = TDStory.dialogList.Find(dialog => dialog.stage == GameManager.instance.CurrentStage && dialog.isProlog == false);
            if (!dialog.Equals(default(TDDialog))  && !isEpilogShowed)
            {
                isEpilogShowed = true;
                StartDialog(dialog);
            }
            else GamePlay.instance.StageClear();
        }
        else if (GamePlay.instance.isOver) GamePlay.instance.GameOver();
    }

    public void SetCharacter()
    {
        if (currentDialog.stage == 1 && currentDialog.isProlog) nagel.enabled = currentLineNumber >= 16;
        else if (currentDialog.stage == 2 && !currentDialog.isProlog) videl.enabled = false;
        else if (currentDialog.stage == 12 && currentDialog.isProlog) videl.enabled = false;
        else videl.enabled = nagel.enabled = true;
    }

    public IEnumerator SayLine(TDLine tdLine)
    {
        videl.enabled = nagel.enabled = true;
        nameBox.SetActive(true);
        dialogBox.SetActive(true);
        picture.enabled = false;

        yield return Tutorial.instance.DoBeforeSayLine();

        isSkipping = false;
        WaitForSeconds wait = new WaitForSeconds(interval);

        Color videlColor = videl.color, nagelColor = nagel.color;
        switch (tdLine.name)
        {
            case "비델": videlColor.a = 1f; nagelColor.a = 0.5f; break;
            case "나겔": videlColor.a = 0.5f; nagelColor.a = 1f; break;
            default: videlColor.a = nagelColor.a = 0.5f; break;
        }
        videl.color = videlColor;
        nagel.color = nagelColor;

        PastDialog dialog = Instantiate(pastDialogPrf, pastDialogContent).GetComponent<PastDialog>();
        dialog.Init(tdLine.name, tdLine.text);
        
        nameTMP.SetText(tdLine.name);

        string text = "";
        bool isColorTag = false;
        foreach(char c in tdLine.text)
        {
            text += c;

            if (c == '<') isColorTag = true;
            else if (c == '>') isColorTag = false;
            if (isColorTag) continue;

            dialogTMP.SetText(text);
            
            if (!isSkipping) yield return wait;
        }

        saying = null;
    }

    public void ShowOnlyPicture(Sprite sprite)
    {
        videl.enabled = nagel.enabled = false;

        nameBox.SetActive(false);
        dialogBox.SetActive(false);

        picture.enabled = true;
        picture.sprite = sprite;
    }

    public void Fade(float endValue, float duration) => Tween.Alpha(background, endValue, duration);

    public void OnClicked() 
    {
        if (saying != null)
        {
            isSkipping = true;
        }
        else if (currentLineNumber < currentDialog.lineList.Count - 1)
        {
            if (Tutorial.instance.BreakDialog()) return;
            else ContinueDialog();
        }
        else
        {
            ExitDialog();
        }
    }

    public void OnSkipClicked()
    {
        if (GamePlay.instance.isCleared) isEpilogShowed = true; 
        ExitDialog();
    }

    public void OnReviewClicked(bool isOpening)
    {
        pastDialogs.SetActive(isOpening);
        pastDialogSR.verticalNormalizedPosition = 0;
        if (GamePlay.instance != null && !GamePlay.instance.isOver && !GamePlay.instance.isCleared) GamePlay.instance.IsRunning = !isOpening;
    }
}
