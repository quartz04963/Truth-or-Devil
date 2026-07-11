using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    [SerializeField] Camera mainCamera;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void SetCenter(Stage stage)
    {
        float centerX = (stage.range.right + stage.range.left) / 2f;
        float centerY = (stage.range.top + stage.range.bottom) / 2f;

        transform.position = new Vector3(centerX, centerY, -10);


        int width = stage.range.right - stage.range.left;
        int height = stage.range.top - stage.range.bottom;

        float newUnitLength = Math.Max(width, height) / 6f;

        mainCamera.orthographicSize = newUnitLength * 5f;
        transform.localScale = new Vector3(newUnitLength, newUnitLength, 1);
    }
}
