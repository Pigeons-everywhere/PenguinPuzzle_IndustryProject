using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("02_First_Game_Scene");
    }
}
