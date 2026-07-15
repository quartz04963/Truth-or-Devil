using Cysharp.Text;
using TMPro;
using UnityEngine;

public class TabGate : MonoBehaviour
{
    [SerializeField] GateTile gateTile;
    [SerializeField] bool isMarked;

    [SerializeField] GameObject xMark;
    [SerializeField] TextMeshProUGUI indexTmp;

    public void Init(GateTile gateTile)
    {
        this.gateTile = gateTile;
        
        indexTmp.SetText(ZString.Concat((char)('A' + gateTile.Index - 1)));
    }

    public void OnClicked()
    {
        isMarked = !isMarked;
        xMark.SetActive(isMarked);
    }

    public void Apply()
    {
        if (isMarked != gateTile.IsMarked) gateTile.Mark();
    }
}
