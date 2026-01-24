using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public static OptionManager instance;

    public GameObject option;
    public Toggle checkEntering;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        checkEntering.SetIsOnWithoutNotify(GameManager.instance.doCheckBeforeEnteringGate);
    }

    public void OnOptionButtonClicked(bool isOpening)
    {
        option.SetActive(isOpening);
        if (GamePlay.instance != null) GamePlay.instance.isRunning = !isOpening;
    }

    public void OnCheckEnteringChanged(bool isOn) => GameManager.instance.doCheckBeforeEnteringGate = isOn;
}
