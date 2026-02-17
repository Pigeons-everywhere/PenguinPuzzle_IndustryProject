using UnityEngine;

public class ButtonPressMoving : MonoBehaviour
{
    [SerializeField] private Animator platformAnimator;
    public GameObject platform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platformAnimator = platform.GetComponent<Animator>();
        platformAnimator.speed = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Penguin")
        {
            platformAnimator.speed = 1f;
            gameObject.transform.localScale = new Vector3(1f,0.75f,1f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Penguin")
        {
            gameObject.transform.localScale += new Vector3(0f,0.25f,0f);
        }
    }
}
