using UnityEngine;

public class TDEye : TDObject
{
    public int code;
    public bool isMarked;
    public Species trueID;
    public Species guessedID = Species.Null;
    public SpriteRenderer spriteRenderer;
    public Sprite defaultSprite, angelSprite, devilSprite;

    public bool isSelecting;
    public GameObject button;
    public GameObject selectingButtons;

    public void Init(TDTileData tileData)
    {
        code = tileData.data[2];
        trueID = (Species)tileData.data[1];

        base.Init(tileData, MyUtils.ConvertToRoman(code + 1));
    }

    public static void SetTDEyeState(TDEye eye, Species guessedID)
    {
        eye.guessedID = guessedID;
        switch (guessedID)
        {
            case Species.Null: eye.isMarked = false; eye.spriteRenderer.sprite = eye.defaultSprite; break;
            case Species.Angel: eye.isMarked = true; eye.spriteRenderer.sprite = eye.angelSprite; break;
            case Species.Devil: eye.isMarked = true; eye.spriteRenderer.sprite = eye.devilSprite; break;
        }

        foreach (AnswerLog log in LogManager.instance.logList)
        {
            if (log.tdEye == eye) log.UpdateEyeImage();
        }
    }
    
    public void OnClicked()
    {
        foreach (TDEye eye in MapManager.instance.eyes)
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

    public void OnSelectingButtonClicked(int guessedID)
    {
        SetTDEyeState(this, (Species)guessedID);
        OnClicked();
    }

    public override void DecreaseCount()
    {
        if (stack == 1) spriteRenderer.color = Color.gray;
        base.DecreaseCount();
    }
}
