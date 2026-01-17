using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public static MyCamera instance;
    
    public Camera mainCamera;
    public RectTransform background;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void SetOSizeByMap()
    {
        int maxX = 0, minX = 8, maxY = 0, minY = 8;
        foreach (TDData tile in MapManager.instance.tileList)
        {
            if (tile.pos.x > maxX) maxX = tile.pos.x;
            if (tile.pos.x < minX) minX = tile.pos.x;
            if (tile.pos.y > maxY) maxY = tile.pos.y;
            if (tile.pos.y < minY) minY = tile.pos.y;
        }
        
        int maxL = maxX + 1 - minX >= maxY + 1 - minY ? maxX + 1 - minX : maxY + 1 - minY; 
        mainCamera.transform.position = new Vector3((minX + maxX + 1) / 2f, (minY + maxY + 1) / 2f - 0.5f, -10);
        mainCamera.orthographicSize = (maxL + 7) / 3f;

        background.anchoredPosition = new Vector3((minX + maxX + 1) / 2f, (minY + maxY + 1) / 2f - 0.5f, 0);
        background.localScale = new Vector3(0.01f * ((maxL + 7) / 3f) / 5f, 0.01f * ((maxL + 7) / 3f) / 5f, 1);
    }
}
