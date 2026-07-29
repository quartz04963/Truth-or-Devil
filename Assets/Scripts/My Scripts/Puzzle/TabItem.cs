using System.Collections.Generic;
using UnityEngine;

public class TabItem : MonoBehaviour
{
    [SerializeField] Transform eyesTransform;
    [SerializeField] Transform gatesTransform;
    [SerializeField] GameObject button;
    [SerializeField] GameObject buttons;
    
    private List<TabEye> tabEyes = new List<TabEye>();
    private List<TabGate> tabGates = new List<TabGate>();

    public void Init(GameObject tabEyePrf, GameObject tabGatePrf, Map map)
    {
        foreach (EyeTile eye in map.eyes)
        {
            TabEye tabEye = Instantiate(tabEyePrf, eyesTransform).GetComponent<TabEye>();
            tabEye.Init(eye);
            tabEyes.Add(tabEye);
        }

        foreach (GateTile gate in map.gates)
        {
            TabGate tabGate = Instantiate(tabGatePrf, gatesTransform).GetComponent<TabGate>();
            tabGate.Init(gate);
            tabGates.Add(tabGate);
        }
    }

    public void Select(bool isSelected)
    {
        if (isSelected) PuzzleManager.instance.Tab.DeselectAll();

        button.SetActive(!isSelected);
        buttons.SetActive(isSelected);

        PuzzleManager.instance.Tab.RebuildLayout();
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public void Apply()
    {
        foreach (TabEye tabEyes in tabEyes)
        {
            tabEyes.Apply();
        }

        foreach (TabGate tabGates in tabGates)
        {
            tabGates.Apply();
        }
    }
}
