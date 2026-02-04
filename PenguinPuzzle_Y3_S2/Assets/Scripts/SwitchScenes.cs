//script to switch scenes on button press
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public string sceneToGoTo;
    //game manager reference
    public GameObject gameMngr;
    //a reference to the "current level" variable in gameManager
    string gMCurLev;

    public void ScnSwitch(string sceneToGoTo)
    {
        gMCurLev = gameMngr.GetComponent<GameManager>().currentLevel;
        if (gMCurLev != "") gMCurLev = sceneToGoTo;
        SceneManager.LoadScene(sceneToGoTo);
    }
}
