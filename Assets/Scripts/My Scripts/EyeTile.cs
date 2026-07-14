using System.Collections.Generic;
using System.Threading.Tasks;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EyeTile : TileObject
{
    [SerializeField] int code;
    [SerializeField] Species trueSpecies;
    [SerializeField] Species markedSpecies = Species.NULL;
    [SerializeField] GraphicRaycaster raycaster;

    [SerializeField] TextMeshProUGUI codeTmp;
    [SerializeField] TextMeshProUGUI answerTmp;
    [SerializeField] CanvasGroup answerBallon;
    [SerializeField] SpriteRenderer eyeSR;
    [SerializeField] GameObject speciesMark;
    
    public int Code => code;
    public Species TureSpecies => trueSpecies;
    public Species MarkedSpecies => markedSpecies;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Utils.IsClicked(raycaster, speciesMark))
        {
            speciesMark.SetActive(false);
        }
    }

    public override void Init(Vector3Int pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn);
        trueSpecies = (Species)data[1];
    }

    public override void ActivateThorn() { }

    public void SetCode(int code)
    {
        this.code = code;
        codeTmp?.SetText(Utils.ConvertToRoman(code));
    }

    public void MarkSpecies(int species)
    {
        markedSpecies = (Species)species;

        switch ((Species)species)
        {
            case Species.NULL: eyeSR.sprite = spriteSource.defaultEye; break;
            case Species.ANGEL: eyeSR.sprite = spriteSource.angelEye; break;
            case Species.DEVIL: eyeSR.sprite = spriteSource.devilEye; break;
        }

        PuzzleManager.instance.Log.UpdateEyeImages();
    }

    public async void Answer(string answerText)
    {
        Tween.StopAll(answerBallon);

        answerTmp.SetText(answerText);
        answerBallon.alpha = 0.8f;

        await Task.Delay(100);
    
        while (!(!PuzzleManager.instance.IsPaused && Utils.GetDirectionKeyDown()))
        {
            await Task.Yield();
        }

        await Tween.Alpha(answerBallon, 0, 1.0f);
    }
}
