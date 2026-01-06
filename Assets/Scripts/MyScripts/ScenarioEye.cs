using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioEye : MonoBehaviour
{
    public ToD guessedID;
    public TDEye tdEye;
    public Image image;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public TextMeshProUGUI tmp;
    public Button button;

    public void Init(TDEye _tdEye)
    {
        tdEye = _tdEye;
        tdEye.guessedID = ToD.Null;
        image.sprite = defaultSprite;
        tmp.SetText((char)('A' + tdEye.index));
    }

    public void OnClicked()
    {
       guessedID = (ToD)(((int)guessedID + 1) % 3);
        switch (guessedID)
        {
            case ToD.Null: image.sprite = defaultSprite; break;
            case ToD.Truth: image.sprite = angelSprite; break;
            case ToD.Devil: image.sprite = devilSprite; break;
        }
        TDEye.SetTDEyeState(tdEye, guessedID);
    }
}
