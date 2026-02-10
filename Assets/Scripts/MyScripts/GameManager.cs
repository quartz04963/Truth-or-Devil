using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxStage;
    [SerializeField] private int currentStage;
    public int CurrentStage { get => currentStage; set => currentStage = value; }
    public int titleTabNumber;
    
    [Header("옵션 관련")]
    public bool doCheckBeforeEnteringGate = true;

    void Awake()
    {
        if (instance == null) {
            instance = this;
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
