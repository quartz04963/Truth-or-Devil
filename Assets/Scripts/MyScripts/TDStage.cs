using System.Collections.Generic;

public readonly struct TDStage
{
    public const int Ch1StageCount = 13;
    public const int Ch2StageCount = 7;
    public const int Ch3StageCount = 0;
    public static List<TDData>[] stageList = new List<TDData>[Ch1StageCount + Ch2StageCount + Ch3StageCount];

    static TDStage()
    {
        //챕터 1
        stageList[0] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 1, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(4, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(0, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 0, "GATE"),
            MyUtils.ConstructTDData(2, 0, "RED"),
            MyUtils.ConstructTDData(3, 0, "1"),
            MyUtils.ConstructTDData(4, 0, WhiteData.Eye, ToD.Truth, 0),
        };

        stageList[1] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 2, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(1, 2, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(2, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(0, 1, "1"),
            MyUtils.ConstructTDData(1, 1, "GATE"),
            MyUtils.ConstructTDData(2, 1, "WHITE"),
            MyUtils.ConstructTDData(0, 0, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTDData(1, 0, "GREEN"),
            MyUtils.ConstructTDData(2, 0, WhiteData.Eye, ToD.Devil, 0),
        };

        stageList[2] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 2, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(2, 2, "1"),
            MyUtils.ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 1, "BLUE"),
            MyUtils.ConstructTDData(2, 1, "RED"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(4, 1, "8"),
            MyUtils.ConstructTDData(1, 0, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(2, 0, "GATE"),
        };

        stageList[3] = new List<TDData>
        {
            MyUtils.ConstructTDData(2, 3, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(1, 2, "WHITE"),
            MyUtils.ConstructTDData(2, 2, "GATE"),
            MyUtils.ConstructTDData(3, 2, "RED"),
            MyUtils.ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 1, "1"),
            MyUtils.ConstructTDData(2, 1, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(3, 1, "2"),
            MyUtils.ConstructTDData(4, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(2, 0, WhiteData.Gate, ToD.Devil, 2),
        };

        stageList[4] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 2, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(2, 2, "BLUE"),
            MyUtils.ConstructTDData(3, 2, "0"),
            MyUtils.ConstructTDData(4, 2, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(0, 1, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(1, 1, "GATE"),
            MyUtils.ConstructTDData(2, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(3, 1, "GATE"),
            MyUtils.ConstructTDData(4, 1, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTDData(0, 0, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(1, 0, "RED"),
            MyUtils.ConstructTDData(2, 0, "1"),
            MyUtils.ConstructTDData(3, 0, WhiteData.Blank, ToD.Null, 0),
        };

        stageList[5] = new List<TDData>
        {
            MyUtils.ConstructTDData(2, 4, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(0, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(1, 3, "GATE"),
            MyUtils.ConstructTDData(2, 3, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(3, 3, "GATE"),
            MyUtils.ConstructTDData(0, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(1, 2, "GREEN"),
            MyUtils.ConstructTDData(2, 2, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTDData(3, 2, "WHITE"),
            MyUtils.ConstructTDData(0, 1, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTDData(1, 1, "3"),
            MyUtils.ConstructTDData(2, 1, "2"),
            MyUtils.ConstructTDData(3, 1, "1"),
            MyUtils.ConstructTDData(0, 0, WhiteData.Gate, ToD.Devil, 4),
            MyUtils.ConstructTDData(1, 0, "1"),
            MyUtils.ConstructTDData(2, 0, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTDData(3, 0, "1"),
        };

        stageList[6] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 4, "GATE"),
            MyUtils.ConstructTDData(1, 4, "BLUE"),
            MyUtils.ConstructTDData(2, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(0, 3, "WHITE"),
            MyUtils.ConstructTDData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(2, 3, "2"),
            MyUtils.ConstructTDData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(0, 2, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(1, 2, "1"),
            MyUtils.ConstructTDData(2, 2, "GREEN"),
            MyUtils.ConstructTDData(3, 2, "1"),
            MyUtils.ConstructTDData(4, 2, "RED"),
            MyUtils.ConstructTDData(1, 1, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(2, 1, "1"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTDData(4, 1, WhiteData.Gate, ToD.Truth, 3),
            MyUtils.ConstructTDData(2, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 4),
        };

        stageList[7] = new List<TDData>
        {
            MyUtils.ConstructTDData(3, 3, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(0, 2, "1"),
            MyUtils.ConstructTDData(1, 2, "MAP"),
            MyUtils.ConstructTDData(2, 2, "DEVIL"),
            MyUtils.ConstructTDData(3, 2, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTDData(4, 2, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 1, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(2, 1, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(3, 1, "GATE"),
            MyUtils.ConstructTDData(2, 0, "1"),
            MyUtils.ConstructTDData(3, 0, "RED"),
        };

        stageList[8] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 2, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(2, 2, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(3, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 1, "MAP"),
            MyUtils.ConstructTDData(2, 1, "ANGEL"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(1, 0, "GATE"),
            MyUtils.ConstructTDData(2, 0, "1"),
            MyUtils.ConstructTDData(3, 0, "RED"),
        };

        stageList[9] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 3, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(2, 3, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTDData(0, 2, "0"),
            MyUtils.ConstructTDData(1, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(2, 2, WhiteData.Blank, ToD.Null, 0),
            MyUtils.ConstructTDData(3, 2, "2"),
            MyUtils.ConstructTDData(0, 1, "RED"),
            MyUtils.ConstructTDData(1, 1, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTDData(2, 1, "BLUE"),
            MyUtils.ConstructTDData(3, 1, "DEVIL"),
            MyUtils.ConstructTDData(0, 0, "GATE"),
            MyUtils.ConstructTDData(1, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(2, 0, WhiteData.Blank, ToD.Null, 0),
            MyUtils.ConstructTDData(3, 0, "MAP"),
        };

        stageList[10] = new List<TDData>
        {
            MyUtils.ConstructTDData(2, 4, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(4, 4, "0"),
            MyUtils.ConstructTDData(0, 3, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 3, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(2, 3, "MAP"),
            MyUtils.ConstructTDData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(4, 3, "GREEN"),
            MyUtils.ConstructTDData(0, 2, "1"),
            MyUtils.ConstructTDData(1, 2, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTDData(2, 2, "DEVIL"),
            MyUtils.ConstructTDData(3, 2, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTDData(4, 2, "GATE"),
            MyUtils.ConstructTDData(0, 1, "WHITE"),
            MyUtils.ConstructTDData(1, 1, WhiteData.Gate, ToD.Devil, 4),
            MyUtils.ConstructTDData(2, 1, "1"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(4, 1, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTDData(0, 0, "GATE"),
        };

        stageList[11] = new List<TDData>
        {
            MyUtils.ConstructTDData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(4, 3, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(0, 2, "2"),
            MyUtils.ConstructTDData(1, 2, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(2, 2, "0"),
            MyUtils.ConstructTDData(3, 2, WhiteData.Gate, ToD.Truth, 1),
            MyUtils.ConstructTDData(4, 2, "2"),
            MyUtils.ConstructTDData(0, 1, "MAP"),
            MyUtils.ConstructTDData(1, 1, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(2, 1, "MAP"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(4, 1, "GATE"),
            MyUtils.ConstructTDData(0, 0, "ANGEL"),
            MyUtils.ConstructTDData(1, 0, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTDData(2, 0, "GREEN"),
            MyUtils.ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTDData(4, 0, "BLUE"),
        };

        stageList[12] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 4, "2"),
            MyUtils.ConstructTDData(2, 4, "DEVIL"),
            MyUtils.ConstructTDData(3, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(4, 4, "DEVIL"),
            MyUtils.ConstructTDData(5, 4, "RED"),
            MyUtils.ConstructTDData(1, 3, "ANGEL"),
            MyUtils.ConstructTDData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(3, 3, "MAP"),
            MyUtils.ConstructTDData(4, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(5, 3, "GREEN"),
            MyUtils.ConstructTDData(0, 2, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 2, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTDData(2, 2, "GATE"),
            MyUtils.ConstructTDData(4, 2, "GATE"),
            MyUtils.ConstructTDData(5, 2, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTDData(1, 1, "2"),
            MyUtils.ConstructTDData(2, 1, WhiteData.Gate, ToD.Truth, 2),
            MyUtils.ConstructTDData(4, 1, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTDData(5, 1, "1"),
            MyUtils.ConstructTDData(1, 0, "BLUE"),
            MyUtils.ConstructTDData(2, 0, "2"),
            MyUtils.ConstructTDData(3, 0, WhiteData.Eye, ToD.Devil, 3),
            MyUtils.ConstructTDData(4, 0, "3"),
            MyUtils.ConstructTDData(5, 0, "2"),
        };

        //챕터 2
        stageList[Ch1StageCount + 0] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 3, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(0, 2, "MAP"),
            MyUtils.ConstructTDData(1, 2, "GATE"),
            MyUtils.ConstructTDData(0, 1, "ANGEL"),
            MyUtils.ConstructTDData(1, 1, "RED"),
            MyUtils.ConstructTDData(0, 0, "2"),
            MyUtils.ConstructTDData(1, 0, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(2, 0, WhiteData.Gate, ToD.Truth, 1),    
        };

        stageList[Ch1StageCount + 1] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 3, "MAP"),
            MyUtils.ConstructTDData(1, 3, "DEVIL"),
            MyUtils.ConstructTDData(2, 3, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(3, 3, "RED"),
            MyUtils.ConstructTDData(4, 3, "MAP"),
            MyUtils.ConstructTDData(0, 2, "GREEN"),
            MyUtils.ConstructTDData(1, 2, "1"),
            MyUtils.ConstructTDData(2, 2, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(3, 2, "0"),
            MyUtils.ConstructTDData(4, 2, "ANGEL"),
            MyUtils.ConstructTDData(0, 1, WhiteData.Eye, ToD.Truth, 0),
            MyUtils.ConstructTDData(1, 1, "GATE"),
            MyUtils.ConstructTDData(2, 1, "2"),
            MyUtils.ConstructTDData(3, 1, "GATE"),
            MyUtils.ConstructTDData(4, 1, WhiteData.Eye, ToD.Devil, 1),
            MyUtils.ConstructTDData(2, 0, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(4, 0, WhiteData.Gate, ToD.Devil, 3),
        };

        stageList[Ch1StageCount + 2] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 4, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(2, 4, "2"),
            MyUtils.ConstructTDData(3, 4, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(1, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(2, 3, "WHITE"),
            MyUtils.ConstructTDData(3, 3, "GATE"),
            MyUtils.ConstructTDData(1, 2, "MAP"),
            MyUtils.ConstructTDData(2, 2, "ANGEL"),
            MyUtils.ConstructTDData(3, 2, "1"),
            MyUtils.ConstructTDData(4, 2, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(0, 1, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTDData(1, 1, "0"),
            MyUtils.ConstructTDData(2, 1, "BLUE"),
            MyUtils.ConstructTDData(3, 1, "GATE"),
            MyUtils.ConstructTDData(4, 1, "3"),
            MyUtils.ConstructTDData(0, 0, "MAP"),
            MyUtils.ConstructTDData(1, 0, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(2, 0, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(3, 0, WhiteData.Eye, ToD.Truth, 2),
            MyUtils.ConstructTDData(4, 0, "DEVIL"),
        };

        stageList[Ch1StageCount + 3] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 5, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(2, 5, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(1, 4, "0"),
            MyUtils.ConstructTDData(2, 4, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(3, 4, "MAP"),
            MyUtils.ConstructTDData(4, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(1, 3, "GATE"),
            MyUtils.ConstructTDData(2, 3, "1"),
            MyUtils.ConstructTDData(3, 3, "3"),
            MyUtils.ConstructTDData(4, 3, "GATE"),
            MyUtils.ConstructTDData(1, 2, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(2, 2, "MAP"),
            MyUtils.ConstructTDData(3, 2, "ANGEL"),
            MyUtils.ConstructTDData(4, 2, "2"),
            MyUtils.ConstructTDData(0, 1, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTDData(1, 1, "RED"),
            MyUtils.ConstructTDData(2, 1, "BLUE"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(4, 1, "DEVIL"),
            MyUtils.ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 3),
            MyUtils.ConstructTDData(4, 0, WhiteData.Eye, ToD.Truth, 3),
        };

        stageList[Ch1StageCount + 4] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 3, WhiteData.Gate, ToD.Truth, 0),
            MyUtils.ConstructTDData(1, 3, "RED"),
            MyUtils.ConstructTDData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(1, 2, "GATE"),
            MyUtils.ConstructTDData(2, 2, "8"),
            MyUtils.ConstructTDData(3, 2, "BLUE"),
            MyUtils.ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 1, "1"),
            MyUtils.ConstructTDData(2, 1, "GATE"),
            MyUtils.ConstructTDData(2, 0, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 2),
        };

        stageList[Ch1StageCount + 5] = new List<TDData>
        {
            MyUtils.ConstructTDData(0, 2, "GREEN"),
            MyUtils.ConstructTDData(1, 2, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(2, 2, "1"),
            MyUtils.ConstructTDData(3, 2, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(0, 1, WhiteData.Gate, ToD.Truth, 1),
            MyUtils.ConstructTDData(1, 1, "BLUE"),
            MyUtils.ConstructTDData(2, 1, "GATE"),
            MyUtils.ConstructTDData(3, 1, "0"),
            MyUtils.ConstructTDData(1, 0, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(2, 0, "RED"),
            MyUtils.ConstructTDData(3, 0, WhiteData.Blank, ToD.Null, 1),
        };

        stageList[Ch1StageCount + 6] = new List<TDData>
        {
            MyUtils.ConstructTDData(1, 5, WhiteData.Gate, ToD.Devil, 0),
            MyUtils.ConstructTDData(0, 4, WhiteData.Blank, ToD.Null, 1),
            MyUtils.ConstructTDData(1, 4, "2"),
            MyUtils.ConstructTDData(2, 4, WhiteData.Gate, ToD.Devil, 1),
            MyUtils.ConstructTDData(3, 4, "1"),
            MyUtils.ConstructTDData(4, 4, WhiteData.Eye, ToD.Devil, 0),
            MyUtils.ConstructTDData(0, 3, "1"),
            MyUtils.ConstructTDData(1, 3, "DEVIL"),
            MyUtils.ConstructTDData(2, 3, WhiteData.Eye, ToD.Truth, 1),
            MyUtils.ConstructTDData(3, 3, "2"),
            MyUtils.ConstructTDData(4, 3, "WHITE"),
            MyUtils.ConstructTDData(0, 2, WhiteData.Gate, ToD.Devil, 2),
            MyUtils.ConstructTDData(1, 2, "BLUE"),
            MyUtils.ConstructTDData(2, 2, "GATE"),
            MyUtils.ConstructTDData(3, 2, WhiteData.Gate, ToD.Truth, 3),
            MyUtils.ConstructTDData(4, 2, WhiteData.Gate, ToD.Devil, 4),
            MyUtils.ConstructTDData(0, 1, "1"),
            MyUtils.ConstructTDData(1, 1, "GREEN"),
            MyUtils.ConstructTDData(2, 1, "2"),
            MyUtils.ConstructTDData(3, 1, WhiteData.Eye, ToD.Devil, 2),
            MyUtils.ConstructTDData(4, 1, "RED"),
            MyUtils.ConstructTDData(5, 1, WhiteData.Gate, ToD.Devil, 5),
            MyUtils.ConstructTDData(0, 0, "RED"),
            MyUtils.ConstructTDData(1, 0, "0"),
            MyUtils.ConstructTDData(2, 0, WhiteData.Gate, ToD.Devil, 6),
            MyUtils.ConstructTDData(3, 0, "ANGEL"),
            MyUtils.ConstructTDData(4, 0, "MAP"),
        };
    }
}
