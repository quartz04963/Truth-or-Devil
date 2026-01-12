using System.Collections.Generic;
using UnityEngine;
using Cysharp.Text;

public enum TileColor
{
    Red = 0, Blue = 1, Green = 2, White = 3,
}

public enum ToD
{
    Null = 0, Truth = 1, Devil = 2
}

public enum RedData
{
    Null = 0, Gate = 1, Map = 2,
}

public enum BlueData
{
    Null = 0, Color = 1, Eye = 2,
}

public enum GreenData
{
    Null = 0, Equal = 1, NotEqual = 2, Greater = 3, Less = 4, GreaterOrEqual = 5, LessOrEqual = 6,
}

public enum WhiteData
{
    Blank = 0, Eye = 1, Gate = 2,
}

public class MyUtils : MonoBehaviour
{
    public static Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    public static List<int> RedDataNull = new List<int>{(int)RedData.Null};
    public static List<int> BlueDataNull = new List<int>{(int)BlueData.Null, 0};
    public static List<int> GreenDataNull = new List<int>{(int)GreenData.Null, 0};
    public static List<TDData>[] stageList = new List<TDData>[15];
    
    void Awake()
    {
        InitStageList();
    }

    public static Color GetColorFromTileColor(TileColor tileColor)
    {
        switch (tileColor)
        {
            case TileColor.Red: return Color.red;
            case TileColor.Blue: return Color.blue;
            case TileColor.Green: return Color.green;
            case TileColor.White: return Color.white;
            default: return Color.black;
        }
    }
    public static string GetTextFromData(TileColor color, List<int> data)
    {
        switch (color)
        {
            case TileColor.Red: 
                switch ((RedData)data[0]) {
                    case RedData.Null: return "";
                    case RedData.Gate: return "GATE";
                    case RedData.Map: return "MAP";
                    default: return "Error";
                }

            case TileColor.Blue: 
                switch ((BlueData)data[0])
                {
                    case BlueData.Null: return "";
                    case BlueData.Color:
                        switch ((TileColor)data[1])
                        {
                            case TileColor.Red: return "RED";
                            case TileColor.Blue: return "BLUE";
                            case TileColor.Green: return "GREEN";
                            case TileColor.White: return "WHITE";
                            default: return "Error";
                        }
                    case BlueData.Eye:
                        switch ((ToD)data[1])
                        {
                            case ToD.Truth: return "ANGEL";
                            case ToD.Devil: return "DEVIL";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            
            case TileColor.Green: 
                switch ((GreenData)data[0])
                {
                    case GreenData.Null: return "";
                    case GreenData.Equal: return ZString.Concat("", data[1]);
                    case GreenData.NotEqual: return ZString.Concat("!= ", data[1]);
                    case GreenData.Greater: return ZString.Concat("> ", data[1]);
                    case GreenData.Less: return ZString.Concat("< ", data[1]);
                    case GreenData.GreaterOrEqual: return ZString.Concat(">= ", data[1]);
                    case GreenData.LessOrEqual: return ZString.Concat("<= ", data[1]);
                    default: return "Error";
                }

            default: return "Error";
        }
    }

    public static TDData ConstructTDData(int x, int y, string str)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (str)
        {
            case "GATE": return new TDData(pos, TileColor.Red, new List<int>{(int)RedData.Gate});
            case "MAP": return new TDData(pos, TileColor.Red, new List<int>{(int)RedData.Map});
            case "RED": return new TDData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red});
            case "BLUE": return new TDData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Blue});
            case "GREEN": return new TDData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Green});
            case "WHITE": return new TDData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White});
            case "ANGEL": return new TDData(pos, TileColor.Blue, new List<int>{(int)BlueData.Eye, (int)ToD.Truth});
            case "DEVIL": return new TDData(pos, TileColor.Blue, new List<int>{(int)BlueData.Eye, (int)ToD.Devil});
            case "0" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 0});
            case "1" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1});
            case "2" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 2});
            case "3" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 3});
            case "4" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 4});
            case "5" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 5});
            case "6" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 6});
            case "7" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 7});
            case "8" : return new TDData(new Vector3Int(x, y, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 8});
            default: return new TDData(Vector3Int.zero, TileColor.Red, RedDataNull);
        }
    }

    public static TDData ConstructTDData(int x, int y, WhiteData whitedata, ToD toD, int index)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (whitedata)
        {
            case WhiteData.Blank: return new TDData(pos, TileColor.White, new List<int>{(int)WhiteData.Blank, index});
            case WhiteData.Eye: return new TDData(pos, TileColor.White, new List<int>{(int)WhiteData.Eye, (int)toD, index});
            case WhiteData.Gate: return new TDData(pos, TileColor.White, new List<int>{(int)WhiteData.Gate, (int)toD, index});
            default: return new TDData(Vector3Int.zero, TileColor.Red, RedDataNull);
        }
    }

    public void InitStageList()
    {
        stageList[0] = new List<TDData>
        {
            ConstructTDData(0, 2, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 2, "GATE"),
            ConstructTDData(2, 2, "RED"),
            ConstructTDData(3, 2, "1"),
            ConstructTDData(2, 1, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(3, 1, WhiteData.Eye, ToD.Devil, 0),
            ConstructTDData(3, 0, WhiteData.Gate, ToD.Truth, 1),
        };

        stageList[1] = new List<TDData>
        {
            ConstructTDData(0, 2, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 2, "1"),
            ConstructTDData(2, 2, "GATE"),
            ConstructTDData(3, 2, "WHITE"),
            ConstructTDData(0, 1, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(1, 1, "2"),
            ConstructTDData(2, 1, "GREEN"),
            ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 0),
            ConstructTDData(1, 0, WhiteData.Gate, ToD.Truth, 1),
            ConstructTDData(2, 0, WhiteData.Gate, ToD.Devil, 2),
            ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 3),
        };

        stageList[2] = new List<TDData>
        {
            ConstructTDData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(1, 2, "WHITE"),
            ConstructTDData(2, 2, "GATE"),
            ConstructTDData(3, 2, "GREEN"),
            ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 1, "1"),
            ConstructTDData(2, 1, WhiteData.Eye, ToD.Devil, 0),
            ConstructTDData(3, 1, "8"),
            ConstructTDData(4, 1, WhiteData.Gate, ToD.Truth, 1),
            ConstructTDData(2, 0, WhiteData.Gate, ToD.Devil, 2),    
        };

        stageList[3] = new List<TDData>
        {
            ConstructTDData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(1, 2, "GATE"),
            ConstructTDData(2, 2, WhiteData.Eye, ToD.Truth, 0),
            ConstructTDData(3, 2, "GATE"),
            ConstructTDData(0, 1, "1"),
            ConstructTDData(1, 1, "WHITE"),
            ConstructTDData(2, 1, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(3, 1, "BLUE"),
            ConstructTDData(4, 1, "0"),
            ConstructTDData(0, 0, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 0, WhiteData.Blank, ToD.Null, 0),
            ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 2),
            ConstructTDData(4, 0, WhiteData.Gate, ToD.Truth, 3),
        };

        stageList[4] = new List<TDData>
        {
            ConstructTDData(1, 2, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(2, 2, "BLUE"),
            ConstructTDData(3, 2, "0"),
            ConstructTDData(4, 2, WhiteData.Eye, ToD.Truth, 0),
            ConstructTDData(0, 1, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(1, 1, "GATE"),
            ConstructTDData(2, 1, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(3, 1, "GATE"),
            ConstructTDData(4, 1, WhiteData.Gate, ToD.Truth, 2),
            ConstructTDData(0, 0, WhiteData.Eye, ToD.Truth, 1),
            ConstructTDData(1, 0, "RED"),
            ConstructTDData(2, 0, "1"),
            ConstructTDData(3, 0, WhiteData.Blank, ToD.Null, 0),
        };

        stageList[5] = new List<TDData>
        {
            ConstructTDData(2, 4, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(0, 3, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(1, 3, "GATE"),
            ConstructTDData(2, 3, WhiteData.Eye, ToD.Truth, 0),
            ConstructTDData(3, 3, "GATE"),
            ConstructTDData(0, 2, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(1, 2, "GREEN"),
            ConstructTDData(2, 2, WhiteData.Gate, ToD.Truth, 2),
            ConstructTDData(3, 2, "WHITE"),
            ConstructTDData(0, 1, WhiteData.Gate, ToD.Devil, 3),
            ConstructTDData(1, 1, "3"),
            ConstructTDData(2, 1, "2"),
            ConstructTDData(3, 1, "1"),
            ConstructTDData(0, 0, WhiteData.Gate, ToD.Devil, 4),
            ConstructTDData(1, 0, "1"),
            ConstructTDData(2, 0, WhiteData.Eye, ToD.Devil, 1),
            ConstructTDData(3, 0, "1"),
        };

        stageList[6] = new List<TDData>
        {
            ConstructTDData(0, 4, "GATE"),
            ConstructTDData(1, 4, "BLUE"),
            ConstructTDData(2, 4, WhiteData.Eye, ToD.Devil, 0),
            ConstructTDData(0, 3, "WHITE"),
            ConstructTDData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(2, 3, "2"),
            ConstructTDData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(0, 2, WhiteData.Eye, ToD.Truth, 1),
            ConstructTDData(1, 2, "1"),
            ConstructTDData(2, 2, "GREEN"),
            ConstructTDData(3, 2, "1"),
            ConstructTDData(4, 2, "RED"),
            ConstructTDData(1, 1, WhiteData.Gate, ToD.Devil, 2),
            ConstructTDData(2, 1, "1"),
            ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 2),
            ConstructTDData(4, 1, WhiteData.Gate, ToD.Truth, 3),
            ConstructTDData(2, 0, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 4),
        };

        stageList[7] = new List<TDData>
        {
            ConstructTDData(1, 2, WhiteData.Gate, ToD.Truth, 0),
            ConstructTDData(2, 2, WhiteData.Eye, ToD.Devil, 0),
            ConstructTDData(3, 2, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(0, 1, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 1, "MAP"),
            ConstructTDData(2, 1, "ANGEL"),
            ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            ConstructTDData(1, 0, "GATE"),
            ConstructTDData(2, 0, "1"),
            ConstructTDData(3, 0, "RED"),
        };

        stageList[8] = new List<TDData>
        {
            ConstructTDData(0, 3, WhiteData.Eye, ToD.Truth, 0),
            ConstructTDData(1, 3, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(2, 3, WhiteData.Eye, ToD.Devil, 1),
            ConstructTDData(0, 2, "0"),
            ConstructTDData(1, 2, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(2, 2, WhiteData.Blank, ToD.Null, 0),
            ConstructTDData(3, 2, "2"),
            ConstructTDData(0, 1, "RED"),
            ConstructTDData(1, 1, WhiteData.Gate, ToD.Truth, 2),
            ConstructTDData(2, 1, "BLUE"),
            ConstructTDData(3, 1, "DEVIL"),
            ConstructTDData(0, 0, "GATE"),
            ConstructTDData(1, 0, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(2, 0, WhiteData.Blank, ToD.Null, 0),
            ConstructTDData(3, 0, "MAP"),
        };

        stageList[9] = new List<TDData>
        {
            ConstructTDData(2, 4, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(4, 4, "0"),
            ConstructTDData(0, 3, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 3, WhiteData.Eye, ToD.Truth, 0),
            ConstructTDData(2, 3, "MAP"),
            ConstructTDData(3, 3, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(4, 3, "GREEN"),
            ConstructTDData(0, 2, "1"),
            ConstructTDData(1, 2, WhiteData.Gate, ToD.Truth, 2),
            ConstructTDData(2, 2, "DEVIL"),
            ConstructTDData(3, 2, WhiteData.Gate, ToD.Devil, 3),
            ConstructTDData(4, 2, "GATE"),
            ConstructTDData(0, 1, "WHITE"),
            ConstructTDData(1, 1, WhiteData.Gate, ToD.Devil, 4),
            ConstructTDData(2, 1, "1"),
            ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            ConstructTDData(4, 1, WhiteData.Eye, ToD.Devil, 2),
            ConstructTDData(0, 0, "GATE"),
        };

        stageList[10] = new List<TDData>
        {
            ConstructTDData(2, 3, WhiteData.Gate, ToD.Truth, 0),
            ConstructTDData(4, 3, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(0, 2, "2"),
            ConstructTDData(1, 2, WhiteData.Eye, ToD.Devil, 0),
            ConstructTDData(2, 2, "0"),
            ConstructTDData(3, 2, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(4, 2, "2"),
            ConstructTDData(0, 1, "MAP"),
            ConstructTDData(1, 1, WhiteData.Gate, ToD.Devil, 2),
            ConstructTDData(2, 1, "MAP"),
            ConstructTDData(3, 1, WhiteData.Eye, ToD.Truth, 1),
            ConstructTDData(4, 1, "GATE"),
            ConstructTDData(0, 0, "ANGEL"),
            ConstructTDData(1, 0, WhiteData.Eye, ToD.Truth, 2),
            ConstructTDData(2, 0, "WHITE"),
            ConstructTDData(3, 0, WhiteData.Gate, ToD.Devil, 3),
            ConstructTDData(4, 0, "BLUE"),
        };

        stageList[11] = new List<TDData>
        {
            ConstructTDData(1, 4, "2"),
            ConstructTDData(2, 4, "DEVIL"),
            ConstructTDData(3, 4, WhiteData.Eye, ToD.Devil, 0),
            ConstructTDData(4, 4, "DEVIL"),
            ConstructTDData(5, 4, "RED"),
            ConstructTDData(1, 3, "ANGEL"),
            ConstructTDData(2, 3, WhiteData.Gate, ToD.Devil, 0),
            ConstructTDData(3, 3, "MAP"),
            ConstructTDData(4, 3, WhiteData.Gate, ToD.Devil, 1),
            ConstructTDData(5, 3, "GREEN"),
            ConstructTDData(0, 2, WhiteData.Blank, ToD.Null, 1),
            ConstructTDData(1, 2, WhiteData.Eye, ToD.Devil, 1),
            ConstructTDData(2, 2, "GATE"),
            ConstructTDData(4, 2, "GATE"),
            ConstructTDData(5, 2, WhiteData.Eye, ToD.Truth, 2),
            ConstructTDData(1, 1, "2"),
            ConstructTDData(2, 1, WhiteData.Gate, ToD.Truth, 2),
            ConstructTDData(4, 1, WhiteData.Gate, ToD.Devil, 3),
            ConstructTDData(5, 1, "1"),
            ConstructTDData(1, 0, "BLUE"),
            ConstructTDData(2, 0, "2"),
            ConstructTDData(3, 0, WhiteData.Eye, ToD.Devil, 3),
            ConstructTDData(4, 0, "3"),
            ConstructTDData(5, 0, "2"),
        };
    }
}
