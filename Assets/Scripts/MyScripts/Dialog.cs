using System.Collections.Generic;

public class TDLine
{
    public string name;
    public string text;

    public TDLine(string _name, string _text)
    {
        name = _name;
        text = _text;
    }
}

public class TDDialog
{
    public int stage;
    public bool isProlog;
    public List<TDLine> lineList;

    public TDDialog(int _stage, bool _isProlog, List<TDLine> _lineList)
    {
        stage = _stage;
        isProlog = _isProlog;
        lineList = _lineList;
    }
}

public static class TDStory
{
    public static TDDialog gameOverLineList = new TDDialog(0, false, new List<TDLine>
    {
        new TDLine("비델", "자, 참가자 님이 밟으신 문은…!"),
        new TDLine("비델", "아쉽게도 지옥 문입니다! 안녕히 계세요!"),
    });

    public static TDDialog stageClearLineList = new TDDialog(0, false, new List<TDLine>
    {
        new TDLine("비델", "자, 참가자 님이 밟으신 문은…!"),
        new TDLine("비델", "천국 문입니다! 축하 드립니다!"),
    });

    public static List<TDDialog> dialogList = new List<TDDialog>();

    static TDStory()
    {
        dialogList.Add(new TDDialog(1, true, new List<TDLine>
        {
            new TDLine("???", "저기요."),
            new TDLine("???", "저기요? 제 말 들리세요?"),
            new TDLine("???", "이거 왜 눈을 안 뜨냐. 연장 가져와야…어머, 깨셨네."),
            new TDLine("???", "…"),
            new TDLine("???", "…자! 그러면 몇 년 만에 돌아온 저희 쇼의 317번째 시즌, 저 비델과 함께 지금 시작하겠습니다!"),
            new TDLine("비델", "참가자 분이 아직 잠이 덜 깨셨나 본데, 빠른 진행을 위해 앞쪽의 무대로 들어가시면 천천히 설명해 드리겠습니다!"),
            new TDLine("비델", "질문은 나중에 하고, 생방송이니까 빨리 들어가시라고."),
            new TDLine("비델", "본격적으로 시작을 해볼 텐데요, 저희 게임 정말 간단합니다. 저기 앞에 문들 보이시죠?"),
            new TDLine("비델", "저 중 딱 하나만 <color=#FF00FF>천국 문</color>이고, 나머지는 <color=#FF00FF>지옥 문</color>입니다. 당연히 천국 문으로 들어가야 되겠죠."),
            new TDLine("비델", "그런데 정말 아쉽게도, 겉으로만 봐서는 어느 것이 천국 문인지 알 수가 없어요. 구별할 힌트를 얻으려면 저에게 직접 오셔서 <color=#FF00FF>질문</color>을 해 주셔야 합니다."),
            new TDLine("비델", "일단 제 앞까지 한 번 와 보시겠어요?"),
            new TDLine("비델", "색깔 칸들을 밟으실 때마다 밑에 있는 상자에 그 칸의 내용이 채워졌죠?"),
            new TDLine("비델", "상자 3개를 모두 채우면, 그 내용들의 조합이 바로 참가자 분이 구성하신 질문입니다. <color=#FF0000>천국 문의 1칸 주변</color><color=#FF00FF>에, </color><color=#0000FF>특정 색깔</color><color=#FF00FF>이, </color><color=#00FF00>특정 개수</color><color=#FF00FF>만큼 있냐,</color> 이 뜻이죠."),
            new TDLine("비델", "지금은 <color=#FF0000>천국 문의 1칸 주변</color>에 <color=#0000FF>적색 칸</color>이 <color=#00FF00>딱 1개</color>가 있냐, 이런 질문을 하실 수 있는 겁니다. 참고로 ‘1칸 주변’이라는 건 상하좌우에다 대각선 범위까지 합친 총 8칸이고요."),
            new TDLine("비델", "이제 저에게 와보세요."),
            new TDLine("비델", "네, 천국 문의 1칸 주변에, 적색 칸이, 딱 1개가 있습니다. 보이시는 문 중에 그런 경우는 하나밖에 없죠? 거기로 들어가시면 됩니다."),
            new TDLine("나겔", "…"),
            new TDLine("비델", "…"),
            new TDLine("나겔", "진짜 미쳤죠."),
            new TDLine("비델", "으음, 왜 또 그러실까요?"),
            new TDLine("나겔", "겨우 잡아온 인간이 당신 거짓말 때문에 지옥 문을 문지방까지 밟고 있는데, 관리 미숙으로 위쪽에서 책잡히면 저까지 날라가는 거 아니에요."),
            new TDLine("비델", "다 우리 시청자 분들 위해서 이벤트로 한 거지, 제가 정말로 여기서 끝내겠나요. 그쪽이 신입이셔서 아직 방송 감이 없으신가 보다."),
            new TDLine("나겔", "…일단 참가자님? 저기 반대쪽 문으로 가세요."),
        }));

        dialogList.Add(new TDDialog(2, true, new List<TDLine> 
        {
            new TDLine("나겔", "아니, <color=#FF00FF>악마면 거짓으로 말한다는 것</color> 정도는 알려줘야지, 참가자가 지금 죽기 직전까지 갔잖아요."),
            new TDLine("나겔", "저희가 매주 하는 쇼도 아니고, PD님이 몇 년 만에 만든 거 당신이 망치면 뒷감당은 어떻게 하려고요. 예?"),
            new TDLine("비델", "신입이 말은 되게 많으시네요. 분량 욕심 있으시면 저기 카메라 보고 시청자 분들께 인사라도 하시지."),
            new TDLine("나겔", "됐으니까, 남은 건 제가 진행하겠습니다."),
            new TDLine("나겔", "하아, 설명 다시 해드릴 테니까 저기 저 무대로 가 보세요."),
            new TDLine("나겔", "기본적인 규칙은 방금 들으신 대로입니다. 칸 밟으셔서 질문 구성하시고, 그 상태로 저에게 오시면 대답해드려요. 듣고 추리하셔서 천국 문 가시면 됩니다."), //퍼즐 화면 입장 시 출력
            new TDLine("나겔", "저 같은 <color=#FF00FF>천사는 질문에 참으로 답하지만, 아까 그 악마는 거짓으로 답하니까</color> 주의하시고요."),
            new TDLine("나겔", "네? 그러면 그냥 악마한테 질문하고 반대로 해석하면 되는 거 아니냐고요?"),
            new TDLine("나겔", "이론 상으로는 맞는데… 그건 다음 무대로 가보시면 압니다. 일단 여기서는 몇 가지만 말씀드릴 게요."),
            new TDLine("나겔", "첫째, <color=#FF00FF>질문 상자에 등록되는 내용은 덮어 씌워집니다.</color> 내용을 하나씩만 등록할 수 있으니, 녹색 0 칸을 밟으신 후 녹색 1칸을 밟으시면 마지막에 밟은 1만 남습니다."),
            new TDLine("나겔", "둘째, <color=#FF00FF>질문 상자가 완성되지 않으면 저에게 오셔도, 아무 일도 발생하지 않습니다.</color> 제가 있는 칸을 지나갈 수는 있지만요."),
            new TDLine("나겔", "…네, 끝입니다. 이제 해보세요."),
        }));

        dialogList.Add(new TDDialog(2, false, new List<TDLine> 
        {
            new TDLine("나겔", "할 만하죠? 질문 상자의 내용이 덮어 씌워지는 걸 이용해서, 여러 질문들을 구성하면 풀 수 있는 무대였습니다."),
            new TDLine("나겔", "아, 잠시만요. 연락이 와서."),
            new TDLine("나겔", "…네. 아직 안 죽었으니까, 군소리하지 말고 다시 진행하러 오세요."),
        }));

        dialogList.Add(new TDDialog(3, true, new List<TDLine>
        {
            new TDLine("비델", "이야, 역시 이번 참가자 분은 뭐가 달라도 다르네요."),
            new TDLine("비델", "어쩐지 처음 봤을 때부터 관상이 잘할 것 같더니, 천사님이 보시기에도 그렇죠?"),
            new TDLine("나겔", "…"),
            new TDLine("비델", "왜요."),
            new TDLine("나겔", "네, 그러면 참가자님, 바로 다음 무대로 입장하시면 됩니다."),
            new TDLine("나겔", "…아, 참고로 저희는 이제 안 들어가요."),
            new TDLine("비델", "그 대신에, 겉으로는 천사인지 악마인지 알 수 없는 직원 분들이 투입됩니다!"),
            new TDLine("비델", "<color=#FF00FF>직원 분들의 정체를 모두 추리하셔야 문 칸으로 들어가실 수 있고요, 한 분이라도 추리를 잘못하셨다면 천국 문으로 들어가셔도 즉시 탈락입니다.</color>"),
            new TDLine("비델", "그런데 누가 천사고 누가 악마인지 어떻게 구별하냐고요?"),
            new TDLine("비델", "그건 당신이 생각해야죠."),
            new TDLine("", "정체를 표시하려는 칸을 마우스로 클릭할 시 해당 칸의 외형이 변화합니다."),
        }));

        dialogList.Add(new TDDialog(3, false, new List<TDLine>
        {
            new TDLine("비델", "녹색 칸, 백색 칸이 주변에 8개나 있는 문이 어디 있겠어요. 어느 곳이 천국 문이어도 말이 안 되는 질문에 맞다고 답변하면 그게 악마죠."),
            new TDLine("나겔", "하여간 갑자기 끌려와서 당황하셨을 텐데, 지금까지 수고하셨고요."),
            new TDLine("나겔", "그럼 이상, 오프닝 마치겠습니다."),
        }));

        dialogList.Add(new TDDialog(4, true, new List<TDLine>
        {
            new TDLine("나겔", "그래서, 이 분께 상황 설명을 하나도 안 했다고요?"),
            new TDLine("비델", "생방송인데 어떡해요. 이미 스케줄에서 5분이나 밀려 있었는데 게임부터 시켜야지."),
            new TDLine("비델", "애초에 설명할 것도 없잖아요? 그냥 천계에서 인간 하나 납치해 퍼즐 풀게 하는 게임 쇼를 하는데 이번에 당첨이 되셨습니다, 하면 되죠."),
            new TDLine("나겔", "혹시 예전 참가자들께도 그렇게 말하셨어요?"),
            new TDLine("비델", "네."),
            new TDLine("나겔", "…네, 어쨌든 여기가 게임 쇼인 것은 맞고요. 저와 이 분은 진행자라 생각해주시면 됩니다."),
            new TDLine("비델", "그리고 우리 참가자 분께서는, 들어가면 바로 숨이 끊어지는 지옥 문을 피해서 몇 십 개의 무대를 통과하셔야 되고요."),
            new TDLine("나겔", "물론 제작팀 분들께서, 잘 생각하시면 어느 칸이 천국 문인지는 아실 수 있도록 설계했습니다."),
            new TDLine("나겔", "더 직접적으로 말하면, <color=#FF00FF>저희가 참가자님을 대놓고 죽이려고 천국 문을 아예 놔두지 않거나, 주어진 무대를 활용해도 천국문의 위치를 알 수 없게 만들지는 않았습니다.</color>"),
            new TDLine("비델", "자, 그러면 슬슬 다음 무대 시작하겠습니다!"),
        }));

        dialogList.Add(new TDDialog(4, false, new List<TDLine>
        {
            new TDLine("나겔", "방금 저 분이 악마라 가정하면 어떤 문도 천국 문이 아니라는 결론이 나왔을 겁니다."),
            new TDLine("나겔", "말씀드렸듯, 저희는 모든 무대에 하나의 천국 문을 배치해 둔 상태이니 그런 경우는 정답이 아니라고 결론지을 수 있는 것이죠."),
            new TDLine("비델", "잠시만요, 네, 담당자님. 저희 지금 다음 무대로 가고 있거든요. 무대 들어갈 직원 분들 신호 좀 주세요."),
            new TDLine("나겔", "…방금 그거 스포일러 아니에요?"),
            new TDLine("비델", "뭐 어때요. 곧 있으면 직접 보실 건데."),
        }));

        dialogList.Add(new TDDialog(5, true, new List<TDLine>
        {
            new TDLine("비델", "자, 25분 간의 짧은 광고를 거쳐 트루스 오어 데블이 다시 돌아왔습니다!"),
            new TDLine("비델", "이제 모두가 아는 그 구간이죠. 질문을 받는 직원 분들이 무려 2분으로 늘어났습니다!"),
            new TDLine("비델", "과연 이번 무대의 조합은 천사와 천사일까요, 천사와 악마일까요, 악마와 천사일까요, 아니면 악마와 악마일까요!"),
            new TDLine("나겔", "뭐, 저희가 그 정도로 경우의 수를 일일이 따지는 문제는…아직은 안 냅니다."),
            new TDLine("나겔", "<color=#FF00FF>당장 눈에 보이는 걸 조금 돌려서 생각하시면 생각보다 쉬울 거고요.</color>"),
            new TDLine("나겔", "그래도 점점 복잡해질 테니까, 들어가시기 전에 수첩 하나 받아 가세요. 기록하면서 하는 게 더 편할 겁니다."),
        }));

        dialogList.Add(new TDDialog(5, false, new List<TDLine>
        {
            new TDLine("비델", "네, 아까 전의 무대를 응용한 것이죠."),
            new TDLine("비델", "방금 무대의 배치를 봤을 때, ‘천국 문 주변에 적색 칸이 0개다’는 말은 천국 문이 어디든 일단 거짓이다. 그런 질문에 거짓이라 말했으니 이 직원은 천사다."),
            new TDLine("나겔", "참고로 지금 알려 드리는 기법들은 앞으로 몇 십 번은 사용하실 거니까, 잘 익혀 두시는 게 좋습니다."),
            new TDLine("비델", "제 경험 상, 몇 십 번을 쓰기 전에 지옥으로 끌려가시던 데요."),
            new TDLine("나겔", "말이 그렇다는 거죠."),
        }));

        dialogList.Add(new TDDialog(6, true, new List<TDLine>
        {
            new TDLine("비델", "시간도 널널한데, 슬슬 우리 참가자 분께 질문이라도 하나 받아볼까요?"),
            new TDLine("비델", "신입 분? 잠깐 저 분 입에 붙은 테이프 떼 보시겠어요?"),
            new TDLine("나겔", "참가자님, 버둥거리지 마시고 가만히 좀 계세요."),
            new TDLine("H-317", "(해당 음성은 당국의 규제 조치에 의해 선제 검열되는 중입니다)"),
            new TDLine("비델", "아하, 참가자 님이 적색 칸은 왜 종류가 하나 뿐이냐고 물으시네요!"),
            new TDLine("비델", "조금만 기다리시면 새로운 타일들이 등장하니까 너무 걱정하지 않으셔도 됩니다. 이제 테이프 다시 붙여 주세요."),
            new TDLine("나겔", "…그리고 이번 무대도 하나만 도와드리자면, 지금까지는 주로 참 거짓이 명확한 질문을 활용하셨죠?"),
            new TDLine("나겔", "<color=#FF00FF>이번에는 참 거짓이 명확한 ‘질문들’을 생각해보세요.</color>"),
        }));

        dialogList.Add(new TDDialog(6, false, new List<TDLine>
        {
            new TDLine("비델", "네, 이래서 직원 분들께 할 수 있는 질문은 다 해 보시는 게 좋습니다."),
            new TDLine("비델", "천국 문은 딱 하나인데, 주변에 녹색 칸이 1개가 있으면서 동시에 2개가 있을 수는 없으니까요."),
            new TDLine("나겔", "그리고 방금 무대에서 눈치채셨을 수도 있지만…"),
            new TDLine("나겔", "<color=#FF00FF>질문 상자 3개를 올바르게 채워서 직원 분이 계신 칸으로 가면, 그 분들은 무조건 질문을 받을 수밖에 없습니다. 참가자님이 원하지 않더라도요.</color>"),
        }));

        dialogList.Add(new TDDialog(7, true, new List<TDLine>
        {
            new TDLine("비델", "이번 참가자님의 활약과 함께 어느덧 첫번째 막이 중간 단계로 접어들고 있는데요."),
            new TDLine("비델", "그에 걸맞게 이번에는 무려! 직원 분이 3명으로 늘어났습니다!"),
            new TDLine("비델", "과연 이번 무대의 조합은 천사와 천사와 천사일까요, 천사와 천사와 악마일까요, 천사와 악마와 천사일까요, 천사와 악마와 악마일까요, 아니면 악마와 천사와…"),
            new TDLine("나겔", "다시 말씀드리지만, 저희가 경우의 수 8개를 다 따져보라고는 안 합니다."),
            new TDLine("나겔", "다만 이번 무대는 어렵긴 할 겁니다. 일단 2회차 전의 참가자 분은 여기서 사망하셨거든요."),
            new TDLine("비델", "저도 힌트를 하나 드려보자면, <color=#FF00FF>이 직원이 천사이든 악마이든 상관없이 천국 문 후보에서 제외되는 문들이 있을 겁니다.</color>"),
            new TDLine("비델", "그 외에는 특이 사항 없어요. 지금까지 연습하신 것들 잘 활용해 보시고, 그러면 이제 무대 시작하겠습니다!"),
        }));

        dialogList.Add(new TDDialog(7, false, new List<TDLine>
        {
            new TDLine("나겔", "이 분 잘 하시는데요? 시청률 잘 나오겠는데."),
            new TDLine("비델", "그러게요. 생각보다 오래 사시겠네."),
            new TDLine("비델", "뭐, 잘 하셨으니까 잠깐 쉬는 동안 아까 물어보신 것 중 하나는 알려 드릴게요."),
            new TDLine("비델", "당신이 여기를 왜 왔냐 하면, 너무 무난하게 사셔서 그래요."),
            new TDLine("비델", "살면서 업을 쌓은 게 양수면 천국을 가고 음수면 지옥을 가는데, 몇 년에 한 번씩 정확하게 0이 나오는 경우가 있거든요."),
            new TDLine("비델", "우리도 그냥 공무원인데, 그런 특이 케이스 보면 신기하잖아요?"),
            new TDLine("비델", "그러니까 이 인간으로 TV 쇼나 만들어 보자, 한 번만 실수해도 지옥으로 끌려가는 퍼즐 게임을 시켜보자, 뭐 그런 거죠."),
            new TDLine("비델", "…왜 나를 봐요. 저기 쟤네들이 만든 건데."),
            new TDLine("나겔", "뭐요."),
        }));

        dialogList.Add(new TDDialog(8, true, new List<TDLine>
        {
            new TDLine("나겔", "이제 새로운 질문 방식과, 이를 구성할 새로운 타일들이 등장할 예정입니다."),
            new TDLine("나겔", "요약하자면, 직원 분들께 이 무대 전체에 천사나 악마가 총 몇 분인지를 물어볼 수 있는 거죠."),
            new TDLine("비델", "여기부터는 시청자 분들도 오랜만에 보시는 파트라서, 더 자세하게 설명 드릴게요!"),
            new TDLine("비델", "<color=#FF00FF>이제 적색 칸 중에는 MAP, 청색 칸 중에는 ANGEL과 DEVIL이라는 칸이 추가됩니다!</color> "),
            new TDLine("비델", "그러니까 적색 질문 상자에 MAP, 청색 질문 상자에 ANGEL이나 DEVIL, 녹색 질문 상자에는 이전처럼 숫자를 넣어서 저희 직원들에게 오시면?"),
            new TDLine("비델", "<color=#FF0000>이 무대 전체</color><color=#FF00FF>에,</color> <color=#0000FF>천사 혹은 악마</color><color=#FF00FF>가,</color> <color=#00FF00>총 몇 분</color><color=#FF00FF>이 있냐</color>, 이 질문에 대해 답을 해주시는 거죠."),
            new TDLine("나겔", "참고로 <color=#FF00FF>방금 말한 조합 외에 GATE ANGEL 1, MAP RED 0, 이런 건 질문으로 취급되지 않습니다.</color>"),
            new TDLine("나겔", "질문 상자를 그렇게 채워서 저희 직원께 오셔도, <color=#FF00FF>저희가 답변을 해 드리지도 않을 거고요.</color>"),
        }));

        dialogList.Add(new TDDialog(8, false, new List<TDLine>
        {
            new TDLine("비델", "네, 두 직원 분이 같은 질문에 다른 답변을 했으므로 한 분은 천사, 한 분은 악마였겠죠."),
            new TDLine("비델", "그 사실을 추론하면 둘 중 누가 맞는 말을 하는지도 유추할 수 있는 무대였습니다!"),
            new TDLine("나겔", "이제부터는 경우의 수 따질 일이 많아질 겁니다. 아까 드린 수첩 활용하셔야 할 거예요."),
            new TDLine("비델", "흠…그런데 신입 분? 슬슬 뭔가 허전하지 않으세요?"),
            new TDLine("나겔", "…예?"),
            new TDLine("비델", "중간 광고 보고 오시겠습니다!"),
        }));

        dialogList.Add(new TDDialog(9, true, new List<TDLine>
        {
            new TDLine("비델", "네, 광고와 함께 다시 돌아온 트루스 오어 데블입니다!"),
            new TDLine("비델", "이야, 저는 개인적으로 마지막에 나온 샴푸 광고가 제일 마음에 드네요. 누가 선물로 주면 딱 좋을 텐데. 그렇죠, 신입 분?"),
            new TDLine("나겔", "그런데 저희가 샴푸를 쓸 일이 있나요?"),
            new TDLine("비델", "우리 신입 분은 눈썹 바디 워시로 씻으세요?"),
            new TDLine("나겔", "네."),
            new TDLine("비델", "…음, 하여간 참가자님은 무대로 들어가 주세요!"),
        }));

        dialogList.Add(new TDDialog(9, false, new List<TDLine>
        {
            new TDLine("비델", "B 직원이 천사였다면 모순이 생기죠. 악마가 전체 2명이라는 것 자체가 자기도 악마라는 뜻이니까요."),
            new TDLine("나겔", "방금 무대처럼, <color=#FF0000>MAP</color>을 사용한 질문은 잘만 사용하면 직원 분들 상당수의 정체를 추리할 수 있습니다."),
            new TDLine("나겔", "그러니 특별한 경우가 아니라면, 일단 MAP을 사용한 질문부터 최대한 해 보시는 게 편할 거예요."),
            new TDLine("비델", "…"),
            new TDLine("나겔", "왜요."),
            new TDLine("비델", "아까부터 느낀 건데, 혹시 저희 대본 작가님 바뀌셨어요?"),
            new TDLine("나겔", "…아뇨?"),
        }));

        dialogList.Add(new TDDialog(10, true, new List<TDLine>
        {
            new TDLine("비델", "게임은 재밌게 즐기고 계신가요?"),
            new TDLine("나겔", "지금 이 분 눈에 초점이 없는데요."),
            new TDLine("비델", "아까 일어나셨을 때부터 이러시던데. 그냥 참가자님 인상이 원래 이런 거 아닐까요?"),
            new TDLine("나겔", "그래도 피곤하시긴 하겠죠. 벌써 퍼즐을 몇 개를 푸셨는데."),
            new TDLine("비델", "이제 더 피곤한 퍼즐 하러 가셔야 되니까, 기운 차리세요."),
            new TDLine("비델", "이제 슬슬, 천사와 천사와 천사인지 천사와 천사와 악마인지 악마와 악마와 천사인지 따지셔야 될 수도 있으니까요."),
        }));

        dialogList.Add(new TDDialog(10, false, new List<TDLine>
        {
            new TDLine("비델", "네, 직원들의 정체에 관한 경우의 수가 총 3가지였죠?"),
            new TDLine("비델", "이전에 알려드린 기법을 응용해 C 직원이 천사라는 점만 추리하면, 나머지 둘은 자연스럽게 악마임을 알 수 있었습니다!"),
            new TDLine("나겔", "사실 <color=#FF0000>GATE</color> <color=#0000FF>GREEN</color> <color=#00FF00>1</color>이란 질문을 B 직원과 C 직원에게 동시에 해서, 둘이 답변이 달랐다는 점만 발견하면 더 쉽게 풀 수도 있고요.  "),
            new TDLine("비델", "뭐, 이미 끝난 무대인데 다시 해볼 것도 아니잖아요? 바로 다음 무대로 이동하겠습니다!"),
        }));

        dialogList.Add(new TDDialog(11, true, new List<TDLine>
        {
            new TDLine("나겔", "…비델님이 잠시 개인 사정이 생기셔서, 이번 무대는 저 혼자 빠르게 진행하겠습니다."),
            new TDLine("나겔", "하는 방식 자체는 똑같습니다. 일단 MAP 사용한 질문부터 해보시고, 수첩에 기록하시면서 경우의 수 생각해 보시고, 거기서 모순점을 발견하시면 돼요."),
            new TDLine("나겔", "다만, 이전 무대와 다소 다르게 흘러가더라도 당황하지는 마시고요."),
            new TDLine("나겔", "다시 말씀드리지만, 질문 형식이 2개가 된 지금은 <color=#FF00FF>질문 상자 3개를 다 채운 채로 직원 분들께 가도 답변해드리지 않는 경우가 있습니다.</color> 잘 활용해 보세요."),
        }));

        dialogList.Add(new TDDialog(11, false, new List<TDLine>
        {
            new TDLine("나겔", "빨리 오셨네요?"),
            new TDLine("비델", "아, 잠시 작가님을 뵙느라고 늦었습니다. 하여간 난이도가 점점 올라가는 데도 잘 풀고 계시네요!"),
            new TDLine("비델", "<color=#FF0000>MAP</color> <color=#0000FF>ANGEL</color> <color=#00FF00>0</color>이라는 질문을 C 직원분께 던지셨다면 경우의 수를 좁힐 수 있는 문제였죠."),
            new TDLine("나겔", "그래서 작가님과는 무슨 얘기를 하신 거예요?"),
            new TDLine("비델", "음…카메라 앞에서는 못하는 얘기?"),
        }));

        dialogList.Add(new TDDialog(12, true, new List<TDLine>
        {
            new TDLine("비델", "자, 드디어 모두가 고대한 1막의 최종 무대입니다! 과연 이번 317번째 참가자 님은 역대 최고난도의 퍼즐을 풀고 2막에 도전할 수 있을까요!"),
            new TDLine("비델", "참고로 마지막 무대인 만큼 직원 분들이 무려! 4명이나 투입됩니다!"),
            new TDLine("나겔", "…"),
            new TDLine("비델", "과연 이번 무대의 조합은 천사와 천사와 천사와 천사일까요, 천사와 천사와 천사와 악마일까요, 천사와 천사와…"),
            new TDLine("나겔", "네, 시작하시면 됩니다."),
        }));

        dialogList.Add(new TDDialog(12, false, new List<TDLine>
        {
            new TDLine("나겔", "진짜 푸셨네요."),
            new TDLine("비델", "그러게요."),
            new TDLine("비델", "음, 일단 1막의 모든 무대에서 생존하신 점 진심으로 축하드립니다!"),
            new TDLine("비델", "그런데 사실…저희도 2막을 진행해 본 적이 별로 없어서요."),
            new TDLine("비델", "아무래도 무대 팀이 예전 설계도로 공사 다시 하시려면 시간이 좀 걸리겠는데요."),
            new TDLine("나겔", "얼마나요?"),
            new TDLine("비델", "한…한 달?"),
            new TDLine("나겔", "네?"),
            new TDLine("비델", "그, 혹시 한 달만 기다려 주실 수 있을까요? 다음 달이면 2막까지 공사 끝납니다!"),
            new TDLine("나겔", "저희 대본에 3막까지 있지 않아요?"),
            new TDLine("비델", "그건 그때 가서 생각하고, 일단 저희는 2막이 완성되면 다시 찾아오겠습니다. 감사합니다!"),
        }));
    }
}
