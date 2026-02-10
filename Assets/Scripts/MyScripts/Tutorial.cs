using System;
using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial instance;

    [SerializeField] private bool isStopping;
    public bool IsStopping => isStopping;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void RevisedInit()
    {
        if (GameManager.instance.CurrentStage == 1)
        {
            // 임시
            MapManager.instance.eyeList.ForEach(eye => eye.button.gameObject.SetActive(false));
            MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(false));

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioButton.gameObject.SetActive(false);
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Devil);

            DialogManager.instance.SetSkipButtonActive(false);
            DialogManager.instance.SetReviewInGamePlayActive(true);
        } 

        else if (GameManager.instance.CurrentStage == 2)
        {
            // 임시
            MapManager.instance.eyeList.ForEach(eye => eye.button.gameObject.SetActive(false));
            MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(false));

            ScenarioManager.instance.scenarioScrollView.SetActive(false);
            ScenarioManager.instance.showScenarioButton.gameObject.SetActive(false);
            TDEye.SetTDEyeState(MapManager.instance.eyeList[0], ToD.Truth);
        }

        else if (GameManager.instance.CurrentStage == 3)
        {
            ScenarioManager.instance.ActivateScenarios(false);
        }

        else if (GameManager.instance.CurrentStage == 4)
        {
            ScenarioManager.instance.ActivateScenarios(false);
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
            }
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
        if (GameManager.instance.CurrentStage == 1)
        {
            if (DialogManager.instance.currentLineNumber == 10)
            {
                StartCoroutine(StopDialogUntil(() => GamePlay.instance.posOnMap == new Vector3Int(3, 2, 0)));
                return true;
            }

            else if (DialogManager.instance.currentLineNumber == 14)
            {
                StartCoroutine(StopDialogUntil(() => GamePlay.instance.posOnMap == new Vector3Int(3, 1, 0)));
                return true;
            }

            else if (DialogManager.instance.currentLineNumber == 15)
            {
                StartCoroutine(StopDialogUntil(
                    () => GamePlay.instance.posOnMap == new Vector3Int(3, 1, 0) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))));
                return true;
            }
        }

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
        if (GameManager.instance.CurrentStage == 1)
        {
            if (DialogManager.instance.currentLineNumber <= 15)
            {
                if (pos == new Vector3Int(3, 0, 0)) return true;
            }

            if (DialogManager.instance.currentLineNumber <= 14)
            {
                if (pos == new Vector3Int(2, 1, 0)) return true;
            }
        }

        return false;
    }

    public bool BreakEnteringGate(Vector3Int dir)
    {
        if (GameManager.instance.CurrentStage == 1)
        {
            if (GamePlay.instance.posOnMap + dir == new Vector3Int(2, 1, 0)) return true;
        }

        return false;
    }
}
