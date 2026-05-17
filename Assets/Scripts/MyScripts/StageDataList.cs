using System.Collections.Generic;

public readonly struct StageDataList
{
    public const int Chapter0 = 6;
    public const int Chapter1 = 6;
    public const int Chapter2 = 6;
    public const int Chapter3 = 6;
    public const int Chapter4 = 0;
    public const int Chapter5 = 0;

    public static int StageCount => Chapter0 + Chapter1 + Chapter2 + Chapter3 + Chapter4 + Chapter5;

    public static List<StageData> stages = new List<StageData>()
    {
        new StageData(0, 1, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(2, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(2, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(4, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(1, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(2, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(4, 0, WhiteData.Blank, ToD.Null, 0),
        }),

        new StageData(0, 2, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, "EXIT"),
            TileData.Construct(2, 2, "8"),
            TileData.Construct(3, 2, "8"),
            TileData.Construct(4, 2, "8"),
            TileData.Construct(0, 1, "GREEN"),
            TileData.Construct(2, 1, "8"),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 1, "8"),
            TileData.Construct(0, 0, "8"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 0, "8"),
            TileData.Construct(3, 0, "8"),
            TileData.Construct(4, 0, "8"),
        }),

        new StageData(0, 3, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, "EXIT"),
            TileData.Construct(2, 2, "EXIT"),
            TileData.Construct(3, 2, "EXIT"),
            TileData.Construct(4, 2, "EXIT"),
            TileData.Construct(0, 1, "GREEN"),
            TileData.Construct(2, 1, "EXIT"),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 1, "EXIT"),
            TileData.Construct(0, 0, "8"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 0, "EXIT"),
            TileData.Construct(3, 0, "EXIT"),
            TileData.Construct(4, 0, "EXIT"),
        }),

        new StageData(0, 4, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, "WHITE"),
            TileData.Construct(2, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(4, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 1, "3"),
            TileData.Construct(2, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(4, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 0, "EXIT"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 0, "BLUE"),
            TileData.Construct(3, 0, "BLUE"),
            TileData.Construct(4, 0, "BLUE"),
        }),

        new StageData(0, 5, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, "1"),
            TileData.Construct(2, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 1, "EXIT"),
            TileData.Construct(2, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(4, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 0, "GREEN"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 0, "8"),
            TileData.Construct(4, 0, WhiteData.Blank, ToD.Null, 0),
        }),

        new StageData(0, 6, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(2, 2, "BLUE"),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(4, 2, "RED"),
            TileData.Construct(0, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(2, 1, "EXIT"),
            TileData.Construct(3, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(4, 1, "EXIT"),
            TileData.Construct(0, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 0, "2"),
            TileData.Construct(3, 0, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(4, 0, "8"),
        }),
        
        new StageData(1, 1, new List<TileData>
        {
            TileData.Construct(1, 2, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(2, 2, "1"),
            TileData.Construct(3, 2, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(0, 1, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(1, 1, "GARO"),
            TileData.Construct(2, 1, "2"),
            TileData.Construct(3, 1, "EXIT"),
            TileData.Construct(1, 0, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(2, 0, "3"),
            TileData.Construct(3, 0, WhiteData.Gate, ToD.Devil, 2),
        }),

        new StageData(1, 2, new List<TileData>
        {
            TileData.Construct(1, 3, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(3, 3, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(0, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(1, 2, "GARO"),
            TileData.Construct(2, 2, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(3, 2, "2"),
            TileData.Construct(4, 2, WhiteData.Gate, ToD.Devil, 3),
            TileData.Construct(1, 1, "EXIT"),
            TileData.Construct(3, 1, "1"),
            TileData.Construct(1, 0, "SERO"),
            TileData.Construct(2, 0, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(3, 0, "0"),
        }),

        new StageData(1, 3, new List<TileData>
        {
            TileData.Construct(1, 4, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(3, 4, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(0, 3, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(1, 3, "0"),
            TileData.Construct(2, 3, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 3, "2"),
            TileData.Construct(4, 3, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 2, "GARO"),
            TileData.Construct(2, 2, "1"),
            TileData.Construct(4, 2, "SERO"),
            TileData.Construct(0, 1, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(1, 1, "EXIT"),
            TileData.Construct(2, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, "EXIT"),
            TileData.Construct(4, 1, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(1, 0, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(3, 0, WhiteData.Blank, ToD.Null, 0),
        }),

        new StageData(1, 4, new List<TileData>
        {
            TileData.Construct(0, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(1, 2, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(2, 2, "1"),
            TileData.Construct(0, 1, "EXIT"),
            TileData.Construct(1, 1, "GARO", true),
            TileData.Construct(2, 1, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(0, 0, WhiteData.Gate, ToD.Truth, 2),
            TileData.Construct(1, 0, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(2, 0, "2"),
        }),

        new StageData(1, 5, new List<TileData>
        {
            TileData.Construct(0, 2, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(1, 2, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(4, 2, "1"),
            TileData.Construct(5, 2, "EXIT"),
            TileData.Construct(1, 1, "GARO"),
            TileData.Construct(2, 1, "SERO"),
            TileData.Construct(3, 1, "1", true),
            TileData.Construct(4, 1, WhiteData.Eye, ToD.Truth, 1),
            TileData.Construct(5, 1, "2"),
            TileData.Construct(0, 0, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(1, 0, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(2, 0, WhiteData.Gate, ToD.Truth, 3),
            TileData.Construct(4, 0, "3"),
            TileData.Construct(5, 0, "EXIT"),
        }),

        new StageData(1, 6, new List<TileData>
        {
            TileData.Construct(0, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(1, 2, "EXIT"),
            TileData.Construct(3, 2, "EXIT"),
            TileData.Construct(4, 2, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(0, 1, "GARO"),
            TileData.Construct(1, 1, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 1, "2", true),
            TileData.Construct(3, 1, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(4, 1, "SERO"),
            TileData.Construct(0, 0, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(1, 0, "1"),
            TileData.Construct(2, 0, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(3, 0, "3"),
            TileData.Construct(4, 0, WhiteData.Gate, ToD.Truth, 3),
        }),

        new StageData(2, 1, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, "MAP"),
            TileData.Construct(2, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 1, "DEVIL"),
            TileData.Construct(2, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(4, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 0, "3"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 0, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(3, 0, WhiteData.Eye, ToD.Devil, 2),
            TileData.Construct(4, 0, WhiteData.Eye, ToD.Devil, 3),
        }),

        new StageData(2, 2, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 2, "MAP"),
            TileData.Construct(2, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 2, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 1, "DEVIL"),
            TileData.Construct(2, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(4, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(0, 0, "3"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 0, "1"),
            TileData.Construct(3, 0, "BLUE"),
            TileData.Construct(4, 0, "EXIT"),
        }),

        new StageData(2, 3, new List<TileData>
        {
            TileData.Construct(1, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(3, 3, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(1, 2, "MAP"),
            TileData.Construct(2, 2, "ANGEL"),
            TileData.Construct(3, 2, "1"),
            TileData.Construct(1, 1, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 1, WhiteData.Eye, ToD.Truth, 1),
            TileData.Construct(0, 0, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(1, 0, "EXIT"),
            TileData.Construct(2, 0, "GREEN"),
            TileData.Construct(3, 0, "1"),
            TileData.Construct(4, 0, WhiteData.Gate, ToD.Truth, 1),
        }),

        new StageData(2, 4, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(2, 3, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(4, 3, WhiteData.Eye, ToD.Truth, 1),
            TileData.Construct(0, 2, "2"),
            TileData.Construct(2, 2, "1"),
            TileData.Construct(3, 2, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(0, 1, "DEVIL"),
            TileData.Construct(2, 1, "GARO"),
            TileData.Construct(3, 1, "2"),
            TileData.Construct(4, 1, WhiteData.Gate, ToD.Truth, 2),
            TileData.Construct(0, 0, "EXIT"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 0, "MAP"),
            TileData.Construct(3, 0, "GARO"),
            TileData.Construct(4, 0, "3"),
        }),

        new StageData(2, 5, new List<TileData>
        {
            TileData.Construct(0, 2, "1"),
            TileData.Construct(1, 2, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(3, 2, "MAP"),
            TileData.Construct(4, 2, WhiteData.Eye, ToD.Devil, 2),
            TileData.Construct(5, 2, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(6, 2, "2"),
            TileData.Construct(0, 1, "GARO"),
            TileData.Construct(1, 1, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(3, 1, "ANGEL"),
            TileData.Construct(5, 1, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(6, 1, "SERO"),
            TileData.Construct(0, 0, "EXIT"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 0, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(3, 0, "2"),
            TileData.Construct(5, 0, WhiteData.Gate, ToD.Devil, 3),
            TileData.Construct(6, 0, "EXIT"),
        }),

        new StageData(2, 6, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(2, 3, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(3, 3, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(4, 3, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(0, 2, "MAP"),
            TileData.Construct(2, 2, "WHITE"),
            TileData.Construct(3, 2, "1"),
            TileData.Construct(4, 2, "EXIT"),
            TileData.Construct(0, 1, "0"),
            TileData.Construct(2, 1, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(3, 1, "ANGEL", true),
            TileData.Construct(4, 1, "2"),
            TileData.Construct(0, 0, "BLUE"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(3, 0, WhiteData.Eye, ToD.Devil, 2),
            TileData.Construct(4, 0, "WHITE"),
        }),

        new StageData(3, 1, new List<TileData>
        {
            TileData.Construct(0, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(2, 2, "8"),
            TileData.Construct(3, 2, "8"),
            TileData.Construct(4, 2, "8"),
            TileData.Construct(0, 1, "GREEN"),
            TileData.Construct(2, 1, "8"),
            TileData.Construct(3, 1, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(4, 1, "8"),
            TileData.Construct(0, 0, "8"),
            TileData.Construct(1, 0, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 0, "8"),
            TileData.Construct(3, 0, "8"),
            TileData.Construct(4, 0, "8"),
        }, new List<TileData>
        {
            TileData.Construct(-1, -1, "EXIT"),
        }),

        new StageData(3, 2, new List<TileData>
        {
            TileData.Construct(1, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(1, 2, "EXIT"),
            TileData.Construct(2, 2, "ANGEL"),
            TileData.Construct(3, 2, "0"),
            TileData.Construct(4, 2, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(0, 1, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(5, 1, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(1, 0, "MAP"),
            TileData.Construct(2, 0, "RED"),
            TileData.Construct(3, 0, "2"),
            TileData.Construct(4, 0, WhiteData.Eye, ToD.Truth, 1),
        }, new List<TileData> 
        {
            TileData.Construct(-1, -1, "RED", false, true),
        }),

        new StageData(3, 3, new List<TileData>
        {
            TileData.Construct(1, 4, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(2, 4, WhiteData.Gate, ToD.Devil, 1),
            TileData.Construct(0, 3, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(1, 3, "EXIT"),
            TileData.Construct(2, 3, "MAP"),
            TileData.Construct(3, 3, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(4, 3, "GARO"),
            TileData.Construct(0, 2, WhiteData.Gate, ToD.Devil, 3),
            TileData.Construct(1, 2, "1"),
            TileData.Construct(4, 2, "2"),
            TileData.Construct(5, 2, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(1, 1, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(2, 1, "2"),
            TileData.Construct(5, 1, "1"),
            TileData.Construct(2, 0, "ANGEL"),
            TileData.Construct(3, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(4, 0, "MAP"),
            TileData.Construct(5, 0, "EXIT"),
        }, new List<TileData>
        {
            TileData.Construct(-1, -1, "EXIT", false, true),
            TileData.Construct(-1, -1, "SERO", false, true),
            TileData.Construct(-1, -1, "2", false, true),
        }),

        new StageData(3, 4, new List<TileData>
        {
            TileData.Construct(3, 4, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(1, 3, "1"),
            TileData.Construct(3, 3, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(5, 3, "2"),
            TileData.Construct(1, 2, "DEVIL"),
            TileData.Construct(5, 2, "RED"),
            TileData.Construct(0, 1, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(1, 1, "MAP"),
            TileData.Construct(2, 1, "EXIT", false, false, 0),
            TileData.Construct(3, 1, WhiteData.Eye, ToD.Truth, 1),
            TileData.Construct(4, 1, "EXIT", false, false, 0),
            TileData.Construct(5, 1, "EXIT"),
            TileData.Construct(6, 1, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(3, 0, WhiteData.Gate, ToD.Devil, 2),
        }, new List<TileData>
        {
            TileData.Construct(-1, -1, "EXIT", false, true),
            TileData.Construct(-1, -1, "MAP", false, true),
        }),

        new StageData(3, 5, new List<TileData>
        {
            TileData.Construct(0, 4, WhiteData.Eye, ToD.Devil, 0),
            TileData.Construct(1, 4, "0", false, false, 0),
            TileData.Construct(2, 4, "MAP"),
            TileData.Construct(3, 4, "ANGEL", false, false, 0),
            TileData.Construct(4, 4, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(0, 3, "ANGEL"),
            TileData.Construct(4, 3, "1"),
            TileData.Construct(0, 2, "ANGEL", false, false, 0),
            TileData.Construct(2, 2, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(4, 2, "0", false, false, 0),
            TileData.Construct(6, 2, WhiteData.Gate, ToD.Truth, 0),
            TileData.Construct(0, 1, "DEVIL"),
            TileData.Construct(4, 1, "2"),
            TileData.Construct(0, 0, WhiteData.Blank, ToD.Null, 0),
            TileData.Construct(1, 0, "0", false, false, 0),
            TileData.Construct(2, 0, "MAP"),
            TileData.Construct(3, 0, "ANGEL", false, false, 0),
            TileData.Construct(4, 0, WhiteData.Eye, ToD.Devil, 2),
        }, new List<TileData>
        {
            TileData.Construct(-1, -1, WhiteData.Blank, ToD.Null, 0, false, true),
        }),

        new StageData(3, 6, new List<TileData>
        {
            TileData.Construct(1, 5, WhiteData.Gate, ToD.Devil, 0),
            TileData.Construct(3, 5, WhiteData.Gate, ToD.Truth, 1),
            TileData.Construct(0, 4, "EXIT"),
            TileData.Construct(2, 4, "RED"),
            TileData.Construct(4, 4, "1"),
            TileData.Construct(1, 3, WhiteData.Gate, ToD.Devil, 2),
            TileData.Construct(2, 3, "RED", false, false, 0),
            TileData.Construct(3, 3, WhiteData.Gate, ToD.Devil, 3),
            TileData.Construct(0, 2, WhiteData.Eye, ToD.Truth, 0),
            TileData.Construct(2, 2, WhiteData.Eye, ToD.Devil, 1),
            TileData.Construct(4, 2, WhiteData.Eye, ToD.Truth, 2),
            TileData.Construct(0, 0, "MAP"),
            TileData.Construct(1, 0, "ANGEL"),
            TileData.Construct(2, 0, WhiteData.Blank, ToD.Null, 1),
            TileData.Construct(3, 0, "DEVIL"),
            TileData.Construct(4, 0, "MAP"),
        }, new List<TileData>
        {
            TileData.Construct(-1, -1, "WHITE", true, true),
            TileData.Construct(-1, -1, "0", true, true),
        }),
    };
}
