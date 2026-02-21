using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    [SerializeField] private bool isStopping;
    public bool IsStopping => isStopping;

    [SerializeField] Sprite tutorialPic1;
    [SerializeField] Sprite tutorialPic2;
    [SerializeField] Sprite tutorialPic3;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void RevisedInit()
    {
        if (GameManager.instance.CurrentStage == 1)
        {
            MapManager.instance.eyeList.ForEach(eye => eye.button.SetActive(false));
            MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(false));
            MapManager.instance.gateList[0].SetSprite(ToD.Truth);
            MapManager.instance.gateList[1].SetSprite(ToD.Devil);
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Truth);

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioButton.gameObject.SetActive(false);

            DialogManager.instance.SetSkipButtonActive(false);
            DialogManager.instance.SetReviewInGamePlayActive(true);
        } 

        else if (GameManager.instance.CurrentStage == 2)
        {
            MapManager.instance.eyeList.ForEach(eye => eye.button.SetActive(false));
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Devil);

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioButton.gameObject.SetActive(false);
        }

        else if (GameManager.instance.CurrentStage == 3)
        {
            ScenarioManager.instance.ActivateScenarios(false);
        }

        else if (GameManager.instance.CurrentStage == 4)
        {
            ScenarioManager.instance.ActivateScenarios(false);
        }
        else if (GameManager.instance.CurrentStage == 8)
        {
            MapManager.instance.eyeList.ForEach(eye => eye.button.SetActive(false));
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Devil);
        }

        else if (GameManager.instance.CurrentStage == TDStage.Ch1StageCount + TDStage.Ch2StageCount + TDStage.Ch3StageCount)
        {
            GamePlay.instance.nextButton.SetActive(false);
        }

        // 정렬 기준 "천사/악마" 비활성화
        if (1 <= GameManager.instance.CurrentStage && GameManager.instance.CurrentStage <= 7)
        {
            LogManager.instance.dropdown.options.RemoveAt(3);
        }
    }

    public IEnumerator DoBeforeSayLine()
    {
        float duration;

        if (GameManager.instance.CurrentStage == 1)
        {
            if (DialogManager.instance.currentLineNumber == 7)
            {
                duration = 1.0f;
                DialogManager.instance.Fade(0f, duration);
                yield return new WaitForSeconds(duration);
                DialogManager.instance.ShowOnlyPicture(tutorialPic1);
            }

            else if (DialogManager.instance.currentLineNumber == 8)
            {
                DialogManager.instance.ShowOnlyPicture(tutorialPic2);
            }

            else if (DialogManager.instance.currentLineNumber == 9)
            {
                DialogManager.instance.ShowOnlyPicture(tutorialPic3);
            }

            // else if (DialogManager.instance.currentLineNumber == 16)
            // {
            //     DialogManager.instance.SetCharacter();
            // }
        }
        
        else if (GameManager.instance.CurrentStage == 2)
        {
            if (DialogManager.instance.currentLineNumber == 5)
            {
                duration = 1.0f;
                DialogManager.instance.Fade(0f, duration);
                yield return new WaitForSeconds(duration);
            }
        }
    }

    public bool BreakDialog()
    {
        // if (GameManager.instance.CurrentStage == 1)
        // {
        //     if (DialogManager.instance.currentLineNumber == 10)
        //     {
        //         StartCoroutine(StopDialogUntil(() => GamePlay.instance.posOnMap == new Vector3Int(3, 2, 0)));
        //         return true;
        //     }

        //     else if (DialogManager.instance.currentLineNumber == 14)
        //     {
        //         StartCoroutine(StopDialogUntil(() => GamePlay.instance.posOnMap == new Vector3Int(3, 1, 0)));
        //         return true;
        //     }

        //     else if (DialogManager.instance.currentLineNumber == 15)
        //     {
        //         StartCoroutine(StopDialogUntil(
        //             () => GamePlay.instance.IsRunning && GamePlay.instance.posOnMap == new Vector3Int(3, 1, 0) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))));
        //         return true;
        //     }
        // }

        return false;
    }

    IEnumerator StopDialogUntil(Func<bool> condition)
    {
        if (isStopping) yield break;

        isStopping = true;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0));
        DialogManager.instance.ExitDialog();
        yield return new WaitUntil(condition);
        DialogManager.instance.ContinueDialog();
        isStopping = false;
    }

    public bool BreakEnteringPos(Vector3Int pos)
    {
        // if (GameManager.instance.CurrentStage == 1)
        // {
        //     if (DialogManager.instance.currentLineNumber <= 15)
        //     {
        //         if (pos == new Vector3Int(3, 0, 0)) return true;
        //     }

        //     if (DialogManager.instance.currentLineNumber <= 14)
        //     {
        //         if (pos == new Vector3Int(2, 1, 0)) return true;
        //     }
        // }

        return false;
    }

    public bool BreakEnteringGate(Vector3Int dir)
    {
        // if (GameManager.instance.CurrentStage == 1)
        // {
        //     if (GamePlay.instance.posOnMap + dir == new Vector3Int(2, 1, 0)) return true;
        // }

        return false;
    }

    public void HighlightTiles(List<int> redBoxData, List<int> blueBoxData)
    {
        if (GameManager.instance.CurrentStage <= 2)
        {
            MapManager.instance.objectList.ForEach(obj => obj.HighlightTile(false));

            if ((RedData)redBoxData[0] == RedData.Gate && (BlueData)blueBoxData[0] == BlueData.Null)
            {
                foreach (TDGate gate in MapManager.instance.gateList)
                {
                    foreach (TDObject obj in MapManager.instance.objectList)
                    {
                        if (Math.Abs(obj.pos.x - gate.pos.x) <= 1 && Math.Abs(obj.pos.y - gate.pos.y) <= 1 && obj.pos != gate.pos)
                            obj.HighlightTile(true);
                    }
                }
            }
            else if ((RedData)redBoxData[0] == RedData.Null && (BlueData)blueBoxData[0] == BlueData.Color)
            {
                foreach (TDData tile in MapManager.instance.tileList)
                {
                    if (tile.color == (TileColor)blueBoxData[1])
                        MapManager.instance.objectList.Find(obj => obj.pos == tile.pos).HighlightTile(true);
                }
            }
            else if ((RedData)redBoxData[0] == RedData.Gate && (BlueData)blueBoxData[0] == BlueData.Color)
            {
                foreach (TDGate gate in MapManager.instance.gateList)
                {
                    foreach (TDData tile in MapManager.instance.tileList)
                    {
                        if (Math.Abs(tile.pos.x - gate.pos.x) <= 1 && Math.Abs(tile.pos.y - gate.pos.y) <= 1 && tile.pos != gate.pos 
                            && tile.color == (TileColor)blueBoxData[1])
                            MapManager.instance.objectList.Find(obj => obj.pos == tile.pos).HighlightTile(true);
                    }
                }
            }
        }

        else if (GameManager.instance.CurrentStage == 8)
        {
            MapManager.instance.eyeList.ForEach(obj => obj.HighlightTile(false));

            if ((RedData)redBoxData[0] == RedData.Map && (BlueData)blueBoxData[0] == BlueData.Null)
            {
                MapManager.instance.eyeList.ForEach(eye => eye.HighlightTile(true));
            }
            else if ((BlueData)blueBoxData[0] == BlueData.Eye)
            {
                foreach (TDEye eye in MapManager.instance.eyeList)
                {
                    if (eye.trueID == (ToD)blueBoxData[1]) eye.HighlightTile(true);
                }
            }

        }
    }
}
