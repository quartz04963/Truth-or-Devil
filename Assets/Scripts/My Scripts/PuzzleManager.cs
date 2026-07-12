using Cysharp.Text;
using TMPro;
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
    [SerializeField] TextMeshProUGUI stageNumberTmp;

    public bool IsPaused => isPaused;
    
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

        stageNumberTmp.SetText(ZString.Concat(chapter, "-", stage));

        CameraManager.instance.SetCenter(currentStage);
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
}
