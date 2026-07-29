using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public readonly struct TileData
{
    public readonly Vector3Int pos;
    public readonly TileColor color;
    public readonly List<int> data;
    public readonly bool isHiding;
    public readonly bool isPlaceable;
    public readonly bool isThorn;

    public TileData(Vector3Int pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        this.pos = pos;
        this.color = color;
        this.data = data;
        this.isHiding = isHiding;
        this.isPlaceable = isPlaceable;
        this.isThorn = isThorn;
    }

    public TileData(int x, int y, string dataString, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        pos = new Vector3Int(x, y, 0);

        switch (dataString)
        {
            case "EXIT": color = TileColor.RED; data = new List<int>{(int)RedData.EXIT}; break;
            case "MAP": color = TileColor.RED; data = new List<int>{(int)RedData.MAP}; break;

            case "RED": color = TileColor.BLUE; data = new List<int>{(int)BlueData.COLOR, (int)TileColor.RED}; break;
            case "BLUE": color = TileColor.BLUE; data = new List<int>{(int)BlueData.COLOR, (int)TileColor.BLUE}; break;
            case "GREEN": color = TileColor.BLUE; data = new List<int>{(int)BlueData.COLOR, (int)TileColor.GREEN}; break;
            case "WHITE": color = TileColor.BLUE; data = new List<int>{(int)BlueData.COLOR, (int)TileColor.WHITE}; break;

            case "ROW": color = TileColor.BLUE; data = new List<int>{(int)BlueData.POSITION, (int)Position.ROW}; break;
            case "COL": color = TileColor.BLUE; data = new List<int>{(int)BlueData.POSITION, (int)Position.COL}; break;

            case "ANGEL": color = TileColor.BLUE; data = new List<int>{(int)BlueData.SPECIES, (int)Species.ANGEL}; break;
            case "DEVIL": color = TileColor.BLUE; data = new List<int>{(int)BlueData.SPECIES, (int)Species.DEVIL}; break;

            case "0": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 0}; break;
            case "1": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 1}; break;
            case "2": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 2}; break;
            case "3": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 3}; break;
            case "4": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 4}; break;
            case "5": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 5}; break;
            case "6": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 6}; break;
            case "7": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 7}; break;
            case "8": color = TileColor.GREEN; data = new List<int>{(int)GreenData.EQ, 8}; break;

            case "": color = TileColor.WHITE; data = new List<int>{(int)WhiteData.NULL, 0}; break;

            default: color = TileColor.NULL; data = null; Debug.Log("argument error. datasString: " + dataString); break;
        }

        this.isHiding = isHiding;
        this.isPlaceable = isPlaceable;
        this.isThorn = isThorn;
    }

    public TileData(int x, int y, Species species = Species.NULL, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        pos = new Vector3Int(x, y, 0);
        color = TileColor.WHITE;
        data = new List<int>{(int)WhiteData.EYE, (int)species};

        this.isHiding = isHiding;
        this.isPlaceable = isPlaceable;
        this.isThorn = isThorn;
    }

    public TileData(int x, int y, bool isExit, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        pos = new Vector3Int(x, y, 0);
        color = TileColor.WHITE;
        data = isExit ? new List<int>{(int)WhiteData.GATE, 1} : new List<int>{(int)WhiteData.GATE, 0};

        this.isHiding = isHiding;
        this.isPlaceable = isPlaceable;
        this.isThorn = isThorn;
    }
}
