using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance;

    public List<ScenarioTab> scenarioList = new List<ScenarioTab>();
    public RectTransform content;
    public GameObject scenarioTabPrf;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetBaseScenario()
    {
        ScenarioTab scenario = AddScenario();
        scenario.deleteButton.gameObject.SetActive(false);
    }

    public ScenarioTab AddScenario()
    {
        ScenarioTab scenario = Instantiate(scenarioTabPrf, content).GetComponent<ScenarioTab>();
        scenario.Init();
        scenarioList.Add(scenario);
        return scenario;
    }

    public void OnAddScenarioClicked() => AddScenario();
}
