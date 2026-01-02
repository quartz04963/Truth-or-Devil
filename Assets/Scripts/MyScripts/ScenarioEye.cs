using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioEye : MonoBehaviour
{
    public int spriteNumber;
    public TDEye tDEye;
    public Image image;
    public Sprite defaultSprite, angelSprite, devilSprite;
    public TextMeshProUGUI tmp;
    public Button button;

    public void Init(TDEye _tdEye)
    {
        tDEye = _tdEye;
        tDEye.guessedID = ToD.Null;
        tDEye.spriteNumber = spriteNumber = 0;
        image.sprite = defaultSprite;
        tmp.SetText((char)('A' + tDEye.index));
    }

    public void OnSwitchClicked()
    {
        spriteNumber = (++spriteNumber) % 3;
        switch (spriteNumber)
        {
            case 0: image.sprite = defaultSprite; break;
            case 1: image.sprite = angelSprite; break;
            case 2: image.sprite = devilSprite; break;
        }
        TDEye.SetState(tDEye, spriteNumber);
    }
}
