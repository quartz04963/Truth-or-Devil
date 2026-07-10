using System.Collections.Generic;
using UnityEngine;

abstract public class TileObject : MonoBehaviour
{ 
    public readonly Vector3 offset = new Vector3(0.5f, 0.5f, 0);

    [SerializeField] protected Vector3 pos;
    [SerializeField] protected TileColor color;
    [SerializeField] protected List<int> data;
    [SerializeField] protected bool isHiding = false;
    [SerializeField] protected bool isPlaceable = false;
    [SerializeField] protected bool isThorn = false;

    [SerializeField] protected SpriteRenderer thornSR;
    [SerializeField] protected SpriteSource spriteSource;

    public Vector3 Pos => pos;
    public TileColor Color => color;
    public List<int> Data => data;
    public bool IsHiding => isHiding;
    public bool IsPlaceable => isPlaceable;
    public bool IsThorn => isThorn;

    public virtual void Init(Vector3 pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        this.pos = pos;
        this.color = color;
        this.data = data;
        this.isHiding = isHiding;
        this.isPlaceable = isPlaceable;
        this.isThorn = isThorn;

        switch (color)
        {
            case TileColor.RED: thornSR.sprite = spriteSource.redThorn; break;
            case TileColor.BLUE: thornSR.sprite = spriteSource.blueThorn; break;
            case TileColor.GREEN: thornSR.sprite = spriteSource.greenThorn; break;
        }

        if (isThorn) ActivateThorn();
        else thornSR.gameObject.SetActive(false);

        transform.position = pos + offset;
    }

    public virtual void ActivateThorn()
    {
        isThorn = true;
        thornSR.gameObject.SetActive(true);
    }
}