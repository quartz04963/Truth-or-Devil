using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioGate : MonoBehaviour
{
    public TDGate tdGate;
    public ToD guessedID;
    public Image image;
    public Sprite defaultSprite, heavenSprite, hellSprite;
    public TextMeshProUGUI tmp;
    public Button button;

    public void Init(TDGate _tdGate)
    {
        tdGate = _tdGate;
        tdGate.guessedID = ToD.Null;
        image.sprite = defaultSprite;
        tmp.SetText((char)('A' + tdGate.index));
    }

    public void OnClicked()
    {
        if (!GamePlay.instance.isRunning) return;
        
        guessedID = (ToD)(((int)guessedID + 1) % 3);
        switch (guessedID)
        {
            case ToD.Null: image.sprite = defaultSprite; break;
            case ToD.Truth: image.sprite = heavenSprite; break;
            case ToD.Devil: image.sprite = hellSprite; break;
        }
        TDGate.SetTDGateState(tdGate, guessedID);
    }
}
