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

    public bool isSelecting;
    public GameObject button;
    public GameObject selectingButtons;

    public void Init(Vector3Int _pos, int _index)
    {
        index = _index;
        base.Init(_pos, MyUtils.ConvertToRoman(_index + 1));
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
        foreach (TDEye eye in MapManager.instance.eyeList)
        {
            if (eye != this)
            {
                eye.isSelecting = false;
                eye.selectingButtons.SetActive(false);
            }
            else
            {
                eye.isSelecting = !isSelecting;
                eye.selectingButtons.SetActive(eye.isSelecting);
            }
        }
    }

    public void OnSelectingButtonClicked(int _guessedID)
    {
        SetTDEyeState(this, (ToD)_guessedID);
        OnClicked();
    }
}
