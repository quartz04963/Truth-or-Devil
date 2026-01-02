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
    public static List<TDData>[] stageList = new List<TDData>[10];
    
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

    public void InitStageList()
    {
        stageList[0] = new List<TDData>{
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Truth, 1})
        };

        stageList[1] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 2}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Green}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Truth, 1}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
        };

        stageList[2] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Truth, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
        };

        stageList[3] = new List<TDData>
        {
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Blue}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 0}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(6, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
            new TDData(new Vector3Int(2, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 1}),
            new TDData(new Vector3Int(3, 2, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(4, 2, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(5, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 0}), 
        };

        stageList[4] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 2}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 3}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(6, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Truth, 3}),
            new TDData(new Vector3Int(2, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 4}),
            new TDData(new Vector3Int(3, 2, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 2}),
            new TDData(new Vector3Int(4, 2, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
            new TDData(new Vector3Int(5, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(6, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 5}),
        };

        stageList[8] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new List<int>{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 2}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 0}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.Green, new List<int>{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.Blue, new List<int>{(int)BlueData.Eye, (int)ToD.Truth}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 2}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 1}),
            new TDData(new Vector3Int(6, 3, 0), TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(2, 2, 0), TileColor.Red, new List<int>{(int)RedData.Map}),
            new TDData(new Vector3Int(3, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Eye, (int)ToD.Truth, 2}),
            new TDData(new Vector3Int(4, 2, 0), TileColor.Red, new List<int>{(int)RedData.Map}),
            new TDData(new Vector3Int(5, 2, 0), TileColor.White, new List<int>{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
            new TDData(new Vector3Int(6, 2, 0), TileColor.Red, new List<int>{(int)RedData.Gate}),
        };
    }
}
