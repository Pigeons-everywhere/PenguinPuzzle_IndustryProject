//store stuff that you need to keep track of
//like current level finished, highest level finished, puzzle stuff

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasKey = false;
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
