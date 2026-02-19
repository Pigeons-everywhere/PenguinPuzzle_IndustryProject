//store stuff that you need to keep track of
//like current level finished, highest level finished, puzzle stuff

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey = false;
    public int lastLevelCompleted = 0;
    public string highestLevelReached = "MainMenu";

    public Vector3 respawnPoint = new Vector3(4f,11f,0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
