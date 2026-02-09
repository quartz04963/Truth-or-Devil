using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    [SerializeField] int stage;
    [SerializeField] GameObject lockImage;
    [SerializeField] TextMeshProUGUI numberTMP;

    void Start()
    {
        if (stage <= 13) numberTMP.SetText(ZString.Concat(stage));
        else if (14 <= stage && stage <= 28) numberTMP.SetText(ZString.Concat(stage - 13));
        else numberTMP.SetText(ZString.Concat(stage - 28));

        if (GameManager.instance.maxStage >= stage) {
            lockImage.SetActive(false);
            numberTMP.gameObject.SetActive(true);
        }
        else 
        {
            lockImage.SetActive(true);
            numberTMP.gameObject.SetActive(false);
        }
    }

    public void OnClicked()
    {
        if (GameManager.instance.maxStage < stage) return;
        
        GameManager.instance.CurrentStage = stage;
        SceneManager.LoadScene("GamePlay");
        SoundManager.Instance.StopBgm();
    }
}
