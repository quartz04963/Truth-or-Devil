using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioGate : MonoBehaviour
{
    public TDGate tdGate;
    public bool isMarked;

    public TextMeshProUGUI tmp;
    public Image XmarkImg;

    public void Init(TDGate _tdGate)
    {
        tdGate = _tdGate;
        tdGate.isMarked = false;
        tmp.SetText((char)('A' + tdGate.index));
    }

    public void OnClicked()
    {
        if (!GamePlay.instance.IsRunning) return;
        
        isMarked = !isMarked;
        XmarkImg.enabled = isMarked;
        // TDGate.SetTDGateState(tdGate, guessedID);
    }
}
