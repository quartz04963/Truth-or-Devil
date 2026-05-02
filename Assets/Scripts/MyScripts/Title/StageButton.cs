using TMPro;
using Cysharp.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    [SerializeField] int stage;

    [SerializeField] GameObject lockImage;
    [SerializeField] TextMeshProUGUI numberTMP;

    void Start()
    {
        if (stage <= StageDataList.Chapter1) 
        {
            numberTMP.SetText(ZString.Concat(stage));
        }
        else if (StageDataList.Chapter1 < stage && stage <= StageDataList.Chapter1 + StageDataList.Chapter2)
        {
            numberTMP.SetText(ZString.Concat(stage - StageDataList.Chapter1));
        }
        else 
        {
            numberTMP.SetText(ZString.Concat(stage - StageDataList.Chapter1 - StageDataList.Chapter2));
        }

        lockImage.SetActive(GameManager.Instance.maxStage < stage);
        numberTMP.gameObject.SetActive(GameManager.Instance.maxStage >= stage);
    }

    public void OnClicked()
    {
        if (GameManager.Instance.maxStage < stage) return;
        
        GameManager.Instance.currentStage = stage;
        SoundManager.Instance.StopBgm();
        SceneManager.LoadScene("GamePlay");
    }
}
