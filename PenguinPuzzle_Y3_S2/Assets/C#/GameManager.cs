//store stuff that you need to keep track of
//like current level finished, highest level finished, puzzle stuff

using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool hasKey = false;
    public int lastLevelCompleted = 0;
    public string highestLevelReached = "MainMenu";

    public List<string> clothes;
    public List<string> trophies;
    public float fish = 0f;

    public List<string> wearing;

    public int doneOrNot = 0;

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
