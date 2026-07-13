using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogItem : MonoBehaviour
{
    [SerializeField] bool isSeparator = false;
    [SerializeField] EyeTile eyeTile;
    [SerializeField] TileObject redTileObj;
    [SerializeField] TileObject blueTileObj;
    [SerializeField] TileObject greenTileObj;
    [SerializeField] SpriteSource spriteSource;

    [SerializeField] Image eyeImage;
    [SerializeField] TextMeshProUGUI eyeCodeTmp;
    [SerializeField] TextMeshProUGUI redDataTmp;
    [SerializeField] TextMeshProUGUI blueDataTmp;
    [SerializeField] TextMeshProUGUI greenDataTmp;
    [SerializeField] TextMeshProUGUI answerTmp;

    public bool IsSeparator => isSeparator;
    public EyeTile EyeTile => eyeTile;
    public TileObject RedTileObj => redTileObj;
    public TileObject BlueTileObj => blueTileObj;
    public TileObject GreenTileObj => greenTileObj;

    public void Init(EyeTile eyeTile, TileObject redTileObj, TileObject blueTileObj, TileObject greenTileObj, string answerText)
    {
        this.eyeTile = eyeTile;

        UpdateEyeImage();
        if (eyeTile != null) eyeCodeTmp.SetText(Utils.ConvertToRoman(eyeTile.Code));

        this.redTileObj = redTileObj;
        this.blueTileObj = blueTileObj;
        this.greenTileObj = greenTileObj;

        redDataTmp.SetText(Utils.GetText(redTileObj));
        blueDataTmp.SetText(Utils.GetText(blueTileObj));
        greenDataTmp.SetText(Utils.GetText(greenTileObj));

        answerTmp.SetText(answerText);
    }

    public void InitAsSeparator(EyeTile eyeTile, TileObject redTileObj, TileObject blueTileObj, TileObject greenTileObj, string separatorText)
    {
        isSeparator = true;

        this.eyeTile = eyeTile;
        this.redTileObj = redTileObj;
        this.blueTileObj = blueTileObj;
        this.greenTileObj = greenTileObj;
        
        answerTmp?.SetText(separatorText);
    }

    public void UpdateEyeImage()
    {
        if (eyeTile == null) return;

        switch (eyeTile.MarkedSpecies)
        {
            case Species.NULL: eyeImage.sprite = spriteSource.defaultEye; return;
            case Species.ANGEL: eyeImage.sprite = spriteSource.angelEye; return;
            case Species.DEVIL: eyeImage.sprite = spriteSource.devilEye; return;
        }
    }

    public override bool Equals(object other)
    {
        if (other is LogItem item)
        {
            return eyeTile == item.eyeTile && isSeparator == item.isSeparator && 
                   redTileObj.Data.SequenceEqual(item.redTileObj.Data) && redTileObj.IsHiding == item.redTileObj.IsHiding &&
                   blueTileObj.Data.SequenceEqual(item.blueTileObj.Data) && blueTileObj.IsHiding == item.blueTileObj.IsHiding &&
                   greenTileObj.Data.SequenceEqual(item.greenTileObj.Data) && greenTileObj.IsHiding == item.greenTileObj.IsHiding;
        }
        else 
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
