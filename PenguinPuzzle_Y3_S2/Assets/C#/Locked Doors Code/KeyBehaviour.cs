using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    GameObject manager;
    [SerializeField] GameManager gm;
    public GameObject keyIcon;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("GameManager");
        gm = manager.GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Penguin")
        {
            gm.hasKey = true;
            keyIcon.SetActive(true);
            Destroy(gameObject);
        }
    }
}
