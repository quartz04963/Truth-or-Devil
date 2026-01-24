using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public static OptionManager instance;

    public GameObject option;
    public Toggle checkEntering;
    public Slider bgmVolume;
    public TextMeshProUGUI ruleTMP;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        checkEntering.SetIsOnWithoutNotify(GameManager.instance.doCheckBeforeEnteringGate);
        bgmVolume.SetValueWithoutNotify(SoundManager.Instance.GetBgmVolume());
        if (GameManager.instance.ruleNumber == 1) {
            ruleTMP.SetText("[규칙 요약]\n- 질문 상자의 내용은 덮어 씌워집니다.\n- GATE + 색깔 + 숫자 = 천국 문 1칸 주변에 특정 색의 칸이 특정 개수만큼 있는가?");
        }
    }

    public void OnOptionButtonClicked(bool isOpening)
    {
        option.SetActive(isOpening);
        if (GamePlay.instance != null && !GamePlay.instance.isOver && !GamePlay.instance.isCleared) GamePlay.instance.isRunning = !isOpening;
    }

    public void OnCheckEnteringChanged(bool isOn) => GameManager.instance.doCheckBeforeEnteringGate = isOn;
    public void OnBgmVolumeChanged(float volume) => SoundManager.Instance.SetBgmVolume(volume);
}
