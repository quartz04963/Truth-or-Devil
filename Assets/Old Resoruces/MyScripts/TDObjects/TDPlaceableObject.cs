using PrimeTween;
using UnityEngine;

public class TDPlaceableObject : TDText
{
    public static Vector3Int OutPos = new Vector3Int(-1, -1, 0);
    
    private Vector3 palettePos;
    private Vector3 returnPos;
    private Vector3 offset;
    private bool isDragging = false;
    public bool IsDragging => isDragging;
    private bool isPlaced = false;

    public void Init(Vector3 palettePos, TileData tileData, string text)
    {
        this.palettePos = palettePos;
        returnPos = palettePos;
        base.Init(tileData, text);

        gameObject.transform.position = palettePos;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.transform == transform)
            {
                if (GamePlay.instance.IsRunning && pos != GamePlay.instance.posOnMap) isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            transform.position = mousePos + (Vector2)offset;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            int maxX = MapManager.instance.currentStageData.maxX + 1;
            int minX = MapManager.instance.currentStageData.minX;
            int maxY = MapManager.instance.currentStageData.maxY + 1;
            int minY = MapManager.instance.currentStageData.minY;

            if (mousePos.x < minX || mousePos.x > maxX || 
                mousePos.y < minY || mousePos.y > maxY || 
                MapManager.instance.map.Find(obj => !obj.tileData.isPlaceable && obj.pos == Vector3Int.FloorToInt(mousePos)) != null)
            {
                Return();
            }
            else
            {
                foreach (TDPlaceableObject pobj in MapManager.instance.placeableObjects)
                {
                    if (GamePlay.instance.posOnMap == pobj.pos) {
                        Return();
                        return; 
                    }
                }

                Place();
            }  
        }
    }

    public void Place()
    {
        pos = Vector3Int.FloorToInt(transform.position);
        returnPos = pos + MyUtils.Offset;
        transform.position = returnPos;

        foreach (TDPlaceableObject pobj in MapManager.instance.placeableObjects)
        {
            if (pobj != this && pobj.pos == pos && pobj.isPlaced) pobj.Remove();
        }

        isPlaced = true;
        isDragging = false;
    }

    public void Return()
    {
        Tween.Position(transform, returnPos, 0.1f);
        isDragging = false;
    }

    public void Remove()
    {
        pos = OutPos;
        returnPos = palettePos;
        Tween.Position(transform, returnPos, 0.1f);

        isPlaced = false;
    }
}
