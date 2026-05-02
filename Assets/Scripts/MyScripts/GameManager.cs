using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int titleTabNumber;
    public int maxStage;
    public int currentStage;
    
    
    [Header("옵션 관련")]
    public bool doCheckBeforeEnteringGate = true;

    void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        SaveSystem.Load();
        MyUtils.LoadAllDialogs();
    }

    void OnApplicationPause(bool pause)
    {
        if (pause) SaveSystem.Save();
    }

    void OnApplicationFocus(bool focus)
    {
        if (!focus) SaveSystem.Save();
    }

    void OnApplicationQuit() => SaveSystem.Save();
}
