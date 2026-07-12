using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField] TileObject redTileObj;
    [SerializeField] TileObject blueTileObj;
    [SerializeField] TileObject greenTileObj;

    [SerializeField] Image redQuestionBox;
    [SerializeField] Image blueQuestionBox;
    [SerializeField] Image greenQuestionBox;
    [SerializeField] TextMeshProUGUI redQuestionTmp;
    [SerializeField] TextMeshProUGUI blueQuestionTmp;
    [SerializeField] TextMeshProUGUI greenQuestionTmp;

    private const string trueText = "O", falseText = "X";

    public TileObject RedTileObj => redTileObj;
    public TileObject BlueTileObj => blueTileObj;
    public TileObject GreenTileObj => greenTileObj;

    public bool IsComplete => redTileObj != null && blueTileObj != null && greenTileObj != null;

    public bool IsValid => (redTileObj.Data[0] == (int)RedData.EXIT && (blueTileObj.Data[0] == (int)BlueData.COLOR || blueTileObj.Data[0] == (int)BlueData.POSITION)) ||
                           (redTileObj.Data[0] == (int)RedData.MAP && blueTileObj.Data[0] == (int)BlueData.SPECIES);
    
    public void UpdateQuestion(TileObject tileObj)
    {
        if (tileObj.IsThorn)
        {
            switch (tileObj.Color)
            {
                case TileColor.RED: redTileObj = null; redQuestionTmp.SetText(""); return;
                case TileColor.BLUE: blueTileObj = null; blueQuestionTmp.SetText(""); return;
                case TileColor.GREEN: greenTileObj = null; greenQuestionTmp.SetText(""); return;
            }
        }

        switch (tileObj.Color)
        {
            case TileColor.RED: redTileObj = tileObj; redQuestionTmp.SetText(Utils.GetText(tileObj)); return;
            case TileColor.BLUE: blueTileObj = tileObj; blueQuestionTmp.SetText(Utils.GetText(tileObj)); return;
            case TileColor.GREEN: greenTileObj = tileObj; greenQuestionTmp.SetText(Utils.GetText(tileObj)); return;
        }
    }

    public void ClearQuestion()
    {
        redTileObj = null;
        blueTileObj = null;
        greenTileObj = null;

        redQuestionTmp.SetText("");
        blueQuestionTmp.SetText("");
        greenQuestionTmp.SetText("");
    }

    public string getAnswer(EyeTile eyeTile, Answer answer)
    {
        string result = null;

        int numberData = greenTileObj.Data[1];

        switch ((RedData)redTileObj.Data[0])
        {
            case RedData.EXIT:
                switch ((BlueData)blueTileObj.Data[0])
                {
                    case BlueData.COLOR: 
                        switch ((TileColor)blueTileObj.Data[1])
                        {
                            case TileColor.RED: result = numberData == answer.exitRedCount ? trueText : falseText; break;
                            case TileColor.BLUE: result = numberData == answer.exitBlueCount ? trueText : falseText; break;
                            case TileColor.GREEN: result = numberData == answer.exitGreenCount ? trueText : falseText; break;
                            case TileColor.WHITE: result = numberData == answer.exitWhiteCount ? trueText : falseText; break;
                        }
                        break;
                    case BlueData.POSITION:
                        switch ((Position)blueTileObj.Data[1])
                        {
                            case Position.ROW: result = numberData == answer.exitRow ? trueText : falseText; break;
                            case Position.COL: result = numberData == answer.exitCol ? trueText : falseText; break;
                        }
                        break;
                }
                break;

            case RedData.MAP:
                if ((BlueData)blueTileObj.Data[0] != BlueData.SPECIES) return null;
                else
                {
                    switch ((Species)blueTileObj.Data[1])
                    {
                        case Species.ANGEL: result = numberData == answer.mapAngelCount ? trueText : falseText; break;
                        case Species.DEVIL: result = numberData == answer.mapDevilCount ? trueText : falseText; break;
                    }
                }
                break;
        }

        if (result == null) 
        {
            Debug.LogWarning("invalid question.");
            return null;
        }

        return eyeTile.TureSpecies == Species.ANGEL ? result : result == trueText ? falseText : trueText;
    }
}
