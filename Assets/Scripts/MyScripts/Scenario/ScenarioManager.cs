using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance;

    public List<ScenarioTab> scenarioList;
    public RectTransform content;
    public GameObject scenarioTabPrf;

    public ScrollRect scenarioScrollRect;
    public GameObject scenarioScrollView;

    public bool isScenarioShowing = true;
    public RectTransform showScenarioButton;
    public TextMeshProUGUI showScenarioButtonTMP;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ActivateScenarios(bool b)
    {
        // MapManager.instance.eyeList.ForEach(eye => eye.button.gameObject.SetActive(!b));
        // MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(!b));
        scenarioScrollView.SetActive(b);
        showScenarioButton.gameObject.SetActive(b);
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
        if (isScenarioShowing)
        {
            showScenarioButton.anchoredPosition = new Vector3(15, 50, 0);
            showScenarioButtonTMP.SetText(">");
        }
        else
        {
            showScenarioButton.anchoredPosition = new Vector3(395, 50, 0);
            showScenarioButtonTMP.SetText("<");
        }

        isScenarioShowing = !isScenarioShowing;
        scenarioScrollView.SetActive(isScenarioShowing);
    }

    public void OnApplyScenarioClicked()
    {
        ScenarioTab scenario = scenarioList.Find(scenario => scenario.isActive);
        scenario.scenarioEyeList.ForEach(sEye => TDEye.SetTDEyeState(sEye.tdEye, sEye.guessedID));
        scenario.scenarioGateList.ForEach(sGate => TDGate.SetTDGateState(sGate.tdGate, sGate.isMarked));
    }
}
