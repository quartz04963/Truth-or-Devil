using UnityEngine;

public class TDEye : TDObject
{
    public ToD trueID;
    public ToD guessedID = ToD.Null;
    public int spriteNumber = 0;
    public bool isMarked;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public SpriteRenderer spriteRenderer;

    public override void Init(Vector3Int _pos, string str)
    {
        base.Init(_pos, str);
        tmp.rectTransform.position = _pos + MyUtils.offset + new Vector3(0.3f, -0.3f, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnSwitchClicked()
    {
        spriteNumber = (++spriteNumber) % 3;

        switch (spriteNumber)
        {
            case 0: isMarked = false; guessedID = ToD.Null; spriteRenderer.sprite = defaultSprite; break;
            case 1: isMarked = true; guessedID = ToD.Truth; spriteRenderer.sprite = angelSprite; break;
            case 2: isMarked = true; guessedID = ToD.Devil; spriteRenderer.sprite = devilSprite; break;
        }
    }
}
