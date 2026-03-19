using UnityEngine;
using System.Collections;

public class DropBridgeBehaviour : MonoBehaviour
{
    Animator thisAnim;
    public int buttonsNeeded;
    public int buttonsPressed;

    void Start()
    {
        thisAnim = this.gameObject.GetComponent<Animator>();
        thisAnim.speed = 0f;
    }

    void Update()
    {
        if (buttonsNeeded == buttonsPressed)
        {
            StartCoroutine(PlayAnne());
        }
    }

    IEnumerator PlayAnne()
    {
        thisAnim.speed = 1;
        yield return new WaitForSeconds(65f);
        thisAnim.speed = 0;
    }
}
