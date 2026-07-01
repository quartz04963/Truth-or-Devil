using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioEye : MonoBehaviour
{
    public Species guessedID;
    public TDEye tdEye;
    public Image image;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public TextMeshProUGUI tmp;
    public Button button;

    public void Init(TDEye _tdEye)
    {
        tdEye = _tdEye;
        tdEye.guessedID = Species.Null;
        image.sprite = defaultSprite;
        tmp.SetText(MyUtils.ConvertToRoman(tdEye.code + 1));
    }

    public void OnClicked()
    {
        if (!GamePlay.instance.IsRunning) return;

        guessedID = (Species)(((int)guessedID + 1) % 3);
        switch (guessedID)
        {
            case Species.Null: image.sprite = defaultSprite; break;
            case Species.Angel: image.sprite = angelSprite; break;
            case Species.Devil: image.sprite = devilSprite; break;
        }
        // TDEye.SetTDEyeState(tdEye, guessedID);
    }
}
