using TMPro;
using UnityEngine;

public class TDObject : MonoBehaviour
{
    public Vector3Int pos;
    public Canvas canvas;
    public TextMeshProUGUI tmp;

    public virtual void Init(Vector3Int _pos, string str)
    {
        pos = _pos;
        gameObject.transform.position = _pos + MyUtils.offset;

        canvas = gameObject.transform.GetChild(0).GetComponent<Canvas>();
        tmp = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp.text = str;
    }
}
