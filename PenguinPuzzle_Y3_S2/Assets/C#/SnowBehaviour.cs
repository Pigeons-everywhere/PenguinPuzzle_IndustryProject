using UnityEngine;

public class SnowBehaviour : MonoBehaviour
{
    CharacterMovement movementScr;
    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Penguin"){
            movementScr = other.gameObject.GetComponent<CharacterMovement>();
            movementScr.moveSpeed = 2.5f;
        }
    }
    void OnCollisionExit(Collision other){
        if (other.gameObject.tag == "Penguin"){
            movementScr = other.gameObject.GetComponent<CharacterMovement>();
            movementScr.moveSpeed = 5f;
        }
    }
    
}
