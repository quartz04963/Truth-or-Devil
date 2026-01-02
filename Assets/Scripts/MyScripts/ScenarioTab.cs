using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioTab : MonoBehaviour
{
    public Image backgroundImg;
    public GameObject row1, row2;
    public Button button1, button2, deleteButton;
    public GameObject scenarioEyePrf;
    public List<ScenarioEye> scenarioEyeList = new List<ScenarioEye>();

    public void Init()
    {
        int eyeCount = MapManager.instance.mapEyeCount.Sum();

        if (eyeCount > 4) row2.SetActive(true);

        for (int i = 0; i < eyeCount; i++)
        {
            ScenarioEye eye = i < 4 ?
                Instantiate(scenarioEyePrf, row1.transform).GetComponent<ScenarioEye>() : Instantiate(scenarioEyePrf, row2.transform).GetComponent<ScenarioEye>();
            eye.Init((TDEye)MapManager.instance.objectList.Find(obj => obj is TDEye eye && eye.index == i));
            scenarioEyeList.Add(eye);
        }

        button1.gameObject.transform.SetAsLastSibling();
        if (eyeCount > 4) button2.gameObject.transform.SetAsLastSibling();

        OnClicked();
    }

    public void Activate(bool b)
    {
        button1.gameObject.SetActive(!b);
        button2.gameObject.SetActive(!b);
        scenarioEyeList.ForEach(sEye => sEye.button.gameObject.SetActive(b)); 
        if (b) scenarioEyeList.ForEach(sEye => TDEye.SetState(sEye.tDEye, sEye.spriteNumber));

        backgroundImg.color = b? new Color(1,1,1) : new Color(0,0,0);
    }

    public void OnClicked()
    {
        ScenarioManager.instance.scenarioList.ForEach(scenario => scenario.Activate(false));
        Activate(true);
    }

    public void OnDeleteClicked()
    {
        ScenarioManager.instance.scenarioList.Remove(this);
        ScenarioManager.instance.scenarioList[ScenarioManager.instance.scenarioList.Count - 1].Activate(true);
        Destroy(gameObject);
    }
}
