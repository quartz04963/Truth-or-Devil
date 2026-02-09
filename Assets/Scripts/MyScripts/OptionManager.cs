using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public static OptionManager instance;

    [SerializeField] private bool isOptionOpened;
    public bool IsOptionOpened => isOptionOpened;

    public GameObject option;
    public Toggle checkEntering;
    public Slider bgmVolume;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        checkEntering.SetIsOnWithoutNotify(GameManager.instance.doCheckBeforeEnteringGate);
        bgmVolume.SetValueWithoutNotify(SoundManager.Instance.GetBgmVolume());
    }

    public void OnOptionClicked(bool isOpening)
    {
        isOptionOpened = isOpening;
        option.SetActive(isOpening);

        if (GamePlay.instance != null && !GamePlay.instance.isOver && !GamePlay.instance.isCleared) GamePlay.instance.IsRunning = !isOpening;
    }

    public void OnCheckEnteringChanged(bool isOn) => GameManager.instance.doCheckBeforeEnteringGate = isOn;
    public void OnBgmVolumeChanged(float volume) => SoundManager.Instance.SetBgmVolume(volume);
}
