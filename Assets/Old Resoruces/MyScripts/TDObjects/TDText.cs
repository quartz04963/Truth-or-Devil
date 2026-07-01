public class TDText : TDObject
{
    public override void Init(TileData tileData, string text)
    {
        base.Init(tileData, text);

        this.text.rectTransform.position = pos + MyUtils.Offset;
        if (stack == 0) this.text.gameObject.SetActive(false);
    }

    public override void DecreaseCount()
    {
        if (stack == 1) text.gameObject.SetActive(false);
        base.DecreaseCount();
    }
}