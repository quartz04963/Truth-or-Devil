using System.Collections.Generic;
using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageGateTile : TileObject
{
    [SerializeField] int chapter;
    [SerializeField] int stage;
    [SerializeField] bool isOpened;
    [SerializeField] GraphicRaycaster raycaster;

    [SerializeField] TextMeshProUGUI stageNumberTmp;
    [SerializeField] Image lockImg;
    [SerializeField] GameObject entranceCheck;

    public int Chapter => chapter;
    public int Stage => stage;

    void Start()
    {
        Init(pos, color, data);

        int maxChapter = TransitionManager.instance.MaxChapter;
        int maxStage = TransitionManager.instance.MaxStage;

        isOpened = maxChapter > chapter || (maxChapter == chapter && maxStage >= stage);
        lockImg.gameObject.SetActive(!isOpened);
    }

    void Update()
    {
        if (entranceCheck.activeSelf)
        {
            if (Input.GetMouseButtonDown(0) && !Utils.IsClicked(raycaster, entranceCheck))
            {
                entranceCheck.SetActive(false);
            } 
            if (Utils.GetDirectionKeyDown() && !StagesManager.instance.Player.IsEntering(this))
            {
                entranceCheck.SetActive(false);
            }
        }
    }

    public override void Init(Vector3Int pos, TileColor color, List<int> data, bool isHiding = false, bool isPlaceable = false, bool isThorn = false)
    {
        base.Init(pos, color, data, isHiding, isPlaceable, isThorn);

        stageNumberTmp.SetText(ZString.Concat(chapter, "-", stage));
    }

    public override void ActivateThorn() { }

    public void CheckEntrance()
    {
        if (!isOpened) return;

        entranceCheck.SetActive(true);
    }

    public void Enter(bool isEntering)
    {
        entranceCheck.SetActive(false);

        if (isEntering)
        {
            TransitionManager.instance.SetCurrentChapterAndStage(chapter, stage);
            
            TransitionManager.instance.Transit("Puzzle");
        }
    }
}
