using System.Collections.Generic;
using UnityEngine;

abstract public class TileObject : MonoBehaviour
{ 
    [SerializeField] protected Vector3 pos;
    [SerializeField] protected TileColor color;
    [SerializeField] protected List<int> data;
    [SerializeField] protected bool isHiding = false;
    [SerializeField] protected bool isPlaceable = false;
    [SerializeField] protected bool isThorn = false;
    [SerializeField] protected SpriteRenderer thornSR;

    public Vector3 Pos => pos;
    public TileColor Color => color;
    public List<int> Data => data;
    public bool IsHiding => isHiding;
    public bool IsPlaceable => isPlaceable;
    public bool IsThorn => isThorn;

    public virtual void Init(
        Vector3Int pos, 
        TileColor color, 
        List<int> data,
        bool isHiding = false, 
        bool isPlaceable = false, 
        bool isThorn = false, 
        Sprite thornSprite = null
        )
    {
        this.pos = pos;
        this.color = color;
        this.data = data;
        this.isHiding = isHiding;
        this.isPlaceable = isPlaceable;
        this.isThorn = isThorn;
        
        thornSR.sprite = thornSprite;
        if (isThorn) ActivateThorn();
        else thornSR.gameObject.SetActive(false);
    }

    public virtual void ActivateThorn()
    {
        isThorn = true;
        thornSR.gameObject.SetActive(true);
    }
}