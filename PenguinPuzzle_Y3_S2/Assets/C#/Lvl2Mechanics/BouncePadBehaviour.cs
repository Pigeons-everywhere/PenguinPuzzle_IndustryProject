using UnityEngine;

public class BouncePadBehaviour : MonoBehaviour
{
    public float forceStrength = 10;
    void OnTriggerEnter(Collider other){
        other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*forceStrength, ForceMode.Impulse);
    }
}
