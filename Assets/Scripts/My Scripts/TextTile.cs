using TMPro;
using UnityEngine;

public class TextTile : TileObject
{
    [SerializeField] TextMeshProUGUI text;

    public void SetText(string text)
    {
        this.text.SetText(text);
    }

    public override void ActivateThorn()
    {
        base.ActivateThorn();
        text.gameObject.SetActive(false);
    }
}
