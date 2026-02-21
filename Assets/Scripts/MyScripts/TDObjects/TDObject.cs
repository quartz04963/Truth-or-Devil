using TMPro;
using UnityEngine;
using PrimeTween;

public class TDObject : MonoBehaviour
{
    public Vector3Int pos;
    public Canvas canvas;
    public TextMeshProUGUI tmp;
    public GameObject tileBlock;
    public GameObject highlightRim;

    public virtual void Init(Vector3Int _pos, string str)
    {
        pos = _pos;
        gameObject.transform.position = _pos + MyUtils.offset;
        tmp.SetText(str);
    }

    public virtual void BlockTile(bool isBlocking)
    {
        tileBlock.SetActive(isBlocking);
    }

    public virtual void HighlightTile(bool isOn)
    {
        highlightRim.SetActive(isOn);
    }

    public virtual void Shake(Vector3 dir, float duration)
    {
        Sequence seq = Sequence.Create()
            .Chain(Tween.Position(transform, pos + MyUtils.offset + dir, duration))
            .Chain(Tween.Position(transform, pos + MyUtils.offset, duration))
            .Chain(Tween.Position(transform, pos + MyUtils.offset - dir, duration))
            .Chain(Tween.Position(transform, pos + MyUtils.offset, duration));
    }
}
