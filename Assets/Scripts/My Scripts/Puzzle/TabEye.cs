using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabEye : MonoBehaviour
{
    [SerializeField] EyeTile eyeTile;
    [SerializeField] Species markedSpecies;

    [SerializeField] Image image;
    [SerializeField] SpriteSource spriteSource;
    [SerializeField] TextMeshProUGUI indexTmp;

    public void Init(EyeTile eyeTile)
    {
        this.eyeTile = eyeTile;

        indexTmp.SetText(Utils.ConvertToRoman(eyeTile.Index));
    }
     
    public void OnClicked()
    {
        switch (markedSpecies)
        {
            case Species.NULL: markedSpecies = Species.ANGEL; image.sprite = spriteSource.angelEye; break;
            case Species.ANGEL: markedSpecies = Species.DEVIL; image.sprite = spriteSource.devilEye; break;
            case Species.DEVIL: markedSpecies = Species.NULL; image.sprite = spriteSource.defaultEye; break;
        }
    }

    public void Apply()
    {
        eyeTile.MarkSpecies((int)markedSpecies);
    }
}
