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
        if (stage <= StageData.Ch1StageCount) 
        {
            numberTMP.SetText(ZString.Concat(stage));
        }
        else if (StageData.Ch1StageCount < stage && stage <= StageData.Ch1StageCount + StageData.Ch2StageCount)
        {
            numberTMP.SetText(ZString.Concat(stage - StageData.Ch1StageCount));
        }
        else 
        {
            numberTMP.SetText(ZString.Concat(stage - StageData.Ch1StageCount - StageData.Ch2StageCount));
        }

        lockImage.SetActive(GameManager.Instance.maxStage < stage);
        numberTMP.gameObject.SetActive(GameManager.Instance.maxStage >= stage);
    }

    public void OnClicked()
    {
        if (GameManager.Instance.maxStage < stage) return;
        
        GameManager.Instance.CurrentStage = stage;
        SoundManager.Instance.StopBgm();
        SceneManager.LoadScene("GamePlay");
    }
}
