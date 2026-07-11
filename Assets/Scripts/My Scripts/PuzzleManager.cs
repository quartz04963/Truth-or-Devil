using Cysharp.Text;
using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    [SerializeField] int chapter;
    [SerializeField] int stage;
    
    [SerializeField] Map map;
    [SerializeField] Player player;
    [SerializeField] Question question;
    [SerializeField] TextMeshProUGUI stageNumberText;
    
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Stage currentStage = StageData.stages[chapter][stage - 1];

        map.SetMap(currentStage);
        player.Init(currentStage.startPos);

        stageNumberText.SetText(ZString.Concat(chapter, "-", stage));

        CameraManager.instance.SetCenter(currentStage);
    }

    void Update()
    {
        if (!player.HandleMove(map)) return;

        TileObject currentTile = map.mapDict[player.Pos];

        if (currentTile is EyeTile eyeTile)
        {
            if (!question.IsComplete || !question.IsValid) return;

            // TODO: 눈알 답변하기

            question.ClearQuestion();
        }
        else
        {
            question.UpdateQuestion(currentTile);
        }
    }
}
