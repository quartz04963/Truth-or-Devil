using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using PrimeTween;
using Cysharp.Text;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public bool isTalking; //대화 중 여부
    public bool isSkipping; //대사 출력 중 스킵 여부
    public bool isEpilogShowed;
    public bool isClicked;
    public float interval;
    public int currentLineNumber;
    public TDDialog currentDialog;
    public Coroutine saying;

    public GameObject dialog;
    public GameObject skipButton;
    public Image background;
    public Image videl;
    public Image nagel;
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI dialogTMP;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        if (currentDialog == null || !isTalking) return;

        if (!OptionManager.instance.IsOptionOpened && Input.GetKeyDown(KeyCode.Return)) OnClicked();
    }

    public void StartDialog(TDDialog _currentDialog)
    {
        currentDialog = _currentDialog;
        if (currentDialog == null) return;

        isTalking = true;
        GamePlay.instance.isRunning = false;
        dialog.SetActive(true);
        SetCharacter();
        Fade(1f, 0f);

        currentLineNumber = 0;
        saying = StartCoroutine(SayLine(currentDialog.lineList[currentLineNumber]));
    }

    public void ContinueDialog()
    {
        isTalking = true;
        GamePlay.instance.isRunning = false;
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
        GamePlay.instance.isRunning = true;
        dialog.SetActive(false);
        
        if (GamePlay.instance.isCleared) 
        {
            TDDialog dialog = TDStory.dialogList.Find(dialog => dialog.stage == GameManager.instance.CurrentStage && dialog.isProlog == false);
            if (dialog != null && !isEpilogShowed)
            {
                isEpilogShowed = true;
                StartDialog(dialog);
            }
            else GamePlay.instance.StageClear();
        }
        else if (GamePlay.instance.isOver) GamePlay.instance.GameOver();
    }

    void SetCharacter()
    {
        if (currentDialog.stage == 1 && currentDialog.isProlog) nagel.enabled = false;
        else if (currentDialog.stage == 2 && !currentDialog.isProlog) videl.enabled = false;
        else if (currentDialog.stage == 12 && currentDialog.isProlog) videl.enabled = false;
        else videl.enabled = nagel.enabled = true;
    }

    public IEnumerator SayLine(TDLine tdLine)
    {
        yield return Tutorial.instance.DoBeforeSayLine();

        isSkipping = false;
        WaitForSeconds wait = new WaitForSeconds(interval);

        Color videlColor = videl.color, nagelColor = nagel.color;
        switch (tdLine.name)
        {
            case "비델": videlColor.a = 1f; nagelColor.a = 0.7f; break;
            case "나겔": videlColor.a = 0.7f; nagelColor.a = 1f; break;
            default: videlColor.a = nagelColor.a = 0.7f; break;
        }
        videl.color = videlColor;
        nagel.color = nagelColor;

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
}
