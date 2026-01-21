using UnityEngine;
using Cysharp.Text;
using UnityEngine.UI;

public class TDEye : TDObject
{
    public int index;
    public bool isMarked;
    public ToD trueID;
    public ToD guessedID = ToD.Null;
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public Button button;

    public void Init(Vector3Int _pos, int _index)
    {
        index = _index;
        base.Init(_pos, ZString.Format("{0}", (char)('A' + _index)));
        tmp.rectTransform.position = _pos + MyUtils.offset + new Vector3(0.3f, -0.3f, 0);
    }

    public static void SetTDEyeState(TDEye eye, ToD _guessedID)
    {
        eye.guessedID = _guessedID;
        switch (_guessedID)
        {
            case ToD.Null: eye.isMarked = false; eye.spriteRenderer.sprite = eye.defaultSprite; break;
            case ToD.Truth: eye.isMarked = true; eye.spriteRenderer.sprite = eye.angelSprite; break;
            case ToD.Devil: eye.isMarked = true; eye.spriteRenderer.sprite = eye.devilSprite; break;
        }

        foreach (AnswerLog log in LogManager.instance.logList)
        {
            if (log.tdEye == eye) log.UpdateEyeImage();
        }
    }
    
    public void OnClicked()
    {
        if (!GamePlay.instance.isRunning) return;
        
        guessedID = (ToD)(((int)guessedID + 1) % 3);
        SetTDEyeState(this, guessedID);
    }
}
