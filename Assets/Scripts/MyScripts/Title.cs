using UnityEngine;

public class Title : MonoBehaviour
{
    public GameObject title;
    public GameObject chapter1;
    public GameObject chapter2;
    public GameObject chapter3;

    void Start()
    {
        MoveTo(GameManager.instance.titleTabNumber);
        SoundManager.Instance.PlayBGM("title");
    }

    public void OnPlayClicked() {
        if (GameManager.instance.titleTabNumber == 0) GameManager.instance.titleTabNumber = 1;
        MoveTo(GameManager.instance.titleTabNumber);
    }

    public void OnExitClicked()
    {
        Application.Quit();   
    }

    public void OnBackClicked() => MoveTo(0);

    public void OnMoveToClicked(int num) => MoveTo(num);

    void MoveTo(int num)
    {
        if (num != 0) GameManager.instance.titleTabNumber = num;
        switch (num)
        {
            case 0: title.SetActive(true); chapter1.SetActive(false); chapter2.SetActive(false); chapter3.SetActive(false); break;
            case 1: title.SetActive(false); chapter1.SetActive(true); chapter2.SetActive(false); chapter3.SetActive(false); break;
            case 2: title.SetActive(false); chapter1.SetActive(false); chapter2.SetActive(true); chapter3.SetActive(false); break;
            case 3: title.SetActive(false); chapter1.SetActive(false); chapter2.SetActive(false); chapter3.SetActive(true); break;
        }
    }
}
