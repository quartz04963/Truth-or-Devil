using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public readonly Vector3Int[] neighborsPos = new Vector3Int[]
    {
        new Vector3Int(-1, 1, 0), 
        new Vector3Int(0, 1, 0), 
        new Vector3Int(1, 1, 0), 
        new Vector3Int(-1, 0, 0), 
        new Vector3Int(1, 0, 0), 
        new Vector3Int(-1, -1, 0), 
        new Vector3Int(0, -1, 0), 
        new Vector3Int(1, -1, 0)
    };

    public Tilemap tilemap;
    public Dictionary<Vector3Int, TileObject> mapDict = new Dictionary<Vector3Int, TileObject>();
    public Dictionary<string, TileObject> dummyDict = new Dictionary<string, TileObject>();
    public List<EyeTile> eyes = new List<EyeTile>();
    public List<GateTile> gates = new List<GateTile>();
    public List<TextTile> blueTiles = new List<TextTile>();
    public Answer answer;

    [SerializeField] Tile redTile;
    [SerializeField] Tile blueTile;
    [SerializeField] Tile greenTile;
    [SerializeField] Tile whiteTile;
    [SerializeField] GameObject textTilePrf;
    [SerializeField] GameObject eyeTilePrf;
    [SerializeField] GameObject gateTilePrf;
    [SerializeField] Transform dummyTransform;

    private Stage stage;
    public Stage Stage => stage;

    void Awake()
    {
        InitDummies();
    }

    public void Init(Stage stage)
    {
        SetMap(stage);
        SetAnswer(stage);
        SetGatesColorCount();
    }

    public void InitDummies()
    {
        mapDict.Clear();

        TileObject dummyExit = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyExit.InitAsDummy(TileColor.RED, new List<int>{(int)RedData.EXIT});
        dummyDict["EXIT"] = dummyExit;

        TileObject dummyMap = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyMap.InitAsDummy(TileColor.RED, new List<int>{(int)RedData.MAP});
        dummyDict["MAP"] = dummyMap;

        TileObject dummyExitHidden = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyExitHidden.InitAsDummy(TileColor.BLUE, new List<int>{0, 0}, true);
        dummyDict["EXIT???"] = dummyExitHidden;

        TileObject dummyMapHidden = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyMapHidden.InitAsDummy(TileColor.BLUE, new List<int>{0, 0}, true);
        dummyDict["MAP???"] = dummyMapHidden;

        TileObject dummyPosition = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyPosition.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.POSITION, (int)Position.NULL});
        dummyDict["POSITION"] = dummyPosition;

        TileObject dummyColor = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyColor.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.NULL});
        dummyDict["COLOR"] = dummyColor;

        TileObject dummyRed = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyRed.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.RED});
        dummyDict["RED"] = dummyRed;

        TileObject dummyBlue = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyBlue.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.BLUE});
        dummyDict["BLUE"] = dummyBlue;

        TileObject dummyGreen = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyGreen.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.GREEN});
        dummyDict["GREEN"] = dummyGreen;

        TileObject dummyWhite = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyWhite.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.WHITE});
        dummyDict["WHITE"] = dummyWhite;

        TileObject dummyAngel = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyAngel.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.SPECIES, (int)Species.ANGEL});
        dummyDict["ANGEL"] = dummyAngel;

        TileObject dummyDevil = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyDevil.InitAsDummy(TileColor.BLUE, new List<int>{(int)BlueData.SPECIES, (int)Species.DEVIL});
        dummyDict["DEVIL"] = dummyDevil;

        TileObject dummyRedTileObj = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyRedTileObj.InitAsDummy(TileColor.RED, new List<int>{0});
        dummyDict["dummyRedTileObj"] = dummyRedTileObj;

        TileObject dummyGreenTileObj = Instantiate(textTilePrf, dummyTransform).GetComponent<TextTile>();
        dummyGreenTileObj.InitAsDummy(TileColor.GREEN, new List<int>{0, 0});
        dummyDict["dummyGreenTileObj"] = dummyGreenTileObj;

        EyeTile dummyEyeTile = Instantiate(eyeTilePrf, dummyTransform).GetComponent<EyeTile>();
        dummyEyeTile.InitAsDummy(TileColor.WHITE, new List<int>{0, 0});
        dummyDict["dummyEyeTile"] = dummyEyeTile;

        foreach (TileObject tileObject in dummyDict.Values)
        {
            tileObject.gameObject.SetActive(false);
        }
    }

    public void SetMap(Stage stage)
    {
        this.stage = stage;

        int eyeCount = 1, gateCount = 1;

        mapDict.Clear();
        eyes.Clear();
        gates.Clear();

        foreach (TileData tileData in stage.tiles)
        {
            switch (tileData.color)
            {
                case TileColor.RED: tilemap.SetTile(tileData.pos, redTile); break;
                case TileColor.BLUE: tilemap.SetTile(tileData.pos, blueTile); break; 
                case TileColor.GREEN: tilemap.SetTile(tileData.pos, greenTile); break; 
                case TileColor.WHITE: tilemap.SetTile(tileData.pos, whiteTile); break; 
            }

            if (Utils.GetText(tileData) != null)
            {
                GameObject text = Instantiate(textTilePrf, transform);

                if (text.TryGetComponent(out TextTile textTile))
                {
                    textTile.Init(tileData.pos, tileData.color, tileData.data, tileData.isHiding, tileData.isPlaceable, tileData.isThorn);

                    mapDict.Add(tileData.pos, textTile);
                    if (tileData.color == TileColor.BLUE) blueTiles.Add(textTile);
                }
            }
            else
            {
                if (tileData.data[0] == (int)WhiteData.EYE)
                {
                    GameObject eye = Instantiate(eyeTilePrf, transform);

                    if (eye.TryGetComponent(out EyeTile eyeTile)) 
                    {
                        eyeTile.Init(tileData.pos, tileData.color, tileData.data, tileData.isHiding, tileData.isPlaceable, tileData.isThorn);
                        eyeTile.SetCode(eyeCount++);

                        mapDict.Add(tileData.pos, eyeTile);
                        eyes.Add(eyeTile);
                    }
                }
                else if (tileData.data[0] == (int)WhiteData.GATE)
                {
                    GameObject gate = Instantiate(gateTilePrf, transform);

                    if (gate.TryGetComponent(out GateTile gateTile))
                    {
                        gateTile.Init(tileData.pos, tileData.color, tileData.data, tileData.isHiding, tileData.isPlaceable, tileData.isThorn);
                        gateTile.SetCode(gateCount++);

                        mapDict.Add(tileData.pos, gateTile);
                        gates.Add(gateTile);
                    } 
                }
            }
        }
    }

    public void SetAnswer(Stage stage)
    {
        answer = default;

        GateTile exitTile = gates.Find(gate => gate.IsExit);

        foreach (Vector3Int delta in neighborsPos)
        {
            if (mapDict.TryGetValue(exitTile.Pos + delta, out TileObject neighbor) && !neighbor.IsPlaceable)
            {
                switch (neighbor.Color)
                {
                    case TileColor.RED: answer.exitRedCount++; break;
                    case TileColor.BLUE: answer.exitBlueCount++; break;
                    case TileColor.GREEN: answer.exitGreenCount++; break;
                    case TileColor.WHITE: answer.exitWhiteCount++; break;
                }
            } 
        }

        answer.exitRow = stage.range.top - exitTile.Pos.y + 1;
        answer.exitCol = exitTile.Pos.x - stage.range.left + 1;

        foreach (EyeTile eye in eyes)
        {
            if (eye.TureSpecies == Species.ANGEL) answer.mapAngelCount++;
            else answer.mapDevilCount++;
        }
    }

    public void SetGatesColorCount()
    {
        foreach (GateTile gate in gates)
        {
            gate.SetColorCount(this);
        }
    }
}
