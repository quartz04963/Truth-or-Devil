using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{    
    [SerializeField] Camera mainCamera;
    [SerializeField] RectTransform background;

    public void InitOSize()
    {
        int maxX = MapManager.instance.currentStageData.maxX + 1;
        int minX = MapManager.instance.currentStageData.minX;
        int maxY = MapManager.instance.currentStageData.maxY + 1;
        int minY = MapManager.instance.currentStageData.minY;

        int maxL = maxX - minX >= maxY - minY ? maxX - minX : maxY - minY; 
        mainCamera.transform.position = new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f - 0.5f, -10);
        mainCamera.orthographicSize = (maxL + 7) / 3f;

        background.anchoredPosition = new Vector3((minX + maxX) / 2f, (minY + maxY) / 2f - 0.5f, 0);
        background.localScale = new Vector3(0.01f * ((maxL + 7) / 3f) / 5f, 0.01f * ((maxL + 7) / 3f) / 5f, 1);
    }
}
