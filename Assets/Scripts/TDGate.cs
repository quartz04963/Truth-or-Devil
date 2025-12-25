using UnityEngine;

public class TDGate : TDObject
{
    public override void Init(Vector3Int _pos, string str)
    {
        base.Init(_pos, str);
        tmp.rectTransform.position = _pos + MyUtils.offset + new Vector3(0.3f, -0.3f, 0);
    }
}
