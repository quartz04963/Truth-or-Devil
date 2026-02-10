using UnityEngine;
using System;
using System.IO;


[Serializable]
public class SaveData
{
    public int maxStage;
    public bool doCheckBeforeEnteringGate;
    public float bgmVolume;
}

public static class SaveSystem
{
    static string savePath = Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save()
    {
        SaveData data = new SaveData()
        {
            maxStage = GameManager.instance.maxStage,
            doCheckBeforeEnteringGate = GameManager.instance.doCheckBeforeEnteringGate,
            bgmVolume = SoundManager.Instance.GetBgmVolume(),
        };
        string json = JsonUtility.ToJson(data, true);
        
        File.WriteAllText(savePath, json);
    }

    public static void Load()
    {
        if (!File.Exists(savePath)) return;

        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        GameManager.instance.maxStage = data.maxStage;
        GameManager.instance.doCheckBeforeEnteringGate = data.doCheckBeforeEnteringGate;
        SoundManager.Instance.SetBgmVolume(data.bgmVolume);
    }
}
