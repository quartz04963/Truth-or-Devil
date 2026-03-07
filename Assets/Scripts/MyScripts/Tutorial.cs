using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    [SerializeField] private bool isStopping;
    public bool IsStopping => isStopping;

    [SerializeField] Sprite[] tutorialPictures;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void RevisedInit()
    {
        if (GameManager.Instance.CurrentStage == 1)
        {
            MapManager.instance.eyeList.ForEach(eye => eye.button.SetActive(false));
            MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(false));
            MapManager.instance.gateList[0].SetSprite(ToD.Devil);
            MapManager.instance.gateList[1].SetSprite(ToD.Truth);
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Truth);

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioRT.gameObject.SetActive(false);

            // DialogManager.instance.SetSkipButtonActive(false);
            // DialogManager.instance.SetReviewInGamePlayActive(true);
        } 

        else if (GameManager.Instance.CurrentStage == 2)
        {
            MapManager.instance.eyeList.ForEach(eye => eye.button.SetActive(false));
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Devil);

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioRT.gameObject.SetActive(false);
        }

        else if (GameManager.Instance.CurrentStage == 3)
        {
            ScenarioManager.instance.ActivateScenarios(false);
        }

        else if (GameManager.Instance.CurrentStage == 4)
        {
            ScenarioManager.instance.ActivateScenarios(false);
        }

        else if (GameManager.Instance.CurrentStage == 7)
        {
            MapManager.instance.eyeList[0].button.SetActive(false);
            MapManager.instance.eyeList[2].button.SetActive(false);
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Devil);
            TDEye.SetTDEyeState(MapManager.instance.eyeList[2], ToD.Devil);

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioRT.gameObject.SetActive(false);
        }

        else if (GameManager.Instance.CurrentStage == StageData.Ch1StageCount + StageData.Ch2StageCount + StageData.Ch3StageCount)
        {
            GamePlay.instance.nextButton.SetActive(false);
        }

        // 정렬 기준 "천사/악마" 비활성화
        if (1 <= GameManager.Instance.CurrentStage && GameManager.Instance.CurrentStage <= 6)
        {
            LogManager.instance.dropdown.options.RemoveAt(3);
        }
    }

    public IEnumerator DoBeforeSayLine()
    {
        float duration;

        if (GameManager.Instance.CurrentStage == 1 && !GamePlay.instance.isCleared)
        {
            if (DialogSystem.instance.currentLineNumber == 9)
            {
                duration = 1.0f;
                DialogSystem.instance.Fade(0f, duration);
                yield return new WaitForSeconds(duration);
                DialogSystem.instance.ShowOnlyPicture(tutorialPictures[0]);
            }

            else if (DialogSystem.instance.currentLineNumber == 10)
            {
                DialogSystem.instance.ShowOnlyPicture(tutorialPictures[1]);
            }

            else if (DialogSystem.instance.currentLineNumber == 11)
            {
                DialogSystem.instance.ShowOnlyPicture(tutorialPictures[2]);
            }

            else if (DialogSystem.instance.currentLineNumber == 12)
            {
                DialogSystem.instance.ShowOnlyPicture(tutorialPictures[3]);
            }


            // else if (DialogManager.instance.currentLineNumber == 16)
            // {
            //     DialogManager.instance.SetCharacter();
            // }
        }
        
        else if (GameManager.Instance.CurrentStage == 2 && !GamePlay.instance.isCleared)
        {
            if (DialogSystem.instance.currentLineNumber == 5)
            {
                duration = 1.0f;
                DialogSystem.instance.Fade(0f, duration);
                yield return new WaitForSeconds(duration);
            }
        }

        else if (GameManager.Instance.CurrentStage == 3 && !GamePlay.instance.isCleared)
        {
            if (DialogSystem.instance.currentLineNumber == 11)
            {
                duration = 1.0f;
                DialogSystem.instance.Fade(0f, duration);
                yield return new WaitForSeconds(duration);
                DialogSystem.instance.ShowOnlyPicture(tutorialPictures[4]);
            }

            else if (DialogSystem.instance.currentLineNumber == 12)
            {
                DialogSystem.instance.ShowOnlyPicture(tutorialPictures[5]);
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
        DialogSystem.instance.ExitDialog();
        yield return new WaitUntil(condition);
        DialogSystem.instance.ContinueDialog();
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
        if (GameManager.Instance.CurrentStage == 1)
        {
            MapManager.instance.objectList.ForEach(obj => obj.HighlightTile(false));
            MapManager.instance.gateList.ForEach(gate => gate.HighlightArea(false));

            if ((RedData)redBoxData[0] == RedData.Gate && (BlueData)blueBoxData[0] == BlueData.Null)
            {
                MapManager.instance.gateList.ForEach(gate => gate.HighlightArea(true));
            }

            else if ((RedData)redBoxData[0] == RedData.Null && (BlueData)blueBoxData[0] == BlueData.Color)
            {
                foreach (TDTileData tile in MapManager.instance.tileList)
                {
                    if (tile.color == (TileColor)blueBoxData[1]) MapManager.instance.objectList.Find(obj => obj.pos == tile.pos).HighlightTile(true);
                }
            }

            else if ((RedData)redBoxData[0] == RedData.Gate && (BlueData)blueBoxData[0] == BlueData.Color)
            {
                MapManager.instance.gateList.ForEach(gate => gate.HighlightArea(true, false));

                foreach (TDGate gate in MapManager.instance.gateList)
                {
                    foreach (TDTileData tile in MapManager.instance.tileList)
                    {
                        if (Math.Abs(tile.pos.x - gate.pos.x) <= 1 && Math.Abs(tile.pos.y - gate.pos.y) <= 1 && tile.pos != gate.pos 
                            && tile.color == (TileColor)blueBoxData[1])
                            MapManager.instance.objectList.Find(obj => obj.pos == tile.pos).HighlightTile(true);
                    }
                }
            }
        }

        else if (GameManager.Instance.CurrentStage == 7)
        {
            MapManager.instance.objectList.ForEach(obj => obj.HighlightTile(false));

            if ((RedData)redBoxData[0] == RedData.Map)
            {
                MapManager.instance.objectList.ForEach(obj => obj.HighlightTile(true, false));
            }
            if ((BlueData)blueBoxData[0] == BlueData.Eye)
            {
                foreach (TDEye eye in MapManager.instance.eyeList)
                {
                    if (eye.guessedID == (ToD)blueBoxData[1]) eye.HighlightTile(true);
                }
            }
        }
    }
}
