using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Cysharp.Text;

public static class MyUtils
{
    public static Vector3 Offset = new Vector3(0.5f, 0.5f, 0);

    public static string ConvertToRoman(int num)
    {        
        switch (num)
        {
            case 1: return "I";
            case 2: return "II";
            case 3: return "III";
            case 4: return "IV";
            case 5: return "V";
            case 6: return "VI";
            case 7: return "VII";
            case 8: return "VIII";
            default: return "Error";
        }    
    }

    public static void LoadAllDialogs()
    {
        DialogData.DialogList = new List<TDDialog>();

        string path;
        for (int i = 1; i <= StageDataList.StageCount; i++)
        {
            path = Path.Combine(Application.streamingAssetsPath, ZString.Format("Dialogs/{0}p.tsv", i));
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path); //안드로이드는 ReadAllText가 안 된다고...
                DialogData.DialogList.Add(new TDDialog(i, true, ParseTSV(text)));
            }

            path = Path.Combine(Application.streamingAssetsPath, ZString.Format("Dialogs/{0}e.tsv", i));
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                DialogData.DialogList.Add(new TDDialog(i, false, ParseTSV(text)));
            }
        }
    }

    static List<TDLine> ParseTSV(string tsv)
    {
        List<TDLine> list = new List<TDLine>();

        string[] lines = tsv.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(lines[i])) continue;

            string[] cols = lines[i].Split('\t');

            TDLine tdLine = new TDLine(cols[0], cols[1]);
            list.Add(tdLine);
        }

        return list;
    }
}
