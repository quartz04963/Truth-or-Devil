using TMPro;
using UnityEngine;
using PrimeTween;
using UnityEngine.UI;
using Cysharp.Text;

public class TDObject : MonoBehaviour
{
    public int stack;
    public Vector3Int pos;
    public TDTileData tileData;

    public Canvas canvas;
    public TextMeshProUGUI stackText;
    public TextMeshProUGUI text;

    public Image thorn;
    public Sprite redThornSprite, blueThornSprite, greenThornSprite;

    public GameObject tileBlock;
    public GameObject highlightRim;
    public Image highlightBG;


    public virtual void Init(TDTileData tileData, string text)
    {
        this.tileData = tileData;
        gameObject.transform.position = tileData.pos + MyUtils.Offset;

        this.text.SetText(text);

        pos = tileData.pos;
        stack = tileData.stack;

        switch (this.tileData.color)
        {
            case TileColor.RED: thorn.sprite = redThornSprite; break;
            case TileColor.BLUE: thorn.sprite = blueThornSprite; break;
            case TileColor.GREEN: thorn.sprite = greenThornSprite; break;
        }

        if (stack > 0) stackText.SetText(ZString.Concat(stack));
        else if (stack == 0) {
            stackText.gameObject.SetActive(false);
            if (this.tileData.color != TileColor.WHITE) {
                thorn.gameObject.SetActive(true);
            }
        }
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
                if (tileData.color != TileColor.WHITE)
                {
                    thorn.gameObject.SetActive(true);
                }
            }
        }
    }
}
