using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Tab : MonoBehaviour
{
    [SerializeField] Map map;
    [SerializeField] Transform addButton;
    [SerializeField] Transform content;
    [SerializeField] RectTransform contentRT;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] GameObject tabItemPrf;
    [SerializeField] GameObject tabEyePrf;
    [SerializeField] GameObject tabGatePrf;

    public void AddItem()
    {
        TabItem tabItem = Instantiate(tabItemPrf, content).GetComponent<TabItem>();

        tabItem.Init(tabEyePrf, tabGatePrf, map);
        tabItem.Select(true);

        addButton.SetAsLastSibling();

        scrollRect.verticalNormalizedPosition = 0f;
    }

    public void DeselectAll()
    {
        foreach (Transform child in content)
        {
            if (child.TryGetComponent(out TabItem tabItem)) tabItem.Select(false);
        }
    }

    public void RebuildLayout()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRT);
    }
}
