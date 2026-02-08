using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxStage;
    [SerializeField] private int currentStage;
    public int CurrentStage
    {
        get => currentStage;
        set
        {
            currentStage = value;
            if (currentStage >= 8) ruleNumber = Mathf.Max(ruleNumber, 2);
        }
    }

    public int titleTabNumber;
    public int ruleNumber;
    
    [Header("옵션 관련")]
    public bool doCheckBeforeEnteringGate = true;

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        MyUtils.LoadAllDialogs();
    }
}
