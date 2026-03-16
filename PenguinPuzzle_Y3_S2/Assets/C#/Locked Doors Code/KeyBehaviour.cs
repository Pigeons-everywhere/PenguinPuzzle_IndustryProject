using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    GameObject manager;
    [SerializeField] UIGameSceneManager gm;
    public GameObject keyIcon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("GameManager");
        gm = manager.GetComponent<UIGameSceneManager>();
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Penguin")
        {
            gm.hasKey = true;
            keyIcon.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
