using UnityEngine;

public class Player : MonoBehaviour
{
    public static readonly Vector3 playerOffset = new Vector3(0.5f, 0.9f, 0);
    
    [SerializeField] Vector3Int pos;

    [SerializeField] float moveInterval;
    [SerializeField] float inputDelay;
    [SerializeField] bool isEntering = false;

    private float lastMoveTime;
    private Vector3Int nextInput;

    public bool IsEntering => isEntering;
    public Vector3Int Pos => pos;

    public void Init(Vector3Int startPos)
    {
        pos = startPos;
        transform.position = startPos + playerOffset;
    }

    public bool HandleMove(Map map)
    {
        if (Time.time < lastMoveTime + inputDelay) return false;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) nextInput = Vector3Int.up;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) nextInput = Vector3Int.left;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) nextInput = Vector3Int.down;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) nextInput = Vector3Int.right;

        if (Time.time < lastMoveTime + moveInterval) return false;

        if (nextInput == Vector3Int.zero) return false;

        lastMoveTime = Time.time;
        return Move(map);
    }

    bool Move(Map map)
    {
        Vector3Int nextPos = pos + nextInput;

        if (!CanMove(map, nextPos)) return false;

        pos = nextPos;
        transform.position = nextPos + playerOffset;

        nextInput = Vector3Int.zero;
        return true;
    }

    bool CanMove(Map map, Vector3Int nextPos)
    {
        bool result = map.mapDict.TryGetValue(nextPos, out TileObject tileObj);

        if (tileObj is GateTile gate)
        {
            if (gate.IsMarked)
            {
                return false;
            }

            if (map.eyes.Exists(eye => eye.MarkedSpecies == Species.NULL))
            {
                return false;
            }
            
            isEntering = true;
            
            gate.CheckEntrance();
            
            nextInput = Vector3Int.zero;
            return false;
        }
        else 
        {
            isEntering = false;
            return result;
        }
    }
}
