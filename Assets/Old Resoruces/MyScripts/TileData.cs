using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Text;


[Serializable]
public readonly struct TDTileData
{
    public static TDTileData Null = new TDTileData(Vector3Int.zero, TileColor.Null, new List<int>{0, 0, 0}, false, false, -1);

    public readonly Vector3Int pos;
    public readonly TileColor color;
    public readonly List<int> data;
    public readonly int stack;
    public readonly bool isHiding;
    public readonly bool isPlaceable;

    public TDTileData(Vector3Int pos, TileColor color, List<int> data, bool isHiding, bool isPlaceable, int stack)
    {
        this.pos = pos;
        this.color = color; 
        this.data = data;
        this.isHiding = isHiding;
        this.stack = stack;
        this.isPlaceable = isPlaceable;
    }

    public static TDTileData Construct(int x, int y, string str, bool isHiding = false, bool isPlaceable = false, int stack = -1)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (str)
        {
            case "EXIT": return new TDTileData(pos, TileColor.Red, new List<int>{(int)RedData.Exit}, isHiding, isPlaceable, stack);
            case "MAP": return new TDTileData(pos, TileColor.Red, new List<int>{(int)RedData.Map}, isHiding, isPlaceable, stack);
            case "RED": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Red}, isHiding, isPlaceable, stack);
            case "BLUE": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Blue}, isHiding, isPlaceable, stack);
            case "GREEN": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.Green}, isHiding, isPlaceable, stack);
            case "WHITE": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Color, (int)TileColor.White}, isHiding, isPlaceable, stack);
            case "GARO": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Position, (int)Position.Row}, isHiding, isPlaceable, stack);
            case "SERO": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Position, (int)Position.Col}, isHiding, isPlaceable, stack);
            case "ANGEL": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Species, (int)Species.Angel}, isHiding, isPlaceable, stack);
            case "DEVIL": return new TDTileData(pos, TileColor.Blue, new List<int>{(int)BlueData.Species, (int)Species.Devil}, isHiding, isPlaceable, stack);
            case "0" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 0}, isHiding, isPlaceable, stack);
            case "1" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 1}, isHiding, isPlaceable, stack);
            case "2" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 2}, isHiding, isPlaceable, stack);
            case "3" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 3}, isHiding, isPlaceable, stack);
            case "4" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 4}, isHiding, isPlaceable, stack);
            case "5" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 5}, isHiding, isPlaceable, stack);
            case "6" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 6}, isHiding, isPlaceable, stack);
            case "7" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 7}, isHiding, isPlaceable, stack);
            case "8" : return new TDTileData(pos, TileColor.Green, new List<int>{(int)GreenData.EQ, 8}, isHiding, isPlaceable, stack);
            default: return Null;
        }
    }

    public static TDTileData Construct(int x, int y, WhiteData whitedata, Species toD, int index, bool isHiding = false, bool isPlaceable = false, int count = -1)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (whitedata)
        {
            case WhiteData.Null: return new TDTileData(pos, TileColor.White, new List<int>{(int)WhiteData.Null, index}, isHiding, isPlaceable, count);
            case WhiteData.Eye: return new TDTileData(pos, TileColor.White, new List<int>{(int)WhiteData.Eye, (int)toD, index}, isHiding, false, count);
            case WhiteData.Gate: return new TDTileData(pos, TileColor.White, new List<int>{(int)WhiteData.Gate, (int)toD, index}, isHiding, false, count);
            default: return Null;
        }
    }

    public static string GetText(TDTileData tile)
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
                    case BlueData.Position:
                        switch ((Position)tile.data[1])
                        {
                            case Position.Row: return "GARO";
                            case Position.Col: return "SERO";
                            default: return "Error";
                        }
                    case BlueData.Species:
                        switch ((Species)tile.data[1])
                        {
                            case Species.Angel: return "ANGEL";
                            case Species.Devil: return "DEVIL";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            
            case TileColor.Green: 
                switch ((GreenData)tile.data[0])
                {
                    case GreenData.Null: return "";
                    case GreenData.EQ: return ZString.Concat("", tile.data[1]);
                    case GreenData.NE: return ZString.Concat("!= ", tile.data[1]);
                    case GreenData.GT: return ZString.Concat("> ", tile.data[1]);
                    case GreenData.LT: return ZString.Concat("< ", tile.data[1]);
                    case GreenData.GE: return ZString.Concat(">= ", tile.data[1]);
                    case GreenData.LE: return ZString.Concat("<= ", tile.data[1]);
                    default: return "Error";
                }

            case TileColor.White:
                return (WhiteData)tile.data[0] == WhiteData.Null ? "" : "Error";

            default: return "Error";
        }
    }
}

public enum RedData
{
    Null, Exit, Map,
}
public enum BlueData
{
    Null, Color, Position, Species,
}
public enum TileColor
{
    Null, Red, Blue, Green, White, Black,
}
public enum Position
{
    Null, Row, Col,
}
public enum Species
{
    Null, Angel, Devil,
}
public enum GreenData
{
    Null, EQ, NE, GT, LT, GE, LE,
}
public enum WhiteData
{
    Null, Eye, Gate,
}