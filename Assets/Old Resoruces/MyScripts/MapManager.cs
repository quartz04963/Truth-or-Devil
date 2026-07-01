using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    
    public Tilemap tilemap;

    public StageData currentStageData;

    public List<TDObject> map;
    public List<TDEye> eyes;
    public List<TDGate> gates;
    public List<TDPlaceableObject> placeableObjects;

    public Tile RedTile;
    public Tile BlueTile;
    public Tile GreenTile;
    public Tile WhiteTile;
    public Tile RoundWhiteTile;
    public GameObject TDTextPrf;
    public GameObject TDEyePrf;
    public GameObject TDGatePrf;
    public GameObject TDPlaceableObjectPrf;
 
    public Dictionary<TileColor, int> exitColorCount;
    public Dictionary<Species, int> mapEyeCount;
    public Dictionary<Position, int> exitGaroSero;
    public bool canAskRed;
    public bool canAskBlue;
    public bool canAskGreen;
    public bool canAskWhite;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void InitMap()
    {
        currentStageData = StageDataList.stages[GameManager.Instance.currentStage - 1];
        map = new List<TDObject>();
        eyes = new List<TDEye>();
        gates = new List<TDGate>();
        
        CreateTilesAndObjects();
        SetAnswer();
        SetAskable();
    }

    public void CreateTilesAndObjects()
    {
        foreach(TDTileData tile in currentStageData.tiles)
        {
            if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Null && tile.data[1] == 1)
            {
                GamePlay.instance.player.transform.position = tile.pos + MyUtils.Offset;
                GamePlay.instance.posOnMap = tile.pos;
            }

            switch (tile.color)
            {
                case TileColor.Red: tilemap.SetTile(tile.pos, RedTile); break;
                case TileColor.Blue: tilemap.SetTile(tile.pos, BlueTile); break;
                case TileColor.Green: tilemap.SetTile(tile.pos, GreenTile); break;
                case TileColor.White: 
                    if ((WhiteData)tile.data[0] == WhiteData.Gate) tilemap.SetTile(tile.pos, RoundWhiteTile);
                    else tilemap.SetTile(tile.pos, WhiteTile); 
                    break;
            }

            switch (tile.color)
            {
                case TileColor.Red: case TileColor.Blue: case TileColor.Green:
                    TDText tdText = Instantiate(TDTextPrf).GetComponent<TDText>();
                    tdText.Init(tile, TDTileData.GetText(tile));
                    map.Add(tdText);
                    break;
            
                case TileColor.White:
                    if ((WhiteData)tile.data[0] == WhiteData.Eye) {
                        TDEye tdEye = Instantiate(TDEyePrf).GetComponent<TDEye>();
                        tdEye.Init(tile);
                        map.Add(tdEye);
                        eyes.Add(tdEye);
                    }
                    else if ((WhiteData)tile.data[0] == WhiteData.Gate) {
                        TDGate tdGate = Instantiate(TDGatePrf).GetComponent<TDGate>();
                        tdGate.Init(tile);
                        map.Add(tdGate);
                        gates.Add(tdGate);
                    }
                    else if ((WhiteData)tile.data[0] == WhiteData.Null) //임시 음영 처리를 위한 코드
                    {
                        TDText emptyText = Instantiate(TDTextPrf).GetComponent<TDText>();
                        emptyText.Init(tile, "");
                        map.Add(emptyText);
                        break;
                    }
                    break;
            }
        }

        if (currentStageData.placeableTiles == null) return;
        for (int i = 0; i < currentStageData.placeableTiles.Count; i++)
        {
            TDPlaceableObject tdPobj = Instantiate(TDPlaceableObjectPrf).GetComponent<TDPlaceableObject>();

            float width = 1.5f;
            float startPoint = (currentStageData.minY + 1 + currentStageData.maxY - width * (currentStageData.placeableTiles.Count - 1)) / 2f;
            Vector3 palettePos = new Vector3(currentStageData.minX - 1, startPoint + width * i, 0);

            TDTileData tileData = currentStageData.placeableTiles[i];
            tdPobj.Init(palettePos, tileData, TDTileData.GetText(tileData));
            switch (tileData.color)
            {
                case TileColor.Red: tdPobj.text.color = Color.red; break;
                case TileColor.Blue: tdPobj.text.color = Color.blue; break;
                case TileColor.Green: tdPobj.text.color = Color.green; break;

            }
            map.Add(tdPobj);
            placeableObjects.Add(tdPobj);
        }
    }

    public void SetAnswer()
    {
        TDTileData exit = gates.Find(gate => gate.tileData.data[1] == (int)Species.Angel).tileData;
        
        exitColorCount = new Dictionary<TileColor, int>();
        exitColorCount[TileColor.Red] = 0;
        exitColorCount[TileColor.Blue] = 0;
        exitColorCount[TileColor.Green] = 0;
        exitColorCount[TileColor.White] = -1;
        foreach (TDTileData tile in currentStageData.tiles)
        {
            if (Math.Abs(tile.pos.x - exit.pos.x) <= 1 && Math.Abs(tile.pos.y - exit.pos.y) <= 1) {
                exitColorCount[tile.color]++;
            }
        }

        mapEyeCount = new Dictionary<Species, int>();
        mapEyeCount[Species.Angel] = 0;
        mapEyeCount[Species.Devil] = 0;
        foreach (TDTileData tile in currentStageData.tiles)
        {
            if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Eye) {
                mapEyeCount[(Species)tile.data[1]]++;
            }
        }

        exitGaroSero = new Dictionary<Position, int>();
        exitGaroSero[Position.Row] = currentStageData.maxY - exit.pos.y + 1;
        exitGaroSero[Position.Col] = exit.pos.x - currentStageData.minX + 1;
    }

    public void SetAskable()
    {
        canAskRed = canAskBlue = canAskGreen = canAskWhite = false;

        foreach(TDObject obj in map)
        {
            if (obj.tileData.color == TileColor.Blue)
            {
                if (obj.tileData.isHiding)
                {
                    canAskRed = canAskBlue = canAskGreen = canAskWhite = true;
                    break;
                }
                if (obj.tileData.data[0] != (int)BlueData.Color) 
                {
                    continue;
                }

                switch ((TileColor)obj.tileData.data[1])
                {
                    case TileColor.Red: canAskRed = true; break;
                    case TileColor.Blue: canAskBlue = true; break;
                    case TileColor.Green: canAskGreen = true; break;
                    case TileColor.White: canAskWhite = true; break;
                }
            }
        }

        gates.ForEach(gate => gate.SetInfoBox());
    }
}
