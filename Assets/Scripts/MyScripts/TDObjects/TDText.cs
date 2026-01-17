using UnityEngine;

public class TDText : TDObject
{
    public override void Init(Vector3Int _pos, string str)
    {
        base.Init(_pos, str);
        tmp.rectTransform.position = _pos + MyUtils.offset;
    }
}
