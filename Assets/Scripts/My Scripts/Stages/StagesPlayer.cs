using PrimeTween;
using UnityEngine;

public class StagesPlayer : MonoBehaviour
{
    public static readonly Vector3 playerOffset = new Vector3(0.5f, 0.9f, 0);
    
    [SerializeField] Vector3Int pos;

    [SerializeField] float moveInterval;
    [SerializeField] float inputDelay;

    private float lastMoveTime;
    private Vector3Int nextInput;
    private StageGateTile enteringGate;

    public void Init(Vector3Int startPos)
    {
        pos = startPos;
        transform.position = startPos + playerOffset;
    }

    public bool HandleMove()
    {
        if (Time.time < lastMoveTime + inputDelay) return false;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) nextInput = Vector3Int.up;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) nextInput = Vector3Int.left;
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) nextInput = Vector3Int.down;
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) nextInput = Vector3Int.right;

        if (Time.time < lastMoveTime + moveInterval) return false;

        if (nextInput == Vector3Int.zero) return false;

        lastMoveTime = Time.time;
        return Move();
    }

    bool Move()
    {
        Vector3Int nextPos = pos + nextInput;

        if (!CanMove(nextPos)) return false;

        pos = nextPos;
        transform.position = nextPos + playerOffset;

        nextInput = Vector3Int.zero;

        MoveCamera(StagesManager.instance.Camera);

        return true;
    }

    bool CanMove(Vector3Int nextPos)
    {
        bool result = StagesManager.instance.mapDict.TryGetValue(nextPos, out TileObject tileObj);

        if (tileObj is StageGateTile gate)
        {            
            enteringGate = gate;
            gate.CheckEntrance();
            
            nextInput = Vector3Int.zero;
            return false;
        }
        else 
        {
            enteringGate = null;
            return result;
        }
    }

    void MoveCamera(GameObject camera)
    {
        Vector3 destination = pos.x <= 5 ? new Vector3(0, 0, -10) :
                              pos.x <= 17 ? new Vector3(12, 0, -10) :
                              pos.x <= 29 ? new Vector3(24, 0, -10) : new Vector3(36, 0, -10);

        Tween.CompleteAll(camera.transform);
        Tween.Position(camera.transform, destination, 0.2f);
    }

    public bool IsEntering(StageGateTile gate)
    {
        return enteringGate == gate;
    }
}
