using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    [SerializeField] int chapter;
    [SerializeField] int stage;
    [SerializeField] bool isPaused;
    
    [SerializeField] Map map;
    [SerializeField] Player player;
    [SerializeField] Question question;
    [SerializeField] Log log;

    public bool IsPaused
    {
        get => isPaused;
        set => isPaused = value;
    }
    public int Chapter => chapter;
    public Player Player => player;
    public Log Log => log;
    
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Stage currentStage = StageData.stages[chapter][stage - 1];

        map.Init(currentStage);
        player.Init(currentStage.startPos);
        log.Init(map);

        CameraManager.instance.SetCenter(currentStage);
        UIManager.instance.SetStageNumberText(chapter, stage);
    }

    void Update()
    {
        if (isPaused) return;

        if (!player.HandleMove(map)) return;

        TileObject currentTileObj = map.mapDict[player.Pos];

        if (currentTileObj is EyeTile eyeTile)
        {
            if (!question.IsComplete || !question.IsValid) return;
            
            string answerText = question.getAnswer(eyeTile, map.answer);
            eyeTile.Answer(answerText);

            log.AddItem(eyeTile, question, answerText);
            question.ClearQuestion();
        }
        else
        {
            question.UpdateQuestion(currentTileObj);
        }
    }

    public void CheckResult(GateTile gate)
    {
        if (gate.IsExit && !map.eyes.Exists(eye => eye.MarkedSpecies != eye.TureSpecies))
        {
            UIManager.instance.EnableSuccessPopup();
        } 
        else
        {
            UIManager.instance.EnableFailPopup();
        }
    }
}
