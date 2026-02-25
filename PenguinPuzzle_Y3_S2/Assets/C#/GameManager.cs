//store stuff that you need to keep track of
//like current level finished, highest level finished, puzzle stuff

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool hasKey = false;
    public int lastLevelCompleted = 0;
    public string highestLevelReached = "MainMenu";

    public GameObject[] clothes;

    public Vector3 respawnPoint = new Vector3(4f,11f,0f);

private void Awake() 
{ 
    // If there is an instance, and it's not me, delete myself.
    
    if (Instance != null && Instance != this) 
    { 
        Destroy(this); 
    } 
    else 
    { 
        Instance = this; 
    } 
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
