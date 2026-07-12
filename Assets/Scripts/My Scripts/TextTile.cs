using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTile : TileObject
{
    [SerializeField] TextMeshProUGUI tmp;

    public override void Init(Vector3Int pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn);

        string text = Utils.GetText(this);

        if (text != null) SetText(text);
        else Debug.LogWarning("Wrong data: " + data);
    }

    public override void ActivateThorn()
    {
        base.ActivateThorn();
        
        tmp.gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        tmp.SetText(text);
    }
}
