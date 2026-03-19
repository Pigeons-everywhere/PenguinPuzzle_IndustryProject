using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class SceneChanging : MonoBehaviour
{
    [SerializeField] List<string> scenes = new List<string> {"01_Menu_Scene","Lvl1", "Lvl2","Lvl3","SampleScene","Map"};
    [SerializeField] GameObject gameManagerObj;
    GameManager gMan; //game manager script
    public GameObject censorBar;
    private int sceneToGoTo;

    [SerializeField]GameObject mMan;//elliots music object

    //starting/respawn positions of levels
    List<Vector3> respawns = new List<Vector3> {new Vector3(4f,11f,0f), new Vector3(0f,5f,0f)};

    private void Start() {
        gameManagerObj = GameObject.Find("GameManager");
        gMan = gameManagerObj.GetComponent<GameManager>();
        mMan = GameObject.Find("MusicMan");

        if (SceneManager.GetActiveScene().name == "Map")
        {
            if(scenes.IndexOf(gMan.highestLevelReached) +1 >= Int32.Parse(gameObject.name))
            {
                censorBar.SetActive(false);
                gameObject.GetComponent<Button>().enabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Penguin")
        {
            if (scenes.IndexOf(gMan.highestLevelReached) < scenes.IndexOf(SceneManager.GetActiveScene().name))
            {
                gMan.highestLevelReached = SceneManager.GetActiveScene().name;
                gMan.lastLevelCompleted = scenes.IndexOf(SceneManager.GetActiveScene().name);
            }
            SceneManager.LoadScene(scenes[^1]);
        }
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(mMan);
            SceneManager.LoadScene(scenes[^1]);
        }
        else
        {
            sceneToGoTo = Int32.Parse(gameObject.name);
            gMan.lastLevelCompleted = sceneToGoTo;
            if (sceneToGoTo!= 0) gMan.respawnPoint = respawns[sceneToGoTo-1];
            SceneManager.LoadScene(scenes[sceneToGoTo]);
        }
    }
    
    
}
