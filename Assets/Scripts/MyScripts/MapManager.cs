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
    
    public Tilemap map;
    public List<TDData> tileList;
    public List<TDObject> objectList;
    public List<TDEye> eyeList;
    public List<TDGate> gateList;

    public Tile RedTile;
    public Tile BlueTile;
    public Tile GreenTile;
    public Tile WhiteTile;
    public Tile RoundWhiteTile;
    public GameObject TDTextPrf;
    public GameObject TDEyePrf;
    public GameObject TDGatePrf;
 
    public int[] gateColorCount;
    public int[] mapEyeCount;
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
        tileList = TDStage.stageList[GameManager.instance.CurrentStage - 1];
        objectList = new List<TDObject>();
        eyeList = new List<TDEye>();
        gateList = new List<TDGate>();

        canAskRed = canAskBlue = canAskGreen = canAskWhite = false;
        foreach(TDData tile in tileList)
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
                case TileColor.White: 
                    if ((WhiteData)tile.data[0] == WhiteData.Gate) map.SetTile(tile.pos, RoundWhiteTile);
                    else map.SetTile(tile.pos, WhiteTile); 
                    break;
            }

            switch (tile.color)
            {
                case TileColor.Red: case TileColor.Blue: case TileColor.Green:
                    TDText tdText = Instantiate(TDTextPrf).GetComponent<TDText>();
                    tdText.Init(tile.pos, MyUtils.GetTextFromData(tile.color, tile.data));
                    objectList.Add(tdText);
                    break;
             
                case TileColor.White:
                    if ((WhiteData)tile.data[0] == WhiteData.Eye) {
                        TDEye tdEye = Instantiate(TDEyePrf).GetComponent<TDEye>();
                        tdEye.Init(tile.pos, tile.data[2]);
                        tdEye.trueID = (ToD)tile.data[1];
                        objectList.Add(tdEye);
                        eyeList.Add(tdEye);
                    }
                    else if ((WhiteData)tile.data[0] == WhiteData.Gate) {
                        TDGate tdGate = Instantiate(TDGatePrf).GetComponent<TDGate>();
                        tdGate.Init(tile.pos, tile.data[2]);
                        objectList.Add(tdGate);
                        gateList.Add(tdGate);
                    }
                    else if ((WhiteData)tile.data[0] == WhiteData.Blank) //임시 음영 처리를 위한 코드
                    {
                        TDText emptyText = Instantiate(TDTextPrf).GetComponent<TDText>();
                        emptyText.Init(tile.pos, "");
                        objectList.Add(emptyText);
                        break;
                    }
                    break;
            }
        }
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
