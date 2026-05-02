using UnityEngine;

public class TDText : TDObject
{
    public override void Init(TileData tileData, string text)
    {
        base.Init(tileData, text);
        this.text.rectTransform.position = pos + MyUtils.Offset;
    }

    public override void DecreaseCount()
    {
        if (stack == 1) text.gameObject.SetActive(false);
        base.DecreaseCount();
    }
}