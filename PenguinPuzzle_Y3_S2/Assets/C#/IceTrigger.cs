using UnityEngine;

public class IceTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Penguin")
        {
            MovementManager manager = other.GetComponent<MovementManager>();
            manager.SwitchToSlide();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Penguin")
        {
            MovementManager manager = other.GetComponent<MovementManager>();
            manager.SwitchToWalk();
        }
    }
}

