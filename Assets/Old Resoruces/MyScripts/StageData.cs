using System.Collections.Generic;


public readonly struct StageData
{
    public readonly int chapter;
    public readonly int stage;
    public readonly List<TileData> tiles;
    public readonly List<TileData> placeableTiles;

    public StageData(int chapter, int stage, List<TileData> tiles, List<TileData> placeableTiles = null)
    {
        this.chapter = chapter;
        this.stage = stage;
        this.tiles = tiles;
        this.placeableTiles = placeableTiles;
    }

    public readonly int maxX
    {
        get
        {
            int maxX = 0;
            foreach (TileData tile in tiles)
            {
                if (tile.pos.x > maxX) maxX = tile.pos.x;
            }
            return maxX;
        }
    }

    public readonly int minX
    {
        get
        {
            int minX = 8;
            foreach (TileData tile in tiles)
            {
                if (tile.pos.x < minX) minX = tile.pos.x;
            }
            return minX;
        }
    }

    public readonly int maxY
    {
        get
        {
            int maxY = 0;
            foreach (TileData tile in tiles)
            {
                if (tile.pos.y > maxY) maxY = tile.pos.y;
            }
            return maxY;
        }
    }

    public readonly int minY
    {
        get
        {
            int minY = 8;
            foreach (TileData tile in tiles)
            {
                if (tile.pos.y < minY) minY = tile.pos.y;
            }
            return minY;
        }
    }
        
}