using System.Collections.Generic;
using UnityEngine;

using TileData = System.Collections.Generic.List<int>;

public class TileColor
{
    public const int Red = 0;
    public const int Blue = 1;
    public const int Green = 2;
    public const int White = 3;
}

public class ToD
{
    public const int Null = 0;
    public const int Truth = 1;
    public const int Devil = 2;
}

public class RedData
{
    public static readonly TileData Default = new TileData{Null};
    public const int Null = 0;
    public const int Gate = 1;
    public const int Map = 2;
}

public class BlueData
{
    public static readonly TileData Default = new TileData{Null, 0};
    public const int Null = 0;
    public const int Color = 1;
    public const int Eye = 2;
}

public class GreenData
{
    public static readonly TileData Default = new TileData{Null, 0};
    public const int Null = 0;
    public const int Equal = 1;
    public const int NotEqual = 2;
    public const int Greater = 3;
    public const int Less = 4;
    public const int GreaterOrEqual = 5;
    public const int LessOrEqual = 6;
}

public class WhiteData
{
    public const int Blank = 0;
    public const int Eye = 1;
    public const int Gate = 2;
}

public class MyUtils : MonoBehaviour
{
    public static Vector3 offset = new Vector3(0.5f, 0.5f, 0);
    public static List<TDData>[] stageList = new List<TDData>[10];

    void Awake()
    {
        InitStageList();
    }

    public static string GetTextFromData(int color, TileData data)
    {
        switch (color)
        {
            case TileColor.Red: 
                switch (data[0]) {
                    case RedData.Null: return "";
                    case RedData.Gate: return "GATE";
                    case RedData.Map: return "MAP";
                    default: return "Error";
                }

            case TileColor.Blue: 
                switch (data[0])
                {
                    case BlueData.Null: return "";
                    case BlueData.Color:
                        switch (data[1])
                        {
                            case TileColor.Red: return "RED";
                            case TileColor.Blue: return "BLUE";
                            case TileColor.Green: return "GREEN";
                            case TileColor.White: return "WHITE";
                            default: return "Error";
                        }
                    case BlueData.Eye:
                        switch (data[1])
                        {
                            case ToD.Truth: return "ANGEL";
                            case ToD.Devil: return "DEVIL";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            
            case TileColor.Green: 
                switch (data[0])
                {
                    case GreenData.Null: return "";
                    case GreenData.Equal: return "" + data[1];
                    case GreenData.NotEqual: return "!= " + data[1];
                    case GreenData.Greater: return "> " + data[1];
                    case GreenData.Less: return "< " + data[1];
                    case GreenData.GreaterOrEqual: return ">= " + data[1];
                    case GreenData.LessOrEqual: return "<= " + data[1];
                    default: return "Error";
                }

            default: return "Error";
        }
    }

    public void InitStageList()
    {
        stageList[0] = new List<TDData>{
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new TileData{WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new TileData{RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.Red}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Green, new TileData{GreenData.Equal, 1}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 0}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new TileData{WhiteData.Eye, ToD.Devil, 0}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Truth, 1})
        };

        stageList[1] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new TileData{WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Green, new TileData{GreenData.Equal, 1}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.Red, new TileData{RedData.Gate}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.White}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Green, new TileData{GreenData.Equal, 2}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.Green}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.White, new TileData{WhiteData.Eye, ToD.Truth, 0}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Truth, 1}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 3}),
        };

        stageList[2] = new List<TDData>
        {
            new TDData(new Vector3Int(2, 5, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 0}),
            new TDData(new Vector3Int(3, 5, 0), TileColor.Red, new TileData{RedData.Gate}),
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new TileData{WhiteData.Eye, ToD.Truth, 0}),
            new TDData(new Vector3Int(5, 5, 0), TileColor.Red, new TileData{RedData.Gate}),
            new TDData(new Vector3Int(2, 4, 0), TileColor.Green, new TileData{GreenData.Equal, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.Red}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 1}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.White}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.Green, new TileData{GreenData.Equal, 1}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.White, new TileData{WhiteData.Blank, 1}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Truth, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 3}),
        };

        stageList[3] = new List<TDData>
        {
            new TDData(new Vector3Int(4, 5, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Truth, 0}),
            new TDData(new Vector3Int(3, 4, 0), TileColor.White, new TileData{WhiteData.Blank, 1}),
            new TDData(new Vector3Int(4, 4, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.Blue}),
            new TDData(new Vector3Int(5, 4, 0), TileColor.Green, new TileData{GreenData.Equal, 0}),
            new TDData(new Vector3Int(6, 4, 0), TileColor.White, new TileData{WhiteData.Eye, ToD.Truth, 0}),
            new TDData(new Vector3Int(2, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 1}),
            new TDData(new Vector3Int(3, 3, 0), TileColor.Red, new TileData{RedData.Gate}),
            new TDData(new Vector3Int(4, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 2}),
            new TDData(new Vector3Int(5, 3, 0), TileColor.Red, new TileData{RedData.Gate}),
            new TDData(new Vector3Int(6, 3, 0), TileColor.White, new TileData{WhiteData.Gate, ToD.Devil, 3}),
            new TDData(new Vector3Int(2, 2, 0), TileColor.White, new TileData{WhiteData.Eye, ToD.Truth, 1}),
            new TDData(new Vector3Int(3, 2, 0), TileColor.Blue, new TileData{BlueData.Color, TileColor.White}),
            new TDData(new Vector3Int(4, 2, 0), TileColor.Green, new TileData{GreenData.Equal, 1}),
            new TDData(new Vector3Int(5, 2, 0), TileColor.White, new TileData{WhiteData.Blank, 0}), 
        };
    }
}
