using UnityEngine;

public static class Utils
{
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
            default: return null;
        }
    }

    public static string GetText(TileData tileData)
    {
        string result;

        switch (tileData.color)
        {
            case TileColor.RED:
                result = tileData.data[0] == (int)RedData.EXIT ? "EXIT" : 
                        tileData.data[0] == (int)RedData.MAP ? "MAP" : null;
                break;
            case TileColor.BLUE:
                switch ((BlueData)tileData.data[0])
                {
                    case BlueData.COLOR: 
                        result = tileData.data[1] == (int)TileColor.RED ? "RED" : 
                                 tileData.data[1] == (int)TileColor.BLUE ? "BLUE" : 
                                 tileData.data[1] == (int)TileColor.GREEN ? "GREEN" :
                                 tileData.data[1] == (int)TileColor.WHITE ? "WHITE" : null;
                        break;
                    case BlueData.POSITION:
                        result = tileData.data[1] == (int)Position.ROW ? "ROW" :
                                 tileData.data[1] == (int)Position.COL ? "COL" : null;
                        break;
                    case BlueData.SPECIES:
                        result = tileData.data[1] == (int)Species.ANGEL ? "ANGEL" :
                                 tileData.data[1] == (int)Species.DEVIL ? "DEVIL" : null;
                        break;
                    default: result = null; break;
                }
                break;
            case TileColor.GREEN:
                switch ((GreenData)tileData.data[0])
                {
                    case GreenData.EQ: result = "" + tileData.data[1]; break;
                    default: result = null; break;
                }
                break;
            case TileColor.WHITE:
                result = tileData.data[0] == (int)WhiteData.NULL ? "" : null; 
                break;
            default: result = null; break;
        }

        if (result != null && tileData.isHiding) result = "???";

        return result;
    }

    public static string GetText(TileObject tileObj)
    {
        TileData tileData = new TileData(Vector3Int.zero, tileObj.Color, tileObj.Data, tileObj.IsHiding);
        
        return GetText(tileData);
    }
}
