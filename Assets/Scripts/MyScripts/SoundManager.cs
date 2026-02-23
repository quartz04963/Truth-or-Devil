using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioClip titleBGM;
    [SerializeField] AudioClip gameplayBGM;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string bgmClip)
    {
        if (bgmClip == "title") bgmSource.clip = titleBGM;
        else if (bgmClip == "gameplay") bgmSource.clip = gameplayBGM;

        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBgm() => bgmSource.Stop();
    public void SetBgmVolume(float volume) => bgmSource.volume = volume;
    public float GetBgmVolume() => bgmSource.volume;
}
