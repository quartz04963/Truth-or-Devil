using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] GameObject popups;
    [SerializeField] GameObject exitPopup;
    [SerializeField] GameObject failPopup;
    [SerializeField] GameObject successPopup;
    [SerializeField] GameObject nextButton;

    [SerializeField] TextMeshProUGUI stageNumberTmp;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        int chapter = TransitionManager.instance.CurrentChapter;
        int stage = TransitionManager.instance.CurrentStage;

        if (chapter == StageData.stages.Length - 1 && stage == StageData.stages[chapter].Count)
        {
            nextButton.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PuzzleManager.instance.IsPaused)
            {
                EnableExitPopup();  
            }
            else if (failPopup.activeSelf || successPopup.activeSelf)
            {
                Exit();
            }
            else
            {
                Close(); 
            }
        }

        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!PuzzleManager.instance.IsPaused) return;
            else if (exitPopup.activeSelf)
            {
                Exit();
            }
            else if (failPopup.activeSelf)
            {
                Retry();
            }
            else if (successPopup.activeSelf)
            {
                Next();
            }
        }
    }

    public void SetStageNumberText(int chapter, int stage)
    {
        stageNumberTmp.SetText(ZString.Concat(chapter, "-", stage));
    }
    
    public void EnableExitPopup()
    {
        EventSystem.current.SetSelectedGameObject(null);

        Close();

        popups.SetActive(true);
        exitPopup.SetActive(true);

        PuzzleManager.instance.IsPaused = true;
    }

    public void EnableFailPopup()
    {
        EventSystem.current.SetSelectedGameObject(null);

        Close();

        popups.SetActive(true);
        failPopup.SetActive(true);

        PuzzleManager.instance.IsPaused = true;
    }

    public void EnableSuccessPopup()
    {
        EventSystem.current.SetSelectedGameObject(null);

        Close();

        popups.SetActive(true);
        successPopup.SetActive(true);

        PuzzleManager.instance.IsPaused = true;
    }

    #region 버튼 클릭
    public void Close()
    {
        popups.SetActive(false);
        exitPopup.SetActive(false);
        failPopup.SetActive(false);
        successPopup.SetActive(false);

        PuzzleManager.instance.IsPaused = false;
    }

    public void Exit()
    {
        TransitionManager.instance.Transit("Stages");
    }

    public void Retry()
    {
        TransitionManager.instance.Transit("Puzzle");
    }

    public void Next()
    {
        int chapter = TransitionManager.instance.CurrentChapter;
        int stage = TransitionManager.instance.CurrentStage;

        if (stage < StageData.stages[chapter].Count)
        {
            stage++;
        }
        else if (chapter < StageData.stages.Length - 1)
        {
            chapter++;
            stage = 1;
        }
        
        TransitionManager.instance.SetCurrentChapterAndStage(chapter, stage);
        TransitionManager.instance.Transit("Puzzle");
    }

    #endregion
}
