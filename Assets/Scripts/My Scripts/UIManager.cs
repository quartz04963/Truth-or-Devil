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

    [SerializeField] TextMeshProUGUI stageNumberTmp;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
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
        // TODO: 스테이지 선택 화면으로 나가기
    }

    public void Retry()
    {
        // TODO: 현재 스테이지 재시작
    }

    public void Next()
    {
        // TODO: 다음 스테이지로
    }

    #endregion
}
