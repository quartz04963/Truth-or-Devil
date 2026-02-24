using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isOptionOpened) OnOptionClicked(false);
    }

    public void OnOptionClicked(bool isOpening)
    {
        EventSystem.current.SetSelectedGameObject(null);
        
        isOptionOpened = isOpening;
        option.SetActive(isOpening);

        checkEntering.SetIsOnWithoutNotify(GameManager.instance.doCheckBeforeEnteringGate);
        bgmVolume.SetValueWithoutNotify(SoundManager.Instance.GetBgmVolume());

        if (GamePlay.instance != null && !GamePlay.instance.isOver && !GamePlay.instance.isCleared && !DialogManager.instance.isTalking) GamePlay.instance.IsRunning = !isOpening;
    }

    public void OnCheckEnteringChanged(bool isOn) => GameManager.instance.doCheckBeforeEnteringGate = isOn;
    public void OnBgmVolumeChanged(float volume) => SoundManager.Instance.SetBgmVolume(volume);
}
