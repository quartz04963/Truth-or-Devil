using UnityEngine;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public int stage;
    public GameObject lockImage;

    void Start()
    {
        if (GameManager.instance.maxStage >= stage) lockImage.SetActive(false);
        else lockImage.SetActive(true);
    }

    public void OnClicked()
    {
        if (GameManager.instance.maxStage < stage) return;
        
        GameManager.instance.currentStage = stage;
        SceneManager.LoadScene("GamePlay");
    }
}
