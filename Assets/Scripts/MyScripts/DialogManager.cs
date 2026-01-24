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
    public bool isPrinting; //대사 출력 중 여부
    public bool isEpilogShowed;
    public bool isClicked;
    public float interval;
    public int currentLineNumber;
    public TDDialog currentDialog;
    public Coroutine saying;

    public GameObject dialog;
    public GameObject skipButton;
    public Image background;
    public TextMeshProUGUI nameTMP;
    public TextMeshProUGUI dialogTMP;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        if (currentDialog == null || !isTalking) return;

        if (Input.GetKeyDown(KeyCode.Return)) OnClicked();
    }

    public void StartDialog(TDDialog _currentDialog)
    {
        currentDialog = _currentDialog;
        if (currentDialog == null) return;

        isTalking = true;
        GamePlay.instance.isRunning = false;
        dialog.SetActive(true);
        Fade(1f, 0f);

        currentLineNumber = 0;
        saying = StartCoroutine(SayLine(currentDialog.lineList[currentLineNumber]));
    }

    public void ContinueDialog()
    {
        isTalking = true;
        GamePlay.instance.isRunning = false;
        dialog.SetActive(true);

        interval = 0.05f;
        currentLineNumber++;
        saying = StartCoroutine(SayLine(currentDialog.lineList[currentLineNumber]));
    }

    public void ExitDialog()
    {
        StopCoroutine(saying);

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

    public IEnumerator SayLine(TDLine tdLine)
    {
        isPrinting = true;
        yield return Tutorial.instance.DoBeforeSayLine();

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
            yield return new WaitForSeconds(interval);
        }
        
        isPrinting = false;
    }

    public void Fade(float endValue, float duration) => Tween.Alpha(background, endValue, duration);

    public void OnClicked() 
    {
        if (isPrinting)
        {
            interval = 0f;
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
