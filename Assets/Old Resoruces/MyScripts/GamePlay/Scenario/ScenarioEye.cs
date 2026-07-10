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
        tdEye.guessedID = Species.NULL;
        image.sprite = defaultSprite;
        tmp.SetText(MyUtils.ConvertToRoman(tdEye.code + 1));
    }

    public void OnClicked()
    {
        if (!GamePlay.instance.IsRunning) return;

        guessedID = (Species)(((int)guessedID + 1) % 3);
        switch (guessedID)
        {
            case Species.NULL: image.sprite = defaultSprite; break;
            case Species.ANGEL: image.sprite = angelSprite; break;
            case Species.DEVIL: image.sprite = devilSprite; break;
        }
        // TDEye.SetTDEyeState(tdEye, guessedID);
    }
}
