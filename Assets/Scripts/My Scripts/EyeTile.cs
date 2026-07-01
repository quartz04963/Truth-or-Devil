using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EyeTile : TileObject
{
    [SerializeField] Species trueSpecies;
    [SerializeField] Species markedSpecies = Species.Null;
    [SerializeField] TextMeshProUGUI codeText;
    [SerializeField] SpriteRenderer eyeSR;
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite angelSprite;
    [SerializeField] Sprite devilSprite;

    public Species TureSpecies => trueSpecies;
    public Species MarkedSpecies => markedSpecies;

    public override void Init(
        Vector3Int pos, 
        TileColor color, 
        List<int> data, 
        bool isHiding = false, 
        bool isPlaceable = false, 
        bool isThorn = false, 
        Sprite thornSprite = null
        )
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn, thornSprite);
        trueSpecies = (Species)data[1];
    }

    public void SetCode(int num)
    {
        codeText.SetText(Utils.ConvertToRoman(num));
    }

    public void SetMarkedSpecies(int species)
    {
        markedSpecies = (Species)species;

        switch ((Species)species)
        {
            case Species.Null: eyeSR.sprite = defaultSprite; break;
            case Species.Angel: eyeSR.sprite = angelSprite; break;
            case Species.Devil: eyeSR.sprite = devilSprite; break;
        }
    }
}
