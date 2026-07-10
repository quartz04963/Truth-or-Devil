using System.Collections.Generic;
using UnityEngine;

public static class StageData
{
    public static List<Stage>[] stages;

    static StageData()
    {
        stages = new List<Stage>[5];
        
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i] = new List<Stage>();
        }

        #region 챕터 0
        stages[0].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, ""),
                    new TileData(2, 2, ""),
                    new TileData(3, 2, true),
                    new TileData(4, 2, ""),
                    new TileData(0, 1, ""),
                    new TileData(2, 1, ""),
                    new TileData(3, 1, false),
                    new TileData(4, 1, ""),
                    new TileData(0, 0, ""),
                    new TileData(1, 0, ""),
                    new TileData(2, 0, ""),
                    new TileData(3, 0, ""),
                    new TileData(4, 0, ""),
                }
            )
        );

        stages[0].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, "EXIT"),
                    new TileData(2, 2, "8"),
                    new TileData(3, 2, "8"),
                    new TileData(4, 2, "8"),
                    new TileData(0, 1, "GREEN"),
                    new TileData(2, 1, "8"),
                    new TileData(3, 1, true),
                    new TileData(4, 1, "8"),
                    new TileData(0, 0, "8"),
                    new TileData(1, 0, Species.ANGEL),
                    new TileData(2, 0, "8"),
                    new TileData(3, 0, "8"),
                    new TileData(4, 0, "8"),
                }
            )
        );

        stages[0].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, "EXIT"),
                    new TileData(2, 2, "EXIT"),
                    new TileData(3, 2, "EXIT"),
                    new TileData(4, 2, "EXIT"),
                    new TileData(0, 1, "RED"),
                    new TileData(2, 1, "EXIT"),
                    new TileData(3, 1, true),
                    new TileData(4, 1, "EXIT"),
                    new TileData(0, 0, "8"),
                    new TileData(1, 0, Species.DEVIL),
                    new TileData(2, 0, "EXIT"),
                    new TileData(3, 0, "EXIT"),
                    new TileData(4, 0, "EXIT"),
                }
            )
        );

        stages[0].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, "WHITE"),
                    new TileData(2, 2, ""),
                    new TileData(3, 2, false),
                    new TileData(4, 2, ""),
                    new TileData(0, 1, "3"),
                    new TileData(2, 1, ""),
                    new TileData(3, 1, true),
                    new TileData(4, 1, ""),
                    new TileData(0, 0, "EXIT"),
                    new TileData(1, 0, Species.ANGEL),
                    new TileData(2, 0, "BLUE"),
                    new TileData(3, 0, "BLUE"),
                    new TileData(4, 0, "BLUE"),
                }
            )
        );

        stages[0].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, "1"),
                    new TileData(2, 2, ""),
                    new TileData(3, 2, true),
                    new TileData(4, 2, ""),
                    new TileData(0, 1, "EXIT"),
                    new TileData(2, 1, ""),
                    new TileData(3, 1, false),
                    new TileData(4, 1, ""),
                    new TileData(0, 0, "GREEN"),
                    new TileData(1, 0, Species.DEVIL),
                    new TileData(2, 0, ""),
                    new TileData(3, 0, "8"),
                    new TileData(4, 0, ""),
                }
            )
        );

        stages[0].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, ""),
                    new TileData(2, 2, "BLUE"),
                    new TileData(3, 2, false),
                    new TileData(4, 2, "RED"),
                    new TileData(0, 1, ""),
                    new TileData(2, 1, "EXIT"),
                    new TileData(3, 1, ""),
                    new TileData(4, 1, "EXIT"),
                    new TileData(0, 0, ""),
                    new TileData(1, 0, Species.ANGEL),
                    new TileData(2, 0, "2"),
                    new TileData(3, 0, true),
                    new TileData(4, 0, "8"),
                }
            )
        );
        #endregion
    }
}
