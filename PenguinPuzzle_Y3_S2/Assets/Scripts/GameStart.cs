using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string SceneToLoad;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
