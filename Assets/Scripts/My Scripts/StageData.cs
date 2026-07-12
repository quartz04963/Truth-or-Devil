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

        #region 챕터 1
        stages[1].Add(
            new Stage(
                new Vector3Int(0, 1, 0),
                new List<TileData> {
                    new TileData(1, 2, true),
                    new TileData(2, 2, "1"),
                    new TileData(3, 2, Species.ANGEL),
                    new TileData(0, 1, ""),
                    new TileData(1, 1, "ROW"),
                    new TileData(2, 1, "2"),
                    new TileData(3, 1, "EXIT"),
                    new TileData(1, 0, false),
                    new TileData(2, 0, "3"),
                    new TileData(3, 0, false),
                }
            )
        );

        stages[1].Add(
            new Stage(
                new Vector3Int(2, 0, 0),
                new List<TileData> {
                    new TileData(1, 3, true),
                    new TileData(3, 3, false),
                    new TileData(0, 2, false),
                    new TileData(1, 2, "ROW"),
                    new TileData(2, 2, Species.DEVIL),
                    new TileData(3, 2, "2"),
                    new TileData(4, 2, false),
                    new TileData(1, 1, "EXIT"),
                    new TileData(3, 1, "1"),
                    new TileData(1, 0, "COL"),
                    new TileData(2, 0, ""),
                    new TileData(3, 0, "0"),
                }
            )
        );

        stages[1].Add(
            new Stage(
                new Vector3Int(1, 4, 0),
                new List<TileData> {
                    new TileData(1, 4, ""),
                    new TileData(3, 4, false),
                    new TileData(0, 3, Species.ANGEL),
                    new TileData(1, 3, "0"),
                    new TileData(2, 3, ""),
                    new TileData(3, 3, "2"),
                    new TileData(4, 3, ""),
                    new TileData(0, 2, "ROW"),
                    new TileData(2, 2, "1"),
                    new TileData(4, 2, "COL"),
                    new TileData(0, 1, true),
                    new TileData(1, 1, "EXIT"),
                    new TileData(2, 1, ""),
                    new TileData(3, 1, "EXIT"),
                    new TileData(4, 1, Species.DEVIL),
                    new TileData(1, 0, false),
                    new TileData(3, 0, ""),
                }
            )
        );

        stages[1].Add(
            new Stage(
                new Vector3Int(1, 0, 0),
                new List<TileData> {
                    new TileData(0, 2, false),
                    new TileData(1, 2, false),
                    new TileData(2, 2, "1"),
                    new TileData(0, 1, "EXIT"),
                    new TileData(1, 1, "ROW", true),
                    new TileData(2, 1, Species.DEVIL),
                    new TileData(0, 0, true),
                    new TileData(1, 0, ""),
                    new TileData(2, 0, "2"),
                }
            )
        );

        stages[1].Add(
            new Stage(
                new Vector3Int(0, 2, 0),
                new List<TileData> {
                    new TileData(0, 2, ""),
                    new TileData(1, 2, Species.ANGEL),
                    new TileData(2, 2, false),
                    new TileData(4, 2, "1"),
                    new TileData(5, 2, "EXIT"),
                    new TileData(1, 1, "ROW"),
                    new TileData(2, 1, "COL"),
                    new TileData(3, 1, "1", true),
                    new TileData(4, 1, Species.ANGEL),
                    new TileData(5, 1, "2"),
                    new TileData(0, 0, false),
                    new TileData(1, 0, false),
                    new TileData(2, 0, true),
                    new TileData(4, 0, "3"),
                    new TileData(5, 0, "EXIT"),
                }
            )
        );

        stages[1].Add(
            new Stage(
                new Vector3Int(0, 0, 0),
                new List<TileData> {
                    new TileData(0, 2, false),
                    new TileData(1, 2, "EXIT"),
                    new TileData(3, 2, "EXIT"),
                    new TileData(4, 2, false),
                    new TileData(0, 1, "ROW"),
                    new TileData(1, 1, Species.DEVIL),
                    new TileData(2, 1, "2", true),
                    new TileData(3, 1, Species.DEVIL),
                    new TileData(4, 1, "COL"),
                    new TileData(0, 0, ""),
                    new TileData(1, 0, "1"),
                    new TileData(2, 0, false),
                    new TileData(3, 0, "3"),
                    new TileData(4, 0, true),
                }
            )
        );
        #endregion

        #region 챕터 2
        stages[2].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, "MAP"),
                    new TileData(2, 2, ""),
                    new TileData(3, 2, true),
                    new TileData(4, 2, ""),
                    new TileData(0, 1, "DEVIL"),
                    new TileData(2, 1, ""),
                    new TileData(3, 1, ""),
                    new TileData(4, 1, ""),
                    new TileData(0, 0, "3"),
                    new TileData(1, 0, Species.ANGEL),
                    new TileData(2, 0, Species.DEVIL),
                    new TileData(3, 0, Species.DEVIL),
                    new TileData(4, 0, Species.DEVIL),
                }
            )
        );

        stages[2].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(0, 2, "MAP"),
                    new TileData(2, 2, ""),
                    new TileData(3, 2, true),
                    new TileData(4, 2, ""),
                    new TileData(0, 1, "DEVIL"),
                    new TileData(2, 1, ""),
                    new TileData(3, 1, false),
                    new TileData(4, 1, ""),
                    new TileData(0, 0, "3"),
                    new TileData(1, 0, Species.DEVIL),
                    new TileData(2, 0, "1"),
                    new TileData(3, 0, "BLUE"),
                    new TileData(4, 0, "EXIT"),
                }
            )
        );

        stages[2].Add(
            new Stage(
                new Vector3Int(1, 3, 0),
                new List<TileData> {
                    new TileData(1, 3, ""),
                    new TileData(3, 3, Species.DEVIL),
                    new TileData(1, 2, "MAP"),
                    new TileData(2, 2, "ANGEL"),
                    new TileData(3, 2, "1"),
                    new TileData(1, 1, ""),
                    new TileData(3, 1, Species.ANGEL),
                    new TileData(0, 0, false),
                    new TileData(1, 0, "EXIT"),
                    new TileData(2, 0, "GREEN"),
                    new TileData(3, 0, "1"),
                    new TileData(4, 0, true),
                }
            )
        );

        stages[2].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(2, 3, false),
                    new TileData(4, 3, Species.ANGEL),
                    new TileData(0, 2, "2"),
                    new TileData(2, 2, "1"),
                    new TileData(3, 2, false),
                    new TileData(0, 1, "DEVIL"),
                    new TileData(2, 1, "ROW"),
                    new TileData(3, 1, "2"),
                    new TileData(4, 1, true),
                    new TileData(0, 0, "EXIT"),
                    new TileData(1, 0, Species.DEVIL),
                    new TileData(2, 0, "MAP"),
                    new TileData(3, 0, "ROW"),
                    new TileData(4, 0, "3"),
                }
            )
        );

        stages[2].Add(
            new Stage(
                new Vector3Int(5, 2, 0),
                new List<TileData> {
                    new TileData(0, 2, "1"),
                    new TileData(1, 2, false),
                    new TileData(3, 2, "MAP"),
                    new TileData(4, 2, Species.DEVIL),
                    new TileData(5, 2, ""),
                    new TileData(6, 2, "2"),
                    new TileData(0, 1, "ROW"),
                    new TileData(1, 1, true),
                    new TileData(3, 1, "ANGEL"),
                    new TileData(5, 1, false),
                    new TileData(6, 1, "COL"),
                    new TileData(0, 0, "EXIT"),
                    new TileData(1, 0, Species.DEVIL),
                    new TileData(2, 0, Species.DEVIL),
                    new TileData(3, 0, "2"),
                    new TileData(5, 0, false),
                    new TileData(6, 0, "EXIT"),
                }
            )
        );

        stages[2].Add(
            new Stage(
                new Vector3Int(0, 3, 0),
                new List<TileData> {
                    new TileData(0, 3, ""),
                    new TileData(2, 3, true),
                    new TileData(3, 3, false),
                    new TileData(4, 3, false),
                    new TileData(0, 2, "MAP"),
                    new TileData(2, 2, "WHITE"),
                    new TileData(3, 2, "1"),
                    new TileData(4, 2, "EXIT"),
                    new TileData(0, 1, "0"),
                    new TileData(2, 1, Species.DEVIL),
                    new TileData(3, 1, "ANGEL", true),
                    new TileData(4, 1, "2"),
                    new TileData(0, 0, "BLUE"),
                    new TileData(1, 0, Species.DEVIL),
                    new TileData(2, 0, ""),
                    new TileData(3, 0, Species.ANGEL),
                    new TileData(4, 0, "WHITE"),
                }
            )
        );
        #endregion
    }
}
