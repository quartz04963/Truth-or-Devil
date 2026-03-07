using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public readonly struct TDTileData
{
    public readonly Vector3Int pos;
    public readonly TileColor color;
    public readonly List<int> data;

    public TDTileData(Vector3Int pos, TileColor color, List<int> data)
    {
        this.pos = pos;
        this.color = color; 
        this.data = data;
    }
}

public readonly struct StageData
{
    public const int Ch1StageCount = 13;
    public const int Ch2StageCount = 7;
    public const int Ch3StageCount = 0;
    public static List<TDTileData>[] StageList = new List<TDTileData>[Ch1StageCount + Ch2StageCount + Ch3StageCount];

    static StageData()
    {
        //챕터 1
        StageList[0] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 1, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(4, 1, WhiteData.Gate, ToD.Truth, 1),
            MyUtils.ConstructTileData(0, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 0, "GATE"),
            MyUtils.ConstructTileData(2, 0, "RED"),
            MyUtils.ConstructTileData(3, 0, "1"),
            MyUtils.ConstructTileData(4, 0, WhiteData.Eye, ToD.Truth, 0),
        };

        StageList[1] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 2, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(1, 2, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(2, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(0, 1, "1"),
            MyUtils.ConstructTileData(1, 1, "GATE"),
            MyUtils.ConstructTileData(2, 1, "WHITE"),
            MyUtils.ConstructTileData(0, 0, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTileData(1, 0, "GREEN"),
            MyUtils.ConstructTileData(2, 0, WhiteData.Eye, ToD.Devil, 0),
        };

        StageList[2] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 2, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(2, 2, "1"),
            MyUtils.ConstructTileData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 1, "BLUE"),
            MyUtils.ConstructTileData(2, 1, "RED"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(4, 1, "8"),
            MyUtils.ConstructTileData(1, 0, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(2, 0, "GATE"),
        };

        StageList[3] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(2, 3, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(1, 2, "WHITE"),
            MyUtils.ConstructTileData(2, 2, "GATE"),
            MyUtils.ConstructTileData(3, 2, "RED"),
            MyUtils.ConstructTileData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 1, "1"),
            MyUtils.ConstructTileData(2, 1, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(3, 1, "2"),
            MyUtils.ConstructTileData(4, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(2, 0, WhiteData.Gate, ToD.Devil, 2),
        };

        StageList[4] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 2, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(2, 2, "BLUE"),
            MyUtils.ConstructTileData(3, 2, "0"),
            MyUtils.ConstructTileData(4, 2, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(0, 1, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(1, 1, "GATE"),
            MyUtils.ConstructTileData(2, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(3, 1, "GATE"),
            MyUtils.ConstructTileData(4, 1, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTileData(0, 0, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(1, 0, "RED"),
            MyUtils.ConstructTileData(2, 0, "1"),
            MyUtils.ConstructTileData(3, 0, WhiteData.Blank, ToD.Null, 0),
        };

        StageList[5] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(2, 4, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(0, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(1, 3, "GATE"),
            MyUtils.ConstructTileData(2, 3, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(3, 3, "GATE"),
            MyUtils.ConstructTileData(0, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(1, 2, "GREEN"),
            MyUtils.ConstructTileData(2, 2, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTileData(3, 2, "WHITE"),
            MyUtils.ConstructTileData(0, 1, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTileData(1, 1, "3"),
            MyUtils.ConstructTileData(2, 1, "2"),
            MyUtils.ConstructTileData(3, 1, "1"),
            MyUtils.ConstructTileData(0, 0, WhiteData.Gate, ToD.Devil, 4),
            MyUtils.ConstructTileData(1, 0, "1"),
            MyUtils.ConstructTileData(2, 0, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTileData(3, 0, "1"),
        };

        StageList[6] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(3, 3, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(0, 2, "1"),
            MyUtils.ConstructTileData(1, 2, "MAP"),
            MyUtils.ConstructTileData(2, 2, "DEVIL"),
            MyUtils.ConstructTileData(3, 2, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTileData(4, 2, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTileData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 1, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(2, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(3, 1, "GATE"),
            MyUtils.ConstructTileData(2, 0, "1"),
            MyUtils.ConstructTileData(3, 0, "RED"),
        };

        StageList[7] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 2, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(2, 2, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(3, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 1, "MAP"),
            MyUtils.ConstructTileData(2, 1, "ANGEL"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(1, 0, "GATE"),
            MyUtils.ConstructTileData(2, 0, "1"),
            MyUtils.ConstructTileData(3, 0, "RED"),
        };

        StageList[8] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 3, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(2, 3, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTileData(0, 2, "0"),
            MyUtils.ConstructTileData(1, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(2, 2, WhiteData.Blank, ToD.Null, 0),
            MyUtils.ConstructTileData(3, 2, "2"),
            MyUtils.ConstructTileData(0, 1, "RED"),
            MyUtils.ConstructTileData(1, 1, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTileData(2, 1, "BLUE"),
            MyUtils.ConstructTileData(3, 1, "DEVIL"),
            MyUtils.ConstructTileData(0, 0, "GATE"),
            MyUtils.ConstructTileData(1, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(2, 0, WhiteData.Blank, ToD.Null, 0),
            MyUtils.ConstructTileData(3, 0, "MAP"),
        };

        StageList[9] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 4, "GATE"),
            MyUtils.ConstructTileData(1, 4, "BLUE"),
            MyUtils.ConstructTileData(2, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(0, 3, "WHITE"),
            MyUtils.ConstructTileData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(2, 3, "2"),
            MyUtils.ConstructTileData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(0, 2, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(1, 2, "1"),
            MyUtils.ConstructTileData(2, 2, "GREEN"),
            MyUtils.ConstructTileData(3, 2, "1"),
            MyUtils.ConstructTileData(4, 2, "RED"),
            MyUtils.ConstructTileData(1, 1, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(2, 1, "1"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTileData(4, 1, WhiteData.Gate, ToD.Truth, 3),
            MyUtils.ConstructTileData(2, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(3, 0, WhiteData.Gate, ToD.Devil, 4),
        };

        StageList[10] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(2, 4, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(4, 4, "0"),
            MyUtils.ConstructTileData(0, 3, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 3, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(2, 3, "MAP"),
            MyUtils.ConstructTileData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(4, 3, "GREEN"),
            MyUtils.ConstructTileData(0, 2, "1"),
            MyUtils.ConstructTileData(1, 2, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTileData(2, 2, "DEVIL"),
            MyUtils.ConstructTileData(3, 2, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTileData(4, 2, "GATE"),
            MyUtils.ConstructTileData(0, 1, "WHITE"),
            MyUtils.ConstructTileData(1, 1, WhiteData.Gate, ToD.Devil, 4),
            MyUtils.ConstructTileData(2, 1, "1"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(4, 1, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTileData(0, 0, "GATE"),
        };

        StageList[11] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(4, 3, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(0, 2, "2"),
            MyUtils.ConstructTileData(1, 2, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(2, 2, "0"),
            MyUtils.ConstructTileData(3, 2, WhiteData.Gate, ToD.Truth, 1),
            MyUtils.ConstructTileData(4, 2, "2"),
            MyUtils.ConstructTileData(0, 1, "MAP"),
            MyUtils.ConstructTileData(1, 1, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(2, 1, "MAP"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(4, 1, "GATE"),
            MyUtils.ConstructTileData(0, 0, "ANGEL"),
            MyUtils.ConstructTileData(1, 0, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTileData(2, 0, "GREEN"),
            MyUtils.ConstructTileData(3, 0, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTileData(4, 0, "BLUE"),
        };

        StageList[12] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 4, "2"),
            MyUtils.ConstructTileData(2, 4, "DEVIL"),
            MyUtils.ConstructTileData(3, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(4, 4, "DEVIL"),
            MyUtils.ConstructTileData(5, 4, "RED"),
            MyUtils.ConstructTileData(1, 3, "ANGEL"),
            MyUtils.ConstructTileData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(3, 3, "MAP"),
            MyUtils.ConstructTileData(4, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(5, 3, "GREEN"),
            MyUtils.ConstructTileData(0, 2, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 2, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTileData(2, 2, "GATE"),
            MyUtils.ConstructTileData(4, 2, "GATE"),
            MyUtils.ConstructTileData(5, 2, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTileData(1, 1, "2"),
            MyUtils.ConstructTileData(2, 1, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTileData(4, 1, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTileData(5, 1, "1"),
            MyUtils.ConstructTileData(1, 0, "BLUE"),
            MyUtils.ConstructTileData(2, 0, "2"),
            MyUtils.ConstructTileData(3, 0, WhiteData.Eye, ToD.Devil, 3),
            MyUtils.ConstructTileData(4, 0, "3"),
            MyUtils.ConstructTileData(5, 0, "2"),
        };

        //챕터 2
        StageList[Ch1StageCount + 0] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 3, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(0, 2, "MAP"),
            MyUtils.ConstructTileData(1, 2, "GATE"),
            MyUtils.ConstructTileData(0, 1, "ANGEL"),
            MyUtils.ConstructTileData(1, 1, "RED"),
            MyUtils.ConstructTileData(0, 0, "2"),
            MyUtils.ConstructTileData(1, 0, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(2, 0, WhiteData.Gate, ToD.Truth, 1),    
        };

        StageList[Ch1StageCount + 1] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 3, "MAP"),
            MyUtils.ConstructTileData(1, 3, "DEVIL"),
            MyUtils.ConstructTileData(2, 3, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(3, 3, "RED"),
            MyUtils.ConstructTileData(4, 3, "MAP"),
            MyUtils.ConstructTileData(0, 2, "GREEN"),
            MyUtils.ConstructTileData(1, 2, "1"),
            MyUtils.ConstructTileData(2, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(3, 2, "0"),
            MyUtils.ConstructTileData(4, 2, "ANGEL"),
            MyUtils.ConstructTileData(0, 1, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTileData(1, 1, "GATE"),
            MyUtils.ConstructTileData(2, 1, "2"),
            MyUtils.ConstructTileData(3, 1, "GATE"),
            MyUtils.ConstructTileData(4, 1, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTileData(2, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(3, 0, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(4, 0, WhiteData.Gate, ToD.Devil, 3),
        };

        StageList[Ch1StageCount + 2] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 4, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(2, 4, "2"),
            MyUtils.ConstructTileData(3, 4, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(1, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(2, 3, "WHITE"),
            MyUtils.ConstructTileData(3, 3, "GATE"),
            MyUtils.ConstructTileData(1, 2, "MAP"),
            MyUtils.ConstructTileData(2, 2, "ANGEL"),
            MyUtils.ConstructTileData(3, 2, "1"),
            MyUtils.ConstructTileData(4, 2, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(0, 1, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTileData(1, 1, "0"),
            MyUtils.ConstructTileData(2, 1, "BLUE"),
            MyUtils.ConstructTileData(3, 1, "GATE"),
            MyUtils.ConstructTileData(4, 1, "3"),
            MyUtils.ConstructTileData(0, 0, "MAP"),
            MyUtils.ConstructTileData(1, 0, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(2, 0, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(3, 0, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTileData(4, 0, "DEVIL"),
        };

        StageList[Ch1StageCount + 3] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 5, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(2, 5, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(1, 4, "0"),
            MyUtils.ConstructTileData(2, 4, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(3, 4, "MAP"),
            MyUtils.ConstructTileData(4, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(1, 3, "GATE"),
            MyUtils.ConstructTileData(2, 3, "1"),
            MyUtils.ConstructTileData(3, 3, "3"),
            MyUtils.ConstructTileData(4, 3, "GATE"),
            MyUtils.ConstructTileData(1, 2, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(2, 2, "MAP"),
            MyUtils.ConstructTileData(3, 2, "ANGEL"),
            MyUtils.ConstructTileData(4, 2, "2"),
            MyUtils.ConstructTileData(0, 1, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTileData(1, 1, "RED"),
            MyUtils.ConstructTileData(2, 1, "BLUE"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(4, 1, "DEVIL"),
            MyUtils.ConstructTileData(3, 0, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTileData(4, 0, WhiteData.Eye, ToD.Truth, 3),
        };

        StageList[Ch1StageCount + 4] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 3, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTileData(1, 3, "RED"),
            MyUtils.ConstructTileData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(1, 2, "GATE"),
            MyUtils.ConstructTileData(2, 2, "8"),
            MyUtils.ConstructTileData(3, 2, "BLUE"),
            MyUtils.ConstructTileData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 1, "1"),
            MyUtils.ConstructTileData(2, 1, "GATE"),
            MyUtils.ConstructTileData(2, 0, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(3, 0, WhiteData.Gate, ToD.Devil, 2),
        };

        StageList[Ch1StageCount + 5] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(0, 2, "GREEN"),
            MyUtils.ConstructTileData(1, 2, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(2, 2, "1"),
            MyUtils.ConstructTileData(3, 2, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(0, 1, WhiteData.Gate, ToD.Truth, 1),
            MyUtils.ConstructTileData(1, 1, "BLUE"),
            MyUtils.ConstructTileData(2, 1, "GATE"),
            MyUtils.ConstructTileData(3, 1, "0"),
            MyUtils.ConstructTileData(1, 0, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(2, 0, "RED"),
            MyUtils.ConstructTileData(3, 0, WhiteData.Blank, ToD.Null, 1),
        };

        StageList[Ch1StageCount + 6] = new List<TDTileData>
        {
            MyUtils.ConstructTileData(1, 5, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTileData(0, 4, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTileData(1, 4, "2"),
            MyUtils.ConstructTileData(2, 4, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTileData(3, 4, "1"),
            MyUtils.ConstructTileData(4, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTileData(0, 3, "1"),
            MyUtils.ConstructTileData(1, 3, "DEVIL"),
            MyUtils.ConstructTileData(2, 3, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTileData(3, 3, "2"),
            MyUtils.ConstructTileData(4, 3, "WHITE"),
            MyUtils.ConstructTileData(0, 2, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTileData(1, 2, "BLUE"),
            MyUtils.ConstructTileData(2, 2, "GATE"),
            MyUtils.ConstructTileData(3, 2, WhiteData.Gate, ToD.Truth, 3),
            MyUtils.ConstructTileData(4, 2, WhiteData.Gate, ToD.Devil, 4),
            MyUtils.ConstructTileData(0, 1, "1"),
            MyUtils.ConstructTileData(1, 1, "GREEN"),
            MyUtils.ConstructTileData(2, 1, "2"),
            MyUtils.ConstructTileData(3, 1, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTileData(4, 1, "RED"),
            MyUtils.ConstructTileData(5, 1, WhiteData.Gate, ToD.Devil, 5),
            MyUtils.ConstructTileData(0, 0, "RED"),
            MyUtils.ConstructTileData(1, 0, "0"),
            MyUtils.ConstructTileData(2, 0, WhiteData.Gate, ToD.Devil, 6),
            MyUtils.ConstructTileData(3, 0, "ANGEL"),
            MyUtils.ConstructTileData(4, 0, "MAP"),
        };
    }
}
