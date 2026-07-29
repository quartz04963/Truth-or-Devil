using System.Threading.Tasks;
using PrimeTween;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;

    [SerializeField] float fadeOutDuration;
    [SerializeField] float fadeInDuration;
    
    [SerializeField] Image cover;

    private bool isTransiting;

    // 임시
    [SerializeField] int currentChapter;
    [SerializeField] int currentStage;
    [SerializeField] int maxChapter;
    [SerializeField] int maxStage;

    public int CurrentChapter => currentChapter;
    public int CurrentStage => currentStage;

    public int MaxChapter => maxChapter;
    public int MaxStage => maxStage;

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void Transit(string sceneName)
    {
        if (isTransiting) return;

        isTransiting = true;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        Task wait = WaitForLoading(operation);
        Task fade = FadeOut();

        await Task.WhenAll(wait, fade);

        operation.allowSceneActivation = true;

        await FadeIn();

        isTransiting = false;
    }
        
    async Task FadeOut()
    {
        cover.gameObject.SetActive(true);

        await Tween.Alpha(cover, 1f, fadeOutDuration);
    }

    async Task FadeIn()
    {
        await Tween.Alpha(cover, 0f, fadeInDuration);

        cover.gameObject.SetActive(false);
    }

    async Task WaitForLoading(AsyncOperation operation)
    {
        while (operation.progress < 0.9f)
        {
            await Task.Yield();
        }
    }

    public void SetCurrentChapterAndStage(int chapter, int stage)
    {
        currentChapter = chapter;
        currentStage = stage;
    }

    public void UpdateMaxStage()
    {
        if (!(currentChapter == maxChapter && currentStage == maxStage)) return;

        if (maxStage < StageData.stages[maxChapter].Count)
        {
            maxStage++;
        }
        else if (maxChapter < StageData.stages.Length - 1)
        {
            maxChapter++;
            maxStage = 1;
        }
    }
}
