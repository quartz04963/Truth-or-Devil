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
        if (stage <= 12) numberTMP.SetText(ZString.Concat(stage));
        else if (16 <= stage && stage <= 30) numberTMP.SetText(ZString.Concat(stage - 15));
        else numberTMP.SetText(ZString.Concat(stage - 30));

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
