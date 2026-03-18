using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    GameObject manager;
    [SerializeField] GameManager gm;
    GameObject keyIcon;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = GameObject.Find("GameManager");
        gm = manager.GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Penguin")
        {
            if (gm.hasKey)
            {
                keyIcon = GameObject.Find("KeySprite");
                gm.hasKey = false;
                keyIcon.SetActive(false);
                //this.gameObject.SetActive(false);
                anim.SetBool("IsOpen", true);
            }
        }
    }
}
