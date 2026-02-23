using TMPro;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public static Hint instance;
    [SerializeField] bool isHintOpened;

    [SerializeField] GameObject hint;
    [SerializeField] GameObject hintButton;
    [SerializeField] TextMeshProUGUI hintTMP;

    string[] hintTexts = new string[]
    {
        // 챕터 1
        "",
        "",
        "주위 8칸의 색깔이 모두 같은 문이 있나요?",
        "가능한 질문을 전부 찾았는지 확인해보세요.",
        "질문하러 들어가는 길목이 하나밖에 없다면 어떤 질문을 더 할 수 있을까요?",
        "참/거짓 여부가 같을 수 없는 두 질문을 찾아보세요.",
        "같은 질문을 다른 직원에게 해보세요.",
        "",
        "같은 질문을 다른 직원에게 해보세요.",
        "MAP을 이용한 질문을 해보세요.",
        "같은 질문이지만 다른 직원에게 할 수 있는 질문을 모두 찾아보세요.",
        "할 수 있는 색깔 질문을 모두 찾아보세요.",
        "다른 질문처럼 보여도 같은 질문일 수 있습니다.",
        // 챕터 2
        "",
        "가능한 천사 질문을 모두 찾아보세요.",
        "보기보다 경로는 한정되어 있습니다.",
        "여기까지 오셨으면 뭐... 충분히 풀 수 있으시죠?",
        "직진을 못한다면 후진을 사용해보세요.",
        "GREEN을 사용한 질문을 할 수 있는지 확인해보세요.",
        "같은 질문이지만 다른 직원에게 할 수 있는 질문을 모두 찾아보세요.",
    };

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        if (hintTexts[GameManager.instance.CurrentStage - 1] == "") hintButton.SetActive(false);
        else hintTMP.SetText(hintTexts[GameManager.instance.CurrentStage - 1]);
    }

    public void OnHintClicked(bool isOpening)
    {
        isHintOpened = isOpening;
        hint.SetActive(isHintOpened);
    }
}
