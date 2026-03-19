using UnityEngine;

public class MusicManScript : MonoBehaviour
{
    public static MusicManScript Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) Destroy(this.gameObject); 
        else Instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
