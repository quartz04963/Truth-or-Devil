using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public readonly struct Range
{
    public readonly int left;
    public readonly int right;
    public readonly int top;
    public readonly int bottom;

    public Range(int left, int right, int top, int bottom)
    {
        this.left = left;
        this.right = right;
        this.top = top;
        this.bottom = bottom;
    }

    public Range(List<TileData> tiles)
    {
        int left = int.MaxValue, right = int.MinValue;
        int top = int.MinValue, bottom = int.MaxValue;

        foreach (TileData tile in tiles)
        {
            if (tile.pos.x < left) left = tile.pos.x;
            if (tile.pos.x > right) right = tile.pos.x;

            if (tile.pos.y > top) top = tile.pos.y;
            if (tile.pos.y < bottom) bottom = tile.pos.y;
        }

        this.left = left;
        this.right = right;
        this.top = top;
        this.bottom = bottom;
    }
}

[Serializable]
public readonly struct Stage
{
    public readonly Vector3Int startPos;
    public readonly List<TileData> tiles;
    public readonly List<TileData> placeableTiles;
    public readonly Range range;

    public Stage(Vector3Int startPos, List<TileData> tiles, List<TileData> placeableTiles = null)
    {
        this.startPos = startPos;
        this.tiles = tiles;
        this.placeableTiles = placeableTiles;

        range = new Range(tiles);
    }
}
