using System.Collections.Generic;

public readonly struct TDLine
{
    public readonly string name;
    public readonly string line;

    public TDLine(string name, string line)
    {
        this.name = name;
        this.line = line;
    }
}

public readonly struct TDDialog
{
    public readonly int stage;
    public readonly bool isProlog;
    public readonly List<TDLine> lineList;

    public TDDialog(int stage, bool isProlog, List<TDLine> lineList)
    {
        this.stage = stage;
        this.isProlog = isProlog;
        this.lineList = lineList;
    }
}

public static class DialogData
{
    public static TDDialog VidelPressure = new TDDialog(
        0,
        false,
        new List<TDLine>
        {
            new TDLine("비델", "..."),
        }
    );

    public static TDDialog GameOver = new TDDialog(
        0, 
        false, 
        new List<TDLine>
        {
            new TDLine("비델", "자, 참가자 님의 결과는...!"),
            new TDLine("비델", "아쉽게도 실패입니다! 안녕히 계세요!"),
        }
    );

    public static TDDialog StageClear = new TDDialog(
        0, 
        false, 
        new List<TDLine>
        {
            new TDLine("비델", "자, 참가자 님의 결과는...!"),
            new TDLine("비델", "성공입니다! 축하드립니다!"),
        }
    );

    public static List<TDDialog> DialogList = new List<TDDialog>();
}