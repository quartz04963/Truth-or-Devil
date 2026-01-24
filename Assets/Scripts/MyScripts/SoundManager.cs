using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioClip bgmClip;

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

    public void PlayTitleBGM()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void StopBgm() => bgmSource.Stop();
    public void SetBgmVolume(float volume) => bgmSource.volume = volume;
    public float GetBgmVolume() => bgmSource.volume;
}
