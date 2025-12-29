using System.Collections.Generic;
using UnityEngine;

using TileData = System.Collections.Generic.List<int>;

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
    public static TileData RedDataNull = new TileData{(int)RedData.Null};
    public static TileData BlueDataNull = new TileData{(int)BlueData.Null, 0};
    public static TileData GreenDataNull = new TileData{(int)GreenData.Null, 0};
    public static List<TDData>[] stageList = new List<TDData>[10];

    void Awake()
    {
        InitStageList();
    }

    public static string GetTextFromData(TileColor color, TileData data)
    {
        switch (color)
        {
            case TileColor.Red: 
                switch (data[0]) {
                    case (int)RedData.Null: return "";
                    case (int)RedData.Gate: return "GATE";
                    case (int)RedData.Map: return "MAP";
                    default: return "Error";
                }

            case TileColor.Blue: 
                switch (data[0])
                {
                    case (int)BlueData.Null: return "";
                    case (int)BlueData.Color:
                        switch (data[1])
                        {
                            case (int)TileColor.Red: return "RED";
                            case (int)TileColor.Blue: return "BLUE";
                            case (int)TileColor.Green: return "GREEN";
                            case (int)TileColor.White: return "WHITE";
                            default: return "Error";
                        }
                    case (int)BlueData.Eye:
                        switch (data[1])
                        {
                            case (int)ToD.Truth: return "ANGEL";
                            case (int)ToD.Devil: return "DEVIL";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            
            case TileColor.Green: 
                switch (data[0])
                {
                    case (int)GreenData.Null: return "";
                    case (int)GreenData.Equal: return "" + data[1];
                    case (int)GreenData.NotEqual: return "!= " + data[1];
                    case (int)GreenData.Greater: return "> " + data[1];
                    case (int)GreenData.Less: return "< " + data[1];
                    case (int)GreenData.GreaterOrEqual: return ">= " + data[1];
                    case (int)GreenData.LessOrEqual: return "<= " + data[1];
                    default: return "Error";
                }

            default: return "Error";
        }
    }

    public void InitStageList()
    {
        stageList[0] = new List<TDData>{
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new TileData{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new TileData{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.Red}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new TileData{(int)WhiteData.Eye, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Truth, 1})
        };

        stageList[1] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new TileData{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.Red, new TileData{(int)RedData.Gate}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 2}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.Green}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new TileData{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Truth, 1}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
        };

        stageList[2] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new TileData{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new TileData{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Red, new TileData{(int)RedData.Gate}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.Red}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.White, new TileData{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Truth, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
        };

        stageList[3] = new List<TDData>
        {
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.White, new TileData{(int)WhiteData.Blank, 1}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.Blue}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 0}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.White, new TileData{(int)WhiteData.Eye, (int)ToD.Truth, 0}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 1}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.Red, new TileData{(int)RedData.Gate}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.Red, new TileData{(int)RedData.Gate}),
            new TDData(new Vector3Int(6, 3, 0), TileColor.White, new TileData{(int)WhiteData.Gate, (int)ToD.Devil, 3}),
            new TDData(new Vector3Int(2, 2, 0), TileColor.White, new TileData{(int)WhiteData.Eye, (int)ToD.Truth, 1}),
            new TDData(new Vector3Int(3, 2, 0), TileColor.Blue, new TileData{(int)BlueData.Color, (int)TileColor.White}),
            new TDData(new Vector3Int(4, 2, 0), TileColor.Green, new TileData{(int)GreenData.Equal, 1}),
            new TDData(new Vector3Int(5, 2, 0), TileColor.White, new TileData{(int)WhiteData.Blank, 0}), 
        };
    }
}
