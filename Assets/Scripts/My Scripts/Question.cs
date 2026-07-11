using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField] TileObject lastRedTile;
    [SerializeField] TileObject lastBlueTile;
    [SerializeField] TileObject lastGreenTile;

    [SerializeField] Image redQuestionBox;
    [SerializeField] Image blueQuestionBox;
    [SerializeField] Image greenQuestionBox;
    [SerializeField] TextMeshProUGUI redQuestionText;
    [SerializeField] TextMeshProUGUI blueQuestionText;
    [SerializeField] TextMeshProUGUI greenQuestionText;

    public bool IsComplete => lastRedTile != null && lastBlueTile != null && lastGreenTile != null;

    public bool IsValid => (lastRedTile.Data[0] == (int)RedData.EXIT && (lastBlueTile.Data[0] == (int)BlueData.COLOR || lastBlueTile.Data[0] == (int)BlueData.POSITION)) ||
                           (lastRedTile.Data[0] == (int)RedData.MAP && lastBlueTile.Data[0] == (int)BlueData.SPECIES);
    
    public void UpdateQuestion(TileObject tileObject)
    {
        if (tileObject.IsThorn)
        {
            switch (tileObject.Color)
            {
                case TileColor.RED: lastRedTile = null; redQuestionText.SetText(""); return;
                case TileColor.BLUE: lastBlueTile = null; blueQuestionText.SetText(""); return;
                case TileColor.GREEN: lastGreenTile = null; greenQuestionText.SetText(""); return;
            }
        }

        switch (tileObject.Color)
        {
            case TileColor.RED: lastRedTile = tileObject; redQuestionText.SetText(Utils.GetText(tileObject)); return;
            case TileColor.BLUE: lastBlueTile = tileObject; blueQuestionText.SetText(Utils.GetText(tileObject)); return;
            case TileColor.GREEN: lastGreenTile = tileObject; greenQuestionText.SetText(Utils.GetText(tileObject)); return;
        }
    }

    public void ClearQuestion()
    {
        lastRedTile = null;
        lastBlueTile = null;
        lastGreenTile = null;

        redQuestionText.SetText("");
        blueQuestionText.SetText("");
        greenQuestionText.SetText("");
    }

    
}
