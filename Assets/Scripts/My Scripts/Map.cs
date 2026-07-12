using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tilemap;
    public Dictionary<Vector3Int, TileObject> mapDict = new Dictionary<Vector3Int, TileObject>();
    public List<EyeTile> eyes = new List<EyeTile>();
    public List<GateTile> gates = new List<GateTile>();
    public Answer answer;

    [SerializeField] Tile redTile;
    [SerializeField] Tile blueTile;
    [SerializeField] Tile greenTile;
    [SerializeField] Tile whiteTile;
    [SerializeField] GameObject textTilePrf;
    [SerializeField] GameObject eyeTilePrf;
    [SerializeField] GameObject gateTilePrf;

    private readonly Vector3Int[] neighborsPos = new Vector3Int[]
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

    public void Init(Stage stage)
    {
        SetMap(stage);
        SetAnswer(stage);
    }

    public void SetMap(Stage stage)
    {
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
            if (mapDict.TryGetValue(exitTile.Pos + delta, out TileObject neighbor))
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
}
