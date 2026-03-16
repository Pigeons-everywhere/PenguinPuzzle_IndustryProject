using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{

    public static UISceneManager Instance { get; private set; }
    [SerializeField] public string currentScene; //Tracks current Scene
    public string playerName; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
            Init();
    }

   private void Init()
    {
        if (SceneManager.sceneCount == 1)
        {
            SetSceneName("01 Menu");
        }
    }

    public void SetSceneName(string name)
    {
        // Unload previous scene if more than one is loaded
        if (SceneManager.sceneCount > 1 && !string.IsNullOrEmpty(currentScene))
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }

        // Load new scene additively
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        currentScene = name;
    }

    public void ChangeName(string name)
    {
        playerName = name;
    }
}
