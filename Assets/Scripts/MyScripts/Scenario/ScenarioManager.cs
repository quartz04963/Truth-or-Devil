using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance;

    public List<ScenarioTab> scenarioList;
    public RectTransform content;
    public GameObject scenarioTabPrf;

    public ScrollRect scenarioScrollRect;
    public GameObject scenarioScrollView;

    public bool isShowing;
    public bool isSliding;
    public RectTransform scenarioRT;
    public RectTransform showScenarioRT;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ActivateScenarios(bool isActive)
    {
        // MapManager.instance.eyeList.ForEach(eye => eye.button.gameObject.SetActive(!b));
        // MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(!b));
        scenarioScrollView.SetActive(isActive);
        showScenarioRT.gameObject.SetActive(isActive);
    }
    
    public void InitBaseScenario()
    {
        scenarioList = new List<ScenarioTab>();
        
        ScenarioTab scenario = AddScenario();
    }

    public ScenarioTab AddScenario()
    {
        ScenarioTab scenario = Instantiate(scenarioTabPrf, content).GetComponent<ScenarioTab>();
        scenario.Init();
        scenarioList.Add(scenario);
        StartCoroutine(ScrollToBottom());
        return scenario;
    }

    IEnumerator ScrollToBottom()
    {
        yield return null;
        scenarioScrollRect.verticalNormalizedPosition = 0f;
    }

    public void OnAddScenarioClicked() 
    {
        if (GamePlay.instance.IsRunning) AddScenario();
    }

    public void OnShowScenarioClicked()
    {
        if (isSliding) return;

        isShowing = !isShowing;

        Sequence seq = Sequence.Create();
        seq.ChainCallback(() => isSliding = true);

        if (isShowing)
        {
            seq.Chain(Tween.UIAnchoredPosition(showScenarioRT, endValue: new Vector3(-120, 40, 0), duration: 0.2f));
            seq.ChainDelay(0.1f);
            seq.Chain(Tween.UIAnchoredPosition(scenarioRT, endValue: new Vector3(215, 520, 0), duration: 0.2f));
        }
        else
        {
            seq.Chain(Tween.UIAnchoredPosition(scenarioRT, endValue: new Vector3(-215, 520, 0), duration: 0.2f));
            seq.ChainDelay(0.1f);
            seq.Chain(Tween.UIAnchoredPosition(showScenarioRT, endValue: new Vector3(120, 40, 0), duration: 0.2f));
        }
        seq.ChainCallback(() => isSliding = false);
    }

    public void OnApplyScenarioClicked()
    {
        ScenarioTab scenario = scenarioList.Find(scenario => scenario.isSelected);
        scenario.scenarioEyeList.ForEach(sEye => TDEye.SetTDEyeState(sEye.tdEye, sEye.guessedID));
        scenario.scenarioGateList.ForEach(sGate => TDGate.SetTDGateState(sGate.tdGate, sGate.isMarked));
    }
}
