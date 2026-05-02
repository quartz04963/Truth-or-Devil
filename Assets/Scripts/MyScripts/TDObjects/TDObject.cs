using TMPro;
using UnityEngine;
using PrimeTween;
using UnityEngine.UI;
using Cysharp.Text;

public class TDObject : MonoBehaviour
{
    public int stack;
    public Vector3Int pos;
    public TileData tileData;

    

    public Canvas canvas;
    public TextMeshProUGUI stackText;
    public TextMeshProUGUI text;
    public GameObject tileBlock;
    public GameObject highlightRim;
    public Image highlightBG;


    public virtual void Init(TileData tileData, string text)
    {
        this.tileData = tileData;
        gameObject.transform.position = tileData.pos + MyUtils.Offset;

        this.text.SetText(text);

        pos = tileData.pos;
        stack = tileData.stack;
        if (stack > 0) stackText.SetText(ZString.Concat(stack));
    }

    public virtual void BlockTile(bool isBlocking)
    {
        tileBlock.SetActive(isBlocking);
    }

    public virtual void HighlightTile(bool isOn, bool isfilled = true)
    {
        highlightRim.SetActive(isOn);
        highlightBG.enabled = isfilled;
    }

    public virtual void Shake(Vector3 dir, float duration)
    {
        Sequence seq = Sequence.Create()
            .Chain(Tween.Position(transform, pos + MyUtils.Offset + dir, duration))
            .Chain(Tween.Position(transform, pos + MyUtils.Offset, duration))
            .Chain(Tween.Position(transform, pos + MyUtils.Offset - dir, duration))
            .Chain(Tween.Position(transform, pos + MyUtils.Offset, duration));
    }

    public virtual void DecreaseCount()
    {
        if (stack > 0)
        {
            stackText.SetText(ZString.Concat(--stack));

            if (stack == 0)
            {
                stackText.gameObject.SetActive(false);
            }
        }
    }
}
