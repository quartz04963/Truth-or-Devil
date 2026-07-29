using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void StartGame()
    {
        TransitionManager.instance.Transit("Stages");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
