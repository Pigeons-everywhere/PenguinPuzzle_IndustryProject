using UnityEngine;

public class DropBridgeBehaviour : MonoBehaviour
{
    Animator thisAnim;
    public int buttonsNeeded;
    public int buttonsPressed;

    void Start()
    {
        thisAnim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (buttonsNeeded == buttonsPressed){
            thisAnim.Play;
        }
    }
}
