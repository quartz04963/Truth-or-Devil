using UnityEngine;
using Cysharp.Text;

public class TDEye : TDObject
{
    public ToD trueID;
    public ToD guessedID = ToD.Null;
    public int index;
    public int spriteNumber = 0;
    public bool isMarked;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public SpriteRenderer spriteRenderer;

    public void Init(Vector3Int _pos, int _index)
    {
        index = _index;
        base.Init(_pos, ZString.Format("{0}", (char)('A' + index)));
        tmp.rectTransform.position = _pos + MyUtils.offset + new Vector3(0.3f, -0.3f, 0);
    }

    public void OnSwitchClicked()
    {
        spriteNumber = (++spriteNumber) % 3;
        SetState(this, spriteNumber);
    }

    public static void SetState(TDEye eye, int _spriteNumber)
    {
        eye.spriteNumber = _spriteNumber;
        switch (eye.spriteNumber)
        {
            case 0: eye.isMarked = false; eye.guessedID = ToD.Null; eye.spriteRenderer.sprite = eye.defaultSprite; break;
            case 1: eye.isMarked = true; eye.guessedID = ToD.Truth; eye.spriteRenderer.sprite = eye.angelSprite; break;
            case 2: eye.isMarked = true; eye.guessedID = ToD.Devil; eye.spriteRenderer.sprite = eye.devilSprite; break;
        }

        foreach (AnswerLog log in LogManager.instance.logList)
        {
            if (log.tdEye == eye) log.UpdateEyeImage();
        }
    }
}
