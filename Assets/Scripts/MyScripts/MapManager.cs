using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    
    public Tilemap map;
    public List<TileData> tiles;
    public List<TDObject> objects;
    public List<TDEye> eyes;
    public List<TDGate> gates;

    public Tile RedTile;
    public Tile BlueTile;
    public Tile GreenTile;
    public Tile WhiteTile;
    public Tile RoundWhiteTile;
    public GameObject TDTextPrf;
    public GameObject TDEyePrf;
    public GameObject TDGatePrf;
 
    public Dictionary<TileColor, int> exitColorCount;
    public Dictionary<ToD, int> mapEyeCount;
    public Dictionary<GaroSero, int> exitGaroSero;
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
        tiles = StageDataList.stages[GameManager.Instance.currentStage - 1].tiles;
        objects = new List<TDObject>();
        eyes = new List<TDEye>();
        gates = new List<TDGate>();

        canAskRed = canAskBlue = canAskGreen = canAskWhite = false;
        foreach(TileData tile in tiles)
        {
            if (tile.color == TileColor.Blue && tile.data[0] == (int)BlueData.Color)
            {
                switch ((TileColor)tile.data[1])
                {
                    case TileColor.Red: canAskRed = true; break;
                    case TileColor.Blue: canAskBlue = true; break;
                    case TileColor.Green: canAskGreen = true; break;
                    case TileColor.White: canAskWhite = true; break;
                }
            }
        }
        
        CreateTilesAndObjects();
        SetAnswer();
    }

    public void CreateTilesAndObjects()
    {
        foreach(TileData tile in tiles)
        {
            if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Blank && tile.data[1] == 1)
            {
                GamePlay.instance.player.transform.position = tile.pos + MyUtils.Offset;
                GamePlay.instance.posOnMap = tile.pos;
            }

            switch (tile.color)
            {
                case TileColor.Red: map.SetTile(tile.pos, RedTile); break;
                case TileColor.Blue: map.SetTile(tile.pos, BlueTile); break;
                case TileColor.Green: map.SetTile(tile.pos, GreenTile); break;
                case TileColor.White: 
                    if ((WhiteData)tile.data[0] == WhiteData.Gate) map.SetTile(tile.pos, RoundWhiteTile);
                    else map.SetTile(tile.pos, WhiteTile); 
                    break;
            }

            switch (tile.color)
            {
                case TileColor.Red: case TileColor.Blue: case TileColor.Green:
                    TDText tdText = Instantiate(TDTextPrf).GetComponent<TDText>();
                    tdText.Init(tile, TileData.GetText(tile));
                    objects.Add(tdText);
                    break;
             
                case TileColor.White:
                    if ((WhiteData)tile.data[0] == WhiteData.Eye) {
                        TDEye tdEye = Instantiate(TDEyePrf).GetComponent<TDEye>();
                        tdEye.Init(tile);
                        objects.Add(tdEye);
                        eyes.Add(tdEye);
                    }
                    else if ((WhiteData)tile.data[0] == WhiteData.Gate) {
                        TDGate tdGate = Instantiate(TDGatePrf).GetComponent<TDGate>();
                        tdGate.Init(tile);
                        objects.Add(tdGate);
                        gates.Add(tdGate);
                    }
                    else if ((WhiteData)tile.data[0] == WhiteData.Blank) //임시 음영 처리를 위한 코드
                    {
                        TDText emptyText = Instantiate(TDTextPrf).GetComponent<TDText>();
                        emptyText.Init(tile, "");
                        objects.Add(emptyText);
                        break;
                    }
                    break;
            }
        }
    }

    public void SetAnswer()
    {
        TileData gate = tiles.Find(tile => tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)ToD.Truth);
        
        exitColorCount = new Dictionary<TileColor, int>();
        exitColorCount[TileColor.Red] = 0;
        exitColorCount[TileColor.Blue] = 0;
        exitColorCount[TileColor.Green] = 0;
        exitColorCount[TileColor.White] = -1;
        foreach (TileData tile in tiles)
        {
            if (Math.Abs(tile.pos.x - gate.pos.x) <= 1 && Math.Abs(tile.pos.y - gate.pos.y) <= 1) {
                exitColorCount[tile.color]++;
            }
        }

        mapEyeCount = new Dictionary<ToD, int>();
        mapEyeCount[ToD.Truth] = 0;
        mapEyeCount[ToD.Devil] = 0;
        foreach (TileData tile in tiles)
        {
            if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Eye) {
                mapEyeCount[(ToD)tile.data[1]]++;
            }
        }

        exitGaroSero = new Dictionary<GaroSero, int>();
        int top = tiles[0].pos.y, left = tiles[0].pos.x;
        foreach (TileData tile in tiles)
        {
            if (tile.pos.y > top) top = tile.pos.y;
            if (tile.pos.x < left) left = tile.pos.x;
        }
        exitGaroSero[GaroSero.Garo] = top - gate.pos.y + 1;
        exitGaroSero[GaroSero.Sero] = gate.pos.x - left + 1;
    }
}
