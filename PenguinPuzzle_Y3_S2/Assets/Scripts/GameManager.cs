//script that stores constants of a player's current playthrough
//(current level, acquired objects -
// - whatever else is needed between scenes)
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string currentLevel = "";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
