using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Text;


[Serializable]
public readonly struct TileData
{
    public static TileData Null = new TileData(Vector3Int.zero, TileColor.Null, new List<int>{0, 0, 0}, false, false, -1);

    public readonly Vector3Int pos;
    public readonly TileColor color;
    public readonly List<int> data;
    public readonly int stack;
    public readonly bool isHiding;
    public readonly bool isPlaceable;

    public TileData(Vector3Int pos, TileColor color, List<int> data, bool isHiding, bool isPlaceable, int stack)
    {
        this.pos = pos;
        this.color = color; 
        this.data = data;
        this.isHiding = isHiding;
        this.stack = stack;
        this.isPlaceable = isPlaceable;
    }

    public static TileData Construct(int x, int y, string str, bool isHiding = false, bool isPlaceable = false, int stack = -1)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (str)
        {
            case "EXIT": return new TileData(pos, TileColor.Red, new List<int>{(int)RedData.Exit}, isHiding, isPlaceable, stack);
            case "MAP": return new TileData(pos, TileColor.Red, new List<int>{(int)RedData.Map}, isHiding, isPlaceable, stack);
            case "RED": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red}, isHiding, isPlaceable, stack);
            case "BLUE": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Blue}, isHiding, isPlaceable, stack);
            case "GREEN": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Green}, isHiding, isPlaceable, stack);
            case "WHITE": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}, isHiding, isPlaceable, stack);
            case "GARO": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.GaroSero, (int)GaroSero.Garo}, isHiding, isPlaceable, stack);
            case "SERO": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.GaroSero, (int)GaroSero.Sero}, isHiding, isPlaceable, stack);
            case "ANGEL": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Eye, (int)ToD.Truth}, isHiding, isPlaceable, stack);
            case "DEVIL": return new TileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Eye, (int)ToD.Devil}, isHiding, isPlaceable, stack);
            case "0" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 0}, isHiding, isPlaceable, stack);
            case "1" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 1}, isHiding, isPlaceable, stack);
            case "2" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 2}, isHiding, isPlaceable, stack);
            case "3" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 3}, isHiding, isPlaceable, stack);
            case "4" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 4}, isHiding, isPlaceable, stack);
            case "5" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 5}, isHiding, isPlaceable, stack);
            case "6" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 6}, isHiding, isPlaceable, stack);
            case "7" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 7}, isHiding, isPlaceable, stack);
            case "8" : return new TileData(pos, TileColor.Green, new List<int>{(int)GreenData.Equal, 8}, isHiding, isPlaceable, stack);
            default: return Null;
        }
    }

    public static TileData Construct(int x, int y, WhiteData whitedata, ToD toD, int index, bool isHiding = false, bool isPlaceable = false, int count = -1)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (whitedata)
        {
            case WhiteData.Blank: return new TileData(pos, TileColor.White, new List<int>{(int)WhiteData.Blank, index}, isHiding, isPlaceable, count);
            case WhiteData.Eye: return new TileData(pos, TileColor.White, new List<int>{(int)WhiteData.Eye, (int)toD, index}, isHiding, false, count);
            case WhiteData.Gate: return new TileData(pos, TileColor.White, new List<int>{(int)WhiteData.Gate, (int)toD, index}, isHiding, false, count);
            default: return Null;
        }
    }

    public static string GetText(TileData tile)
    {
        if (tile.isHiding) return "???";

        switch (tile.color)
        {
            case TileColor.Red: 
                switch ((RedData)tile.data[0]) {
                    case RedData.Null: return "";
                    case RedData.Exit: return "EXIT";
                    case RedData.Map: return "MAP";
                    default: return "Error";
                }

            case TileColor.Blue: 
                switch ((BlueData)tile.data[0])
                {
                    case BlueData.Null: return "";
                    case BlueData.Color:
                        switch ((TileColor)tile.data[1])
                        {
                            case TileColor.Red: return "RED";
                            case TileColor.Blue: return "BLUE";
                            case TileColor.Green: return "GREEN";
                            case TileColor.White: return "WHITE";
                            default: return "Error";
                        }
                    case BlueData.GaroSero:
                        switch ((GaroSero)tile.data[1])
                        {
                            case GaroSero.Garo: return "GARO";
                            case GaroSero.Sero: return "SERO";
                            default: return "Error";
                        }
                    case BlueData.Eye:
                        switch ((ToD)tile.data[1])
                        {
                            case ToD.Truth: return "ANGEL";
                            case ToD.Devil: return "DEVIL";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            
            case TileColor.Green: 
                switch ((GreenData)tile.data[0])
                {
                    case GreenData.Null: return "";
                    case GreenData.Equal: return ZString.Concat("", tile.data[1]);
                    case GreenData.NotEqual: return ZString.Concat("!= ", tile.data[1]);
                    case GreenData.Greater: return ZString.Concat("> ", tile.data[1]);
                    case GreenData.Less: return ZString.Concat("< ", tile.data[1]);
                    case GreenData.GreaterOrEqual: return ZString.Concat(">= ", tile.data[1]);
                    case GreenData.LessOrEqual: return ZString.Concat("<= ", tile.data[1]);
                    default: return "Error";
                }

            case TileColor.White:
                return (WhiteData)tile.data[0] == WhiteData.Blank ? "" : "Error";

            default: return "Error";
        }
    }
}

public enum TileColor
{
    Null, Red, Blue, Green, White, Black,
}

public enum ToD
{
    Null, Truth , Devil,
}

public enum RedData
{
    Null, Exit, Map,
}

public enum BlueData
{
    Null, Color, GaroSero, Eye,
}

public enum GreenData
{
    Null, Equal, NotEqual, Greater, Less, GreaterOrEqual, LessOrEqual,
}

public enum WhiteData
{
    Blank, Eye, Gate,
}

public enum GaroSero
{
    Null, Garo, Sero
}