using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap tilemap;
    public Dictionary<Vector3Int, TileObject> mapDict = new Dictionary<Vector3Int, TileObject>();

    [SerializeField] Tile redTile;
    [SerializeField] Tile blueTile;
    [SerializeField] Tile greenTile;
    [SerializeField] Tile whiteTile;
    [SerializeField] GameObject textTilePrf;
    [SerializeField] GameObject eyeTilePrf;
    [SerializeField] GameObject gateTilePrf;

    void Start()
    {
        SetMap(StageData.stages[0][5]);
    }

    void SetMap(Stage stage)
    {
        int eyeCount = 1, gateCount = 1;

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
                    }
                }
                else if (tileData.data[0] == (int)WhiteData.GATE)
                {
                    GameObject gate = Instantiate(gateTilePrf, transform);

                    if (gate.TryGetComponent(out GateTile gateTile))
                    {
                        gateTile.Init(tileData.pos, tileData.color, tileData.data, tileData.isHiding, tileData.isPlaceable, tileData.isThorn);
                        gateTile.SetCode(gateCount++);
                    } 
                }
            }
        }
    }
}
