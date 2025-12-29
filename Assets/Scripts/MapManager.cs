using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public struct TDData
{
    public Vector3Int pos;
    public TileColor color;
    public List<int> data;

    public TDData(Vector3Int _pos, TileColor _color, List<int> _data)
    {
        pos = _pos;
        color = _color; 
        data = _data;
    }
}

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    
    public List<TDData> tileList;
    public List<TDObject> objectList;
    public Tilemap map;

    public Tile RedTile;
    public Tile BlueTile;
    public Tile GreenTile;
    public Tile WhiteTile;
    public GameObject TDTextPrf;
    public GameObject TDEyePrf;
    public GameObject TDGatePrf;
 
    public int[] gateColorCount;
    public int[] mapEyeCount; 

    public int stageNumber;

    void Awake()
    {
        if (instance == null) instance = this;
        else DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        tileList = MyUtils.stageList[stageNumber];
        InitMap();
    }

    public void InitMap()
    {
        objectList = new List<TDObject>();

        foreach(TDData tile in tileList)
        {
            if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Blank && tile.data[1] == 1)
            {
                GamePlay.instance.player.transform.position = tile.pos + MyUtils.offset;
                GamePlay.instance.posOnMap = tile.pos;
            }

            switch (tile.color)
            {
                case TileColor.Red: map.SetTile(tile.pos, RedTile); break;
                case TileColor.Blue: map.SetTile(tile.pos, BlueTile); break;
                case TileColor.Green: map.SetTile(tile.pos, GreenTile); break;
                case TileColor.White: map.SetTile(tile.pos, WhiteTile); break;
            }

            switch (tile.color)
            {
                case TileColor.Red: case TileColor.Blue: case TileColor.Green:
                    TDText TDtext = Instantiate(TDTextPrf).GetComponent<TDText>();
                    TDtext.Init(tile.pos, MyUtils.GetTextFromData(tile.color, tile.data));
                    objectList.Add(TDtext);
                    break;
             
                case TileColor.White:
                    if (tile.data[0] == (int)WhiteData.Eye) {
                        TDEye TDeye = Instantiate(TDEyePrf).GetComponent<TDEye>();
                        TDeye.Init(tile.pos, $"{(char)('A' + tile.data[2])}");
                        TDeye.trueID = (ToD)tile.data[1];
                        objectList.Add(TDeye);
                    }
                    else if (tile.data[0] == (int)WhiteData.Gate) {
                        TDGate TDgate = Instantiate(TDGatePrf).GetComponent<TDGate>();
                        TDgate.Init(tile.pos, $"{(char)('A' + tile.data[2])}");
                        objectList.Add(TDgate);
                    }
                    break;
            }
        }

        SetAnswer();
    }

    public void SetAnswer()
    {
        gateColorCount = new[]{0, 0, 0, 0};
        TDData gate = tileList.Find(tile => tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Gate && tile.data[1] == (int)ToD.Truth);
        foreach (TDData tile in tileList)
        {
            if (Math.Abs(tile.pos.x - gate.pos.x) <= 1 && Math.Abs(tile.pos.y - gate.pos.y) <= 1) gateColorCount[(int)tile.color]++;
        }
        gateColorCount[(int)TileColor.White]--;

        mapEyeCount = new[]{0, 0, 0};
        foreach (TDData tile in tileList)
        {
            if (tile.color == TileColor.White && tile.data[0] == (int)WhiteData.Eye) mapEyeCount[tile.data[1]]++;
        }
    }
}
