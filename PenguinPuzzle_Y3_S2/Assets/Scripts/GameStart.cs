using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    public void OnPlayButton()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
