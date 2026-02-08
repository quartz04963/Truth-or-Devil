using System.Collections.Generic;
using UnityEngine;
using Cysharp.Text;
using System.CodeDom;

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

public static class MyUtils
{
    public static Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    public static List<int> RedDataNull = new List<int>{(int)RedData.Null};
    public static List<int> BlueDataNull = new List<int>{(int)BlueData.Null, 0};
    public static List<int> GreenDataNull = new List<int>{(int)GreenData.Null, 0};

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

    public static string ConvertToRoman(int num)
    {        
        switch (num)
        {
            case 1: return "I";
            case 2: return "II";
            case 3: return "III";
            case 4: return "IV";
            case 5: return "V";
            case 6: return "VI";
            case 7: return "VII";
            case 8: return "VIII";
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
            case "0" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 0});
            case "1" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 1});
            case "2" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 2});
            case "3" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 3});
            case "4" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 4});
            case "5" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 5});
            case "6" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 6});
            case "7" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 7});
            case "8" : return new TDData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 8});
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
}
