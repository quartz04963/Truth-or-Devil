using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance;

    public List<ScenarioTab> scenarioList;
    public RectTransform content;
    public GameObject scenarioTabPrf;

    public ScrollRect scenarioScrollRect;
    public GameObject scenarioScrollView;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ActivateScenarios(bool b)
    {
        MapManager.instance.eyeList.ForEach(eye => eye.button.gameObject.SetActive(!b));
        MapManager.instance.gateList.ForEach(gate => gate.button.gameObject.SetActive(!b));
        scenarioScrollView.SetActive(b);
    }
    
    public void InitBaseScenario()
    {
        scenarioList = new List<ScenarioTab>();
        
        ScenarioTab scenario = AddScenario();
        scenario.deleteButton.enabled = false;
        scenario.deleteButton.image.enabled = false;
        scenario.deleteButton.transform.GetChild(0).gameObject.SetActive(false);
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
        if (GamePlay.instance.isRunning) AddScenario();
    }
}
