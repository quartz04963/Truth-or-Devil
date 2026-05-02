using TMPro;
using UnityEngine;

public class PastDialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI dialogTMP;

    public void Init(string name, string text)
    {
        nameTMP.SetText(name);
        dialogTMP.SetText(text);
    }
}
