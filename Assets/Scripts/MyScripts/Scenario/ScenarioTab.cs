using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioTab : MonoBehaviour
{
    public bool isActive;
    public Image rimImage;
    public GameObject eyeRow1, eyeRow2, gateRow;
    public Button button1, button2, button3, deleteButton;
    public GameObject scenarioEyePrf, scenarioGatePrf;
    public List<ScenarioEye> scenarioEyeList;
    public List<ScenarioGate> scenarioGateList;

    public void Init()
    {
        int eyeCount = MapManager.instance.eyeList.Count;
        if (eyeCount > 4) {
            eyeRow2.SetActive(true);
            rimImage.rectTransform.sizeDelta = new Vector2(512, 360);
        }
        for (int i = 0; i < eyeCount; i++)
        {
            ScenarioEye eye = i < 4 ?
                Instantiate(scenarioEyePrf, eyeRow1.transform).GetComponent<ScenarioEye>() : Instantiate(scenarioEyePrf, eyeRow2.transform).GetComponent<ScenarioEye>();
            eye.Init(MapManager.instance.eyeList.Find(eye => eye.index == i));
            scenarioEyeList.Add(eye);
        }

        int gateCount = MapManager.instance.gateList.Count;
        for (int i = 0; i < gateCount; i++)
        {
            ScenarioGate gate = Instantiate(scenarioGatePrf, gateRow.transform).GetComponent<ScenarioGate>();
            gate.Init(MapManager.instance.gateList.Find(gate => gate.index == i));
            scenarioGateList.Add(gate);
        }

        button1.gameObject.transform.SetAsLastSibling();
        if (eyeCount > 4) button2.gameObject.transform.SetAsLastSibling();
        button3.gameObject.transform.SetAsLastSibling();

        ScenarioManager.instance.scenarioList.ForEach(scenario => scenario.Activate(false));
        Activate(true);
    }

    public void Activate(bool b)
    {
        button1.gameObject.SetActive(!b);
        button2.gameObject.SetActive(!b);
        button3.gameObject.SetActive(!b);
        // scenarioEyeList.ForEach(sEye => sEye.button.enabled = b); 
        // scenarioGateList.ForEach(sGate => sGate.button.enabled = b);

        rimImage.enabled = b;

        // if (b) {
        //     scenarioEyeList.ForEach(sEye => TDEye.SetTDEyeState(sEye.tdEye, sEye.guessedID));
        //     scenarioGateList.ForEach(sGate => TDGate.SetTDGateState(sGate.tdGate, sGate.guessedID));
        // }
        
        isActive = b;
    }

    public void OnClicked()
    {
        if (!GamePlay.instance.IsRunning) return;

        ScenarioManager.instance.scenarioList.ForEach(scenario => scenario.Activate(false));
        Activate(true);
    }

    public void OnDeleteClicked()
    {
        if (!GamePlay.instance.IsRunning) return;
        
        if (isActive && ScenarioManager.instance.scenarioList.Count >= 2)
        {
            ScenarioManager.instance.scenarioList[ScenarioManager.instance.scenarioList.Count - 2].Activate(true);
        }
        ScenarioManager.instance.scenarioList.Remove(this);
        Destroy(gameObject);
    }
}
