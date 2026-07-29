using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StagesManager : MonoBehaviour
{
    public static StagesManager instance;

    [SerializeField] bool isPaused;
    [SerializeField] StagesPlayer player;

    [SerializeField] GameObject stagesCamera;
    [SerializeField] GameObject textTilePrf;
    [SerializeField] Transform tiles;
    [SerializeField] Transform gates;

    public Dictionary<Vector3Int, TileObject> mapDict = new Dictionary<Vector3Int, TileObject>();

    public bool IsPaused
    {
        get => isPaused;
        set => isPaused = value;
    }

    public StagesPlayer Player => player;
    public GameObject Camera => stagesCamera;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        InitStagesMap();
        InitPlayer();
    }

    void Update()
    {
        player.HandleMove();
    }

    // 하드코딩
    void InitStagesMap()
    {
        mapDict.Clear();

        List<int> blank = new List<int>{(int)WhiteData.NULL, 0};

        for (int i = -5; i < 41; i++)
        {
            TileObject dummy = Instantiate(textTilePrf, tiles).GetComponent<TileObject>();
            Vector3Int pos = new Vector3Int(i, -2, 0);

            dummy.Init(pos, TileColor.WHITE, blank);
            mapDict.Add(pos, dummy);
        }

        foreach (Transform child in gates)
        {
            if (!child.TryGetComponent(out StageGateTile gate)) continue;
            
            mapDict.Add(gate.Pos, gate);
        }
    }

    void InitPlayer()
    {
        int chapter = TransitionManager.instance.CurrentChapter;
        int stage = TransitionManager.instance.CurrentStage;

        if (chapter == 0 && stage == 0)
        {
            player.Init(new Vector3Int(-5, -2, 0));
        }
        else
        {
            var pos = mapDict.FirstOrDefault(
                pair => pair.Value is StageGateTile gate && chapter == gate.Chapter && stage == gate.Stage
                ).Key;
                
            player.Init(pos + Vector3Int.down);
        }
    }

    public void BackToTitle()
    {
        TransitionManager.instance.SetCurrentChapterAndStage(0, 0);
        TransitionManager.instance.Transit("Title");
    }
}
