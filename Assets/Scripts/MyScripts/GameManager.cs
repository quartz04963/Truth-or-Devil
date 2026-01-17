using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxStage;
    public int currentStage;
    public int titleTabNumber;
    
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
