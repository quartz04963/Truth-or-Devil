using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EyeTile : TileObject
{
    [SerializeField] Species trueSpecies;
    [SerializeField] Species markedSpecies = Species.NULL;
    [SerializeField] TextMeshProUGUI codeText;
    [SerializeField] SpriteRenderer eyeSR;

    public Species TureSpecies => trueSpecies;
    public Species MarkedSpecies => markedSpecies;

    public override void Init(Vector3 pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn);
        trueSpecies = (Species)data[1];
    }

    public override void ActivateThorn() { }

    public void SetCode(int num)
    {
        codeText.SetText(Utils.ConvertToRoman(num));
    }

    public void SetMarkedSpecies(int species)
    {
        markedSpecies = (Species)species;

        switch ((Species)species)
        {
            case Species.NULL: eyeSR.sprite = spriteSource.defaultSprite; break;
            case Species.ANGEL: eyeSR.sprite = spriteSource.angelSprite; break;
            case Species.DEVIL: eyeSR.sprite = spriteSource.devilSprite; break;
        }
    }
}
