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
        new StageData(0, 1, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(2, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(2, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(4, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(1, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(2, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(4, 0, WhiteData.Null, Species.Null, 0),
        }),

        new StageData(0, 2, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, "EXIT"),
            TDTileData.Construct(2, 2, "8"),
            TDTileData.Construct(3, 2, "8"),
            TDTileData.Construct(4, 2, "8"),
            TDTileData.Construct(0, 1, "GREEN"),
            TDTileData.Construct(2, 1, "8"),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 1, "8"),
            TDTileData.Construct(0, 0, "8"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 0, "8"),
            TDTileData.Construct(3, 0, "8"),
            TDTileData.Construct(4, 0, "8"),
        }),

        new StageData(0, 3, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, "EXIT"),
            TDTileData.Construct(2, 2, "EXIT"),
            TDTileData.Construct(3, 2, "EXIT"),
            TDTileData.Construct(4, 2, "EXIT"),
            TDTileData.Construct(0, 1, "GREEN"),
            TDTileData.Construct(2, 1, "EXIT"),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 1, "EXIT"),
            TDTileData.Construct(0, 0, "8"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 0, "EXIT"),
            TDTileData.Construct(3, 0, "EXIT"),
            TDTileData.Construct(4, 0, "EXIT"),
        }),

        new StageData(0, 4, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, "WHITE"),
            TDTileData.Construct(2, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(4, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 1, "3"),
            TDTileData.Construct(2, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(4, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 0, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 0, "BLUE"),
            TDTileData.Construct(3, 0, "BLUE"),
            TDTileData.Construct(4, 0, "BLUE"),
        }),

        new StageData(0, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, "1"),
            TDTileData.Construct(2, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 1, "EXIT"),
            TDTileData.Construct(2, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(4, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 0, "GREEN"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 0, "8"),
            TDTileData.Construct(4, 0, WhiteData.Null, Species.Null, 0),
        }),

        new StageData(0, 6, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(2, 2, "BLUE"),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(4, 2, "RED"),
            TDTileData.Construct(0, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(2, 1, "EXIT"),
            TDTileData.Construct(3, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(4, 1, "EXIT"),
            TDTileData.Construct(0, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 0, "2"),
            TDTileData.Construct(3, 0, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(4, 0, "8"),
        }),
        
        new StageData(1, 1, new List<TDTileData>
        {
            TDTileData.Construct(1, 2, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(3, 2, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(0, 1, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(1, 1, "GARO"),
            TDTileData.Construct(2, 1, "2"),
            TDTileData.Construct(3, 1, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(2, 0, "3"),
            TDTileData.Construct(3, 0, WhiteData.Gate, Species.Devil, 2),
        }),

        new StageData(1, 2, new List<TDTileData>
        {
            TDTileData.Construct(1, 3, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(3, 3, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(0, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(1, 2, "GARO"),
            TDTileData.Construct(2, 2, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(3, 2, "2"),
            TDTileData.Construct(4, 2, WhiteData.Gate, Species.Devil, 3),
            TDTileData.Construct(1, 1, "EXIT"),
            TDTileData.Construct(3, 1, "1"),
            TDTileData.Construct(1, 0, "SERO"),
            TDTileData.Construct(2, 0, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(3, 0, "0"),
        }),

        new StageData(1, 3, new List<TDTileData>
        {
            TDTileData.Construct(1, 4, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(3, 4, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(0, 3, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(1, 3, "0"),
            TDTileData.Construct(2, 3, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 3, "2"),
            TDTileData.Construct(4, 3, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 2, "GARO"),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(4, 2, "SERO"),
            TDTileData.Construct(0, 1, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(1, 1, "EXIT"),
            TDTileData.Construct(2, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, "EXIT"),
            TDTileData.Construct(4, 1, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(1, 0, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(3, 0, WhiteData.Null, Species.Null, 0),
        }),

        new StageData(1, 4, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(1, 2, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(0, 1, "EXIT"),
            TDTileData.Construct(1, 1, "GARO", true),
            TDTileData.Construct(2, 1, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(0, 0, WhiteData.Gate, Species.Angel, 2),
            TDTileData.Construct(1, 0, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(2, 0, "2"),
        }),

        new StageData(1, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(1, 2, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(4, 2, "1"),
            TDTileData.Construct(5, 2, "EXIT"),
            TDTileData.Construct(1, 1, "GARO"),
            TDTileData.Construct(2, 1, "SERO"),
            TDTileData.Construct(3, 1, "1", true),
            TDTileData.Construct(4, 1, WhiteData.Eye, Species.Angel, 1),
            TDTileData.Construct(5, 1, "2"),
            TDTileData.Construct(0, 0, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(1, 0, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(2, 0, WhiteData.Gate, Species.Angel, 3),
            TDTileData.Construct(4, 0, "3"),
            TDTileData.Construct(5, 0, "EXIT"),
        }),

        new StageData(1, 6, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(1, 2, "EXIT"),
            TDTileData.Construct(3, 2, "EXIT"),
            TDTileData.Construct(4, 2, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(0, 1, "GARO"),
            TDTileData.Construct(1, 1, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 1, "2", true),
            TDTileData.Construct(3, 1, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(4, 1, "SERO"),
            TDTileData.Construct(0, 0, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(1, 0, "1"),
            TDTileData.Construct(2, 0, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(3, 0, "3"),
            TDTileData.Construct(4, 0, WhiteData.Gate, Species.Angel, 3),
        }),

        new StageData(2, 1, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, "MAP"),
            TDTileData.Construct(2, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(2, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(4, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 0, "3"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 0, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(3, 0, WhiteData.Eye, Species.Devil, 2),
            TDTileData.Construct(4, 0, WhiteData.Eye, Species.Devil, 3),
        }),

        new StageData(2, 2, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 2, "MAP"),
            TDTileData.Construct(2, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 2, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(2, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(4, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(0, 0, "3"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 0, "1"),
            TDTileData.Construct(3, 0, "BLUE"),
            TDTileData.Construct(4, 0, "EXIT"),
        }),

        new StageData(2, 3, new List<TDTileData>
        {
            TDTileData.Construct(1, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(3, 3, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(1, 2, "MAP"),
            TDTileData.Construct(2, 2, "ANGEL"),
            TDTileData.Construct(3, 2, "1"),
            TDTileData.Construct(1, 1, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 1, WhiteData.Eye, Species.Angel, 1),
            TDTileData.Construct(0, 0, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(1, 0, "EXIT"),
            TDTileData.Construct(2, 0, "GREEN"),
            TDTileData.Construct(3, 0, "1"),
            TDTileData.Construct(4, 0, WhiteData.Gate, Species.Angel, 1),
        }),

        new StageData(2, 4, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(2, 3, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(4, 3, WhiteData.Eye, Species.Angel, 1),
            TDTileData.Construct(0, 2, "2"),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(3, 2, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(2, 1, "GARO"),
            TDTileData.Construct(3, 1, "2"),
            TDTileData.Construct(4, 1, WhiteData.Gate, Species.Angel, 2),
            TDTileData.Construct(0, 0, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 0, "MAP"),
            TDTileData.Construct(3, 0, "GARO"),
            TDTileData.Construct(4, 0, "3"),
        }),

        new StageData(2, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, "1"),
            TDTileData.Construct(1, 2, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(3, 2, "MAP"),
            TDTileData.Construct(4, 2, WhiteData.Eye, Species.Devil, 2),
            TDTileData.Construct(5, 2, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(6, 2, "2"),
            TDTileData.Construct(0, 1, "GARO"),
            TDTileData.Construct(1, 1, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(3, 1, "ANGEL"),
            TDTileData.Construct(5, 1, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(6, 1, "SERO"),
            TDTileData.Construct(0, 0, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 0, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(3, 0, "2"),
            TDTileData.Construct(5, 0, WhiteData.Gate, Species.Devil, 3),
            TDTileData.Construct(6, 0, "EXIT"),
        }),

        new StageData(2, 6, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(2, 3, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(3, 3, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(4, 3, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(0, 2, "MAP"),
            TDTileData.Construct(2, 2, "WHITE"),
            TDTileData.Construct(3, 2, "1"),
            TDTileData.Construct(4, 2, "EXIT"),
            TDTileData.Construct(0, 1, "0"),
            TDTileData.Construct(2, 1, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(3, 1, "ANGEL", true),
            TDTileData.Construct(4, 1, "2"),
            TDTileData.Construct(0, 0, "BLUE"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(3, 0, WhiteData.Eye, Species.Devil, 2),
            TDTileData.Construct(4, 0, "WHITE"),
        }),

        new StageData(3, 1, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(2, 2, "8"),
            TDTileData.Construct(3, 2, "8"),
            TDTileData.Construct(4, 2, "8"),
            TDTileData.Construct(0, 1, "GREEN"),
            TDTileData.Construct(2, 1, "8"),
            TDTileData.Construct(3, 1, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(4, 1, "8"),
            TDTileData.Construct(0, 0, "8"),
            TDTileData.Construct(1, 0, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 0, "8"),
            TDTileData.Construct(3, 0, "8"),
            TDTileData.Construct(4, 0, "8"),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "EXIT"),
        }),

        new StageData(3, 2, new List<TDTileData>
        {
            TDTileData.Construct(1, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(1, 2, "EXIT"),
            TDTileData.Construct(2, 2, "ANGEL"),
            TDTileData.Construct(3, 2, "0"),
            TDTileData.Construct(4, 2, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(0, 1, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(5, 1, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(1, 0, "MAP"),
            TDTileData.Construct(2, 0, "RED"),
            TDTileData.Construct(3, 0, "2"),
            TDTileData.Construct(4, 0, WhiteData.Eye, Species.Angel, 1),
        }, new List<TDTileData> 
        {
            TDTileData.Construct(-1, -1, "RED", false, true),
        }),

        new StageData(3, 3, new List<TDTileData>
        {
            TDTileData.Construct(1, 4, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(2, 4, WhiteData.Gate, Species.Devil, 1),
            TDTileData.Construct(0, 3, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(1, 3, "EXIT"),
            TDTileData.Construct(2, 3, "MAP"),
            TDTileData.Construct(3, 3, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(4, 3, "GARO"),
            TDTileData.Construct(0, 2, WhiteData.Gate, Species.Devil, 3),
            TDTileData.Construct(1, 2, "1"),
            TDTileData.Construct(4, 2, "2"),
            TDTileData.Construct(5, 2, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(1, 1, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(2, 1, "2"),
            TDTileData.Construct(5, 1, "1"),
            TDTileData.Construct(2, 0, "ANGEL"),
            TDTileData.Construct(3, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(4, 0, "MAP"),
            TDTileData.Construct(5, 0, "EXIT"),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "EXIT", false, true),
            TDTileData.Construct(-1, -1, "SERO", false, true),
            TDTileData.Construct(-1, -1, "2", false, true),
        }),

        new StageData(3, 4, new List<TDTileData>
        {
            TDTileData.Construct(3, 4, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(1, 3, "1"),
            TDTileData.Construct(3, 3, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(5, 3, "2"),
            TDTileData.Construct(1, 2, "DEVIL"),
            TDTileData.Construct(5, 2, "RED"),
            TDTileData.Construct(0, 1, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(1, 1, "MAP"),
            TDTileData.Construct(2, 1, "EXIT", false, false, 0),
            TDTileData.Construct(3, 1, WhiteData.Eye, Species.Angel, 1),
            TDTileData.Construct(4, 1, "EXIT", false, false, 0),
            TDTileData.Construct(5, 1, "EXIT"),
            TDTileData.Construct(6, 1, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(3, 0, WhiteData.Gate, Species.Devil, 2),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "EXIT", false, true),
            TDTileData.Construct(-1, -1, "MAP", false, true),
        }),

        new StageData(3, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 4, WhiteData.Eye, Species.Devil, 0),
            TDTileData.Construct(1, 4, "0", false, false, 0),
            TDTileData.Construct(2, 4, "MAP"),
            TDTileData.Construct(3, 4, "ANGEL", false, false, 0),
            TDTileData.Construct(4, 4, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(0, 3, "ANGEL"),
            TDTileData.Construct(4, 3, "1"),
            TDTileData.Construct(0, 2, "ANGEL", false, false, 0),
            TDTileData.Construct(2, 2, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(4, 2, "0", false, false, 0),
            TDTileData.Construct(6, 2, WhiteData.Gate, Species.Angel, 0),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(4, 1, "2"),
            TDTileData.Construct(0, 0, WhiteData.Null, Species.Null, 0),
            TDTileData.Construct(1, 0, "0", false, false, 0),
            TDTileData.Construct(2, 0, "MAP"),
            TDTileData.Construct(3, 0, "ANGEL", false, false, 0),
            TDTileData.Construct(4, 0, WhiteData.Eye, Species.Devil, 2),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, WhiteData.Null, Species.Null, 0, false, true),
        }),

        new StageData(3, 6, new List<TDTileData>
        {
            TDTileData.Construct(1, 5, WhiteData.Gate, Species.Devil, 0),
            TDTileData.Construct(3, 5, WhiteData.Gate, Species.Angel, 1),
            TDTileData.Construct(0, 4, "EXIT"),
            TDTileData.Construct(2, 4, "RED"),
            TDTileData.Construct(4, 4, "1"),
            TDTileData.Construct(1, 3, WhiteData.Gate, Species.Devil, 2),
            TDTileData.Construct(2, 3, "RED", false, false, 0),
            TDTileData.Construct(3, 3, WhiteData.Gate, Species.Devil, 3),
            TDTileData.Construct(0, 2, WhiteData.Eye, Species.Angel, 0),
            TDTileData.Construct(2, 2, WhiteData.Eye, Species.Devil, 1),
            TDTileData.Construct(4, 2, WhiteData.Eye, Species.Angel, 2),
            TDTileData.Construct(0, 0, "MAP"),
            TDTileData.Construct(1, 0, "ANGEL"),
            TDTileData.Construct(2, 0, WhiteData.Null, Species.Null, 1),
            TDTileData.Construct(3, 0, "DEVIL"),
            TDTileData.Construct(4, 0, "MAP"),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "WHITE", true, true),
            TDTileData.Construct(-1, -1, "0", true, true),
        }),
    };
}
