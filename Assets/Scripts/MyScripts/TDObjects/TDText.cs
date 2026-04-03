using UnityEngine;

public class TDText : TDObject
{
    public override void Init(Vector3Int pos, string str, int count)
    {
        base.Init(pos, str, count);
        tmp.rectTransform.position = pos + MyUtils.Offset;
    }

    public override void DecreaseCount()
    {
        if (count == 1) tmp.gameObject.SetActive(false);
        base.DecreaseCount();
    }
}
