using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField] Sprite redThorn;
    [SerializeField] Sprite blueThorn;
    [SerializeField] Sprite greenThorn;
    
    public Tilemap tilemap;
    public Dictionary<Vector3Int, TileObject> mapDict = new Dictionary<Vector3Int, TileObject>();

    void Start()
    {
        Debug.Log(StageData.stages[0][0]);
    }
}
