using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Text;


[Serializable]
public readonly struct TDTileData
{
    public static TDTileData Null = new TDTileData(Vector3Int.zero, TileColor.NULL, new List<int>{0, 0, 0}, false, false, -1);

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
            case "EXIT": return new TDTileData(pos, TileColor.RED, new List<int>{(int)RedData.EXIT}, isHiding, isPlaceable, stack);
            case "MAP": return new TDTileData(pos, TileColor.RED, new List<int>{(int)RedData.MAP}, isHiding, isPlaceable, stack);
            case "RED": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.RED}, isHiding, isPlaceable, stack);
            case "BLUE": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.BLUE}, isHiding, isPlaceable, stack);
            case "GREEN": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.GREEN}, isHiding, isPlaceable, stack);
            case "WHITE": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.COLOR, (int)TileColor.WHITE}, isHiding, isPlaceable, stack);
            case "GARO": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.POSITION, (int)Position.ROW}, isHiding, isPlaceable, stack);
            case "SERO": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.POSITION, (int)Position.COL}, isHiding, isPlaceable, stack);
            case "ANGEL": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.SPECIES, (int)Species.ANGEL}, isHiding, isPlaceable, stack);
            case "DEVIL": return new TDTileData(pos, TileColor.BLUE, new List<int>{(int)BlueData.SPECIES, (int)Species.DEVIL}, isHiding, isPlaceable, stack);
            case "0" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 0}, isHiding, isPlaceable, stack);
            case "1" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 1}, isHiding, isPlaceable, stack);
            case "2" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 2}, isHiding, isPlaceable, stack);
            case "3" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 3}, isHiding, isPlaceable, stack);
            case "4" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 4}, isHiding, isPlaceable, stack);
            case "5" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 5}, isHiding, isPlaceable, stack);
            case "6" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 6}, isHiding, isPlaceable, stack);
            case "7" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 7}, isHiding, isPlaceable, stack);
            case "8" : return new TDTileData(pos, TileColor.GREEN, new List<int>{(int)GreenData.EQ, 8}, isHiding, isPlaceable, stack);
            default: return Null;
        }
    }

    public static TDTileData Construct(int x, int y, WhiteData whitedata, Species toD, int index, bool isHiding = false, bool isPlaceable = false, int count = -1)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        switch (whitedata)
        {
            case WhiteData.NULL: return new TDTileData(pos, TileColor.WHITE, new List<int>{(int)WhiteData.NULL, index}, isHiding, isPlaceable, count);
            case WhiteData.EYE: return new TDTileData(pos, TileColor.WHITE, new List<int>{(int)WhiteData.EYE, (int)toD, index}, isHiding, false, count);
            case WhiteData.GATE: return new TDTileData(pos, TileColor.WHITE, new List<int>{(int)WhiteData.GATE, (int)toD, index}, isHiding, false, count);
            default: return Null;
        }
    }

    public static string GetText(TDTileData tile)
    {
        if (tile.isHiding) return "???";

        switch (tile.color)
        {
            case TileColor.RED: 
                switch ((RedData)tile.data[0]) {
                    case RedData.NULL: return "";
                    case RedData.EXIT: return "EXIT";
                    case RedData.MAP: return "MAP";
                    default: return "Error";
                }

            case TileColor.BLUE: 
                switch ((BlueData)tile.data[0])
                {
                    case BlueData.NULL: return "";
                    case BlueData.COLOR:
                        switch ((TileColor)tile.data[1])
                        {
                            case TileColor.RED: return "RED";
                            case TileColor.BLUE: return "BLUE";
                            case TileColor.GREEN: return "GREEN";
                            case TileColor.WHITE: return "WHITE";
                            default: return "Error";
                        }
                    case BlueData.POSITION:
                        switch ((Position)tile.data[1])
                        {
                            case Position.ROW: return "GARO";
                            case Position.COL: return "SERO";
                            default: return "Error";
                        }
                    case BlueData.SPECIES:
                        switch ((Species)tile.data[1])
                        {
                            case Species.ANGEL: return "ANGEL";
                            case Species.DEVIL: return "DEVIL";
                            default: return "Error";
                        }
                    default: return "Error";
                }
            
            case TileColor.GREEN: 
                switch ((GreenData)tile.data[0])
                {
                    case GreenData.NULL: return "";
                    case GreenData.EQ: return ZString.Concat("", tile.data[1]);
                    case GreenData.NE: return ZString.Concat("!= ", tile.data[1]);
                    case GreenData.GT: return ZString.Concat("> ", tile.data[1]);
                    case GreenData.LT: return ZString.Concat("< ", tile.data[1]);
                    case GreenData.GE: return ZString.Concat(">= ", tile.data[1]);
                    case GreenData.LE: return ZString.Concat("<= ", tile.data[1]);
                    default: return "Error";
                }

            case TileColor.WHITE:
                return (WhiteData)tile.data[0] == WhiteData.NULL ? "" : "Error";

            default: return "Error";
        }
    }
}

public enum RedData
{
    NULL, EXIT, MAP,
}
public enum BlueData
{
    NULL, COLOR, POSITION, SPECIES,
}
public enum TileColor
{
    NULL, RED, BLUE, GREEN, WHITE, BLACK,
}
public enum Position
{
    NULL, ROW, COL,
}
public enum Species
{
    NULL, ANGEL, DEVIL,
}
public enum GreenData
{
    NULL, EQ, NE, GT, LT, GE, LE,
}
public enum WhiteData
{
    NULL, EYE, GATE,
}