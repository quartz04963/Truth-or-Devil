using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public readonly struct Stage
{
    public readonly Vector3Int startPos;
    public readonly List<TileData> tiles;
    public readonly List<TileData> placeableTiles;

    public Stage(Vector3Int startPos, List<TileData> tiles, List<TileData> placeableTiles = null)
    {
        this.startPos = startPos;
        this.tiles = tiles;
        this.placeableTiles = placeableTiles;
    }
}
