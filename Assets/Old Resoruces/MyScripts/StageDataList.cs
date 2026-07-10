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

    public static List<TDStageData> stages = new List<TDStageData>()
    {
        new TDStageData(0, 1, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(2, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(2, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(4, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(1, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(2, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(4, 0, WhiteData.NULL, Species.NULL, 0),
        }),

        new TDStageData(0, 2, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, "EXIT"),
            TDTileData.Construct(2, 2, "8"),
            TDTileData.Construct(3, 2, "8"),
            TDTileData.Construct(4, 2, "8"),
            TDTileData.Construct(0, 1, "GREEN"),
            TDTileData.Construct(2, 1, "8"),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 1, "8"),
            TDTileData.Construct(0, 0, "8"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 0, "8"),
            TDTileData.Construct(3, 0, "8"),
            TDTileData.Construct(4, 0, "8"),
        }),

        new TDStageData(0, 3, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, "EXIT"),
            TDTileData.Construct(2, 2, "EXIT"),
            TDTileData.Construct(3, 2, "EXIT"),
            TDTileData.Construct(4, 2, "EXIT"),
            TDTileData.Construct(0, 1, "GREEN"),
            TDTileData.Construct(2, 1, "EXIT"),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 1, "EXIT"),
            TDTileData.Construct(0, 0, "8"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 0, "EXIT"),
            TDTileData.Construct(3, 0, "EXIT"),
            TDTileData.Construct(4, 0, "EXIT"),
        }),

        new TDStageData(0, 4, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, "WHITE"),
            TDTileData.Construct(2, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(4, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 1, "3"),
            TDTileData.Construct(2, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(4, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 0, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 0, "BLUE"),
            TDTileData.Construct(3, 0, "BLUE"),
            TDTileData.Construct(4, 0, "BLUE"),
        }),

        new TDStageData(0, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, "1"),
            TDTileData.Construct(2, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 1, "EXIT"),
            TDTileData.Construct(2, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(4, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 0, "GREEN"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 0, "8"),
            TDTileData.Construct(4, 0, WhiteData.NULL, Species.NULL, 0),
        }),

        new TDStageData(0, 6, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(2, 2, "BLUE"),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(4, 2, "RED"),
            TDTileData.Construct(0, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(2, 1, "EXIT"),
            TDTileData.Construct(3, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(4, 1, "EXIT"),
            TDTileData.Construct(0, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 0, "2"),
            TDTileData.Construct(3, 0, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(4, 0, "8"),
        }),
        
        new TDStageData(1, 1, new List<TDTileData>
        {
            TDTileData.Construct(1, 2, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(3, 2, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(0, 1, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(1, 1, "GARO"),
            TDTileData.Construct(2, 1, "2"),
            TDTileData.Construct(3, 1, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(2, 0, "3"),
            TDTileData.Construct(3, 0, WhiteData.GATE, Species.DEVIL, 2),
        }),

        new TDStageData(1, 2, new List<TDTileData>
        {
            TDTileData.Construct(1, 3, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(3, 3, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(0, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(1, 2, "GARO"),
            TDTileData.Construct(2, 2, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(3, 2, "2"),
            TDTileData.Construct(4, 2, WhiteData.GATE, Species.DEVIL, 3),
            TDTileData.Construct(1, 1, "EXIT"),
            TDTileData.Construct(3, 1, "1"),
            TDTileData.Construct(1, 0, "SERO"),
            TDTileData.Construct(2, 0, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(3, 0, "0"),
        }),

        new TDStageData(1, 3, new List<TDTileData>
        {
            TDTileData.Construct(1, 4, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(3, 4, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(0, 3, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(1, 3, "0"),
            TDTileData.Construct(2, 3, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 3, "2"),
            TDTileData.Construct(4, 3, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 2, "GARO"),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(4, 2, "SERO"),
            TDTileData.Construct(0, 1, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(1, 1, "EXIT"),
            TDTileData.Construct(2, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, "EXIT"),
            TDTileData.Construct(4, 1, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(1, 0, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(3, 0, WhiteData.NULL, Species.NULL, 0),
        }),

        new TDStageData(1, 4, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(1, 2, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(0, 1, "EXIT"),
            TDTileData.Construct(1, 1, "GARO", true),
            TDTileData.Construct(2, 1, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(0, 0, WhiteData.GATE, Species.ANGEL, 2),
            TDTileData.Construct(1, 0, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(2, 0, "2"),
        }),

        new TDStageData(1, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(1, 2, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(4, 2, "1"),
            TDTileData.Construct(5, 2, "EXIT"),
            TDTileData.Construct(1, 1, "GARO"),
            TDTileData.Construct(2, 1, "SERO"),
            TDTileData.Construct(3, 1, "1", true),
            TDTileData.Construct(4, 1, WhiteData.EYE, Species.ANGEL, 1),
            TDTileData.Construct(5, 1, "2"),
            TDTileData.Construct(0, 0, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(1, 0, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(2, 0, WhiteData.GATE, Species.ANGEL, 3),
            TDTileData.Construct(4, 0, "3"),
            TDTileData.Construct(5, 0, "EXIT"),
        }),

        new TDStageData(1, 6, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(1, 2, "EXIT"),
            TDTileData.Construct(3, 2, "EXIT"),
            TDTileData.Construct(4, 2, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(0, 1, "GARO"),
            TDTileData.Construct(1, 1, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 1, "2", true),
            TDTileData.Construct(3, 1, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(4, 1, "SERO"),
            TDTileData.Construct(0, 0, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(1, 0, "1"),
            TDTileData.Construct(2, 0, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(3, 0, "3"),
            TDTileData.Construct(4, 0, WhiteData.GATE, Species.ANGEL, 3),
        }),

        new TDStageData(2, 1, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, "MAP"),
            TDTileData.Construct(2, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(2, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(4, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 0, "3"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 0, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(3, 0, WhiteData.EYE, Species.DEVIL, 2),
            TDTileData.Construct(4, 0, WhiteData.EYE, Species.DEVIL, 3),
        }),

        new TDStageData(2, 2, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 2, "MAP"),
            TDTileData.Construct(2, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 2, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(2, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(4, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(0, 0, "3"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 0, "1"),
            TDTileData.Construct(3, 0, "BLUE"),
            TDTileData.Construct(4, 0, "EXIT"),
        }),

        new TDStageData(2, 3, new List<TDTileData>
        {
            TDTileData.Construct(1, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(3, 3, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(1, 2, "MAP"),
            TDTileData.Construct(2, 2, "ANGEL"),
            TDTileData.Construct(3, 2, "1"),
            TDTileData.Construct(1, 1, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 1, WhiteData.EYE, Species.ANGEL, 1),
            TDTileData.Construct(0, 0, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(1, 0, "EXIT"),
            TDTileData.Construct(2, 0, "GREEN"),
            TDTileData.Construct(3, 0, "1"),
            TDTileData.Construct(4, 0, WhiteData.GATE, Species.ANGEL, 1),
        }),

        new TDStageData(2, 4, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(2, 3, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(4, 3, WhiteData.EYE, Species.ANGEL, 1),
            TDTileData.Construct(0, 2, "2"),
            TDTileData.Construct(2, 2, "1"),
            TDTileData.Construct(3, 2, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(2, 1, "GARO"),
            TDTileData.Construct(3, 1, "2"),
            TDTileData.Construct(4, 1, WhiteData.GATE, Species.ANGEL, 2),
            TDTileData.Construct(0, 0, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 0, "MAP"),
            TDTileData.Construct(3, 0, "GARO"),
            TDTileData.Construct(4, 0, "3"),
        }),

        new TDStageData(2, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 2, "1"),
            TDTileData.Construct(1, 2, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(3, 2, "MAP"),
            TDTileData.Construct(4, 2, WhiteData.EYE, Species.DEVIL, 2),
            TDTileData.Construct(5, 2, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(6, 2, "2"),
            TDTileData.Construct(0, 1, "GARO"),
            TDTileData.Construct(1, 1, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(3, 1, "ANGEL"),
            TDTileData.Construct(5, 1, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(6, 1, "SERO"),
            TDTileData.Construct(0, 0, "EXIT"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 0, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(3, 0, "2"),
            TDTileData.Construct(5, 0, WhiteData.GATE, Species.DEVIL, 3),
            TDTileData.Construct(6, 0, "EXIT"),
        }),

        new TDStageData(2, 6, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(2, 3, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(3, 3, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(4, 3, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(0, 2, "MAP"),
            TDTileData.Construct(2, 2, "WHITE"),
            TDTileData.Construct(3, 2, "1"),
            TDTileData.Construct(4, 2, "EXIT"),
            TDTileData.Construct(0, 1, "0"),
            TDTileData.Construct(2, 1, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(3, 1, "ANGEL", true),
            TDTileData.Construct(4, 1, "2"),
            TDTileData.Construct(0, 0, "BLUE"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(3, 0, WhiteData.EYE, Species.DEVIL, 2),
            TDTileData.Construct(4, 0, "WHITE"),
        }),

        new TDStageData(3, 1, new List<TDTileData>
        {
            TDTileData.Construct(0, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(2, 2, "8"),
            TDTileData.Construct(3, 2, "8"),
            TDTileData.Construct(4, 2, "8"),
            TDTileData.Construct(0, 1, "GREEN"),
            TDTileData.Construct(2, 1, "8"),
            TDTileData.Construct(3, 1, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(4, 1, "8"),
            TDTileData.Construct(0, 0, "8"),
            TDTileData.Construct(1, 0, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 0, "8"),
            TDTileData.Construct(3, 0, "8"),
            TDTileData.Construct(4, 0, "8"),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "EXIT"),
        }),

        new TDStageData(3, 2, new List<TDTileData>
        {
            TDTileData.Construct(1, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(1, 2, "EXIT"),
            TDTileData.Construct(2, 2, "ANGEL"),
            TDTileData.Construct(3, 2, "0"),
            TDTileData.Construct(4, 2, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(0, 1, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(5, 1, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(1, 0, "MAP"),
            TDTileData.Construct(2, 0, "RED"),
            TDTileData.Construct(3, 0, "2"),
            TDTileData.Construct(4, 0, WhiteData.EYE, Species.ANGEL, 1),
        }, new List<TDTileData> 
        {
            TDTileData.Construct(-1, -1, "RED", false, true),
        }),

        new TDStageData(3, 3, new List<TDTileData>
        {
            TDTileData.Construct(1, 4, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(2, 4, WhiteData.GATE, Species.DEVIL, 1),
            TDTileData.Construct(0, 3, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(1, 3, "EXIT"),
            TDTileData.Construct(2, 3, "MAP"),
            TDTileData.Construct(3, 3, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(4, 3, "GARO"),
            TDTileData.Construct(0, 2, WhiteData.GATE, Species.DEVIL, 3),
            TDTileData.Construct(1, 2, "1"),
            TDTileData.Construct(4, 2, "2"),
            TDTileData.Construct(5, 2, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(1, 1, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(2, 1, "2"),
            TDTileData.Construct(5, 1, "1"),
            TDTileData.Construct(2, 0, "ANGEL"),
            TDTileData.Construct(3, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(4, 0, "MAP"),
            TDTileData.Construct(5, 0, "EXIT"),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "EXIT", false, true),
            TDTileData.Construct(-1, -1, "SERO", false, true),
            TDTileData.Construct(-1, -1, "2", false, true),
        }),

        new TDStageData(3, 4, new List<TDTileData>
        {
            TDTileData.Construct(3, 4, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(1, 3, "1"),
            TDTileData.Construct(3, 3, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(5, 3, "2"),
            TDTileData.Construct(1, 2, "DEVIL"),
            TDTileData.Construct(5, 2, "RED"),
            TDTileData.Construct(0, 1, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(1, 1, "MAP"),
            TDTileData.Construct(2, 1, "EXIT", false, false, 0),
            TDTileData.Construct(3, 1, WhiteData.EYE, Species.ANGEL, 1),
            TDTileData.Construct(4, 1, "EXIT", false, false, 0),
            TDTileData.Construct(5, 1, "EXIT"),
            TDTileData.Construct(6, 1, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(3, 0, WhiteData.GATE, Species.DEVIL, 2),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "EXIT", false, true),
            TDTileData.Construct(-1, -1, "MAP", false, true),
        }),

        new TDStageData(3, 5, new List<TDTileData>
        {
            TDTileData.Construct(0, 4, WhiteData.EYE, Species.DEVIL, 0),
            TDTileData.Construct(1, 4, "0", false, false, 0),
            TDTileData.Construct(2, 4, "MAP"),
            TDTileData.Construct(3, 4, "ANGEL", false, false, 0),
            TDTileData.Construct(4, 4, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(0, 3, "ANGEL"),
            TDTileData.Construct(4, 3, "1"),
            TDTileData.Construct(0, 2, "ANGEL", false, false, 0),
            TDTileData.Construct(2, 2, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(4, 2, "0", false, false, 0),
            TDTileData.Construct(6, 2, WhiteData.GATE, Species.ANGEL, 0),
            TDTileData.Construct(0, 1, "DEVIL"),
            TDTileData.Construct(4, 1, "2"),
            TDTileData.Construct(0, 0, WhiteData.NULL, Species.NULL, 0),
            TDTileData.Construct(1, 0, "0", false, false, 0),
            TDTileData.Construct(2, 0, "MAP"),
            TDTileData.Construct(3, 0, "ANGEL", false, false, 0),
            TDTileData.Construct(4, 0, WhiteData.EYE, Species.DEVIL, 2),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, WhiteData.NULL, Species.NULL, 0, false, true),
        }),

        new TDStageData(3, 6, new List<TDTileData>
        {
            TDTileData.Construct(1, 5, WhiteData.GATE, Species.DEVIL, 0),
            TDTileData.Construct(3, 5, WhiteData.GATE, Species.ANGEL, 1),
            TDTileData.Construct(0, 4, "EXIT"),
            TDTileData.Construct(2, 4, "RED"),
            TDTileData.Construct(4, 4, "1"),
            TDTileData.Construct(1, 3, WhiteData.GATE, Species.DEVIL, 2),
            TDTileData.Construct(2, 3, "RED", false, false, 0),
            TDTileData.Construct(3, 3, WhiteData.GATE, Species.DEVIL, 3),
            TDTileData.Construct(0, 2, WhiteData.EYE, Species.ANGEL, 0),
            TDTileData.Construct(2, 2, WhiteData.EYE, Species.DEVIL, 1),
            TDTileData.Construct(4, 2, WhiteData.EYE, Species.ANGEL, 2),
            TDTileData.Construct(0, 0, "MAP"),
            TDTileData.Construct(1, 0, "ANGEL"),
            TDTileData.Construct(2, 0, WhiteData.NULL, Species.NULL, 1),
            TDTileData.Construct(3, 0, "DEVIL"),
            TDTileData.Construct(4, 0, "MAP"),
        }, new List<TDTileData>
        {
            TDTileData.Construct(-1, -1, "WHITE", true, true),
            TDTileData.Construct(-1, -1, "0", true, true),
        }),
    };
}
