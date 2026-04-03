using TMPro;
using UnityEngine;
using PrimeTween;
using UnityEngine.UI;
using Cysharp.Text;

public class TDObject : MonoBehaviour
{
    public Vector3Int pos;
    public Canvas canvas;
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI countText;
    public GameObject tileBlock;
    public GameObject highlightRim;
    public Image highlightBG;

    public int count;

    public virtual void Init(Vector3Int _pos, string _code, int _count)
    {
        pos = _pos;
        gameObject.transform.position = _pos + MyUtils.Offset;
        tmp.SetText(_code);
        count = _count;
        if (_count > 0) countText.SetText(ZString.Concat(_count));
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
        if (count > 0)
        {
            countText.SetText(ZString.Concat(--count));

            if (count == 0)
            {
                countText.gameObject.SetActive(false);
            }
        }
    }
}
