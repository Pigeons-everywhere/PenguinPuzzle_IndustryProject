    using UnityEngine;

    public class IceTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider penguin)
        {
            if (penguin.gameObject.tag == "Penguin")
            {
                MovementManager manager = penguin.GetComponent<MovementManager>();
                manager.SwitchToSlide();
            }
        }

        private void OnTriggerExit(Collider penguin)
        {
            if (penguin.gameObject.tag == "Penguin")
            {
                MovementManager manager = penguin.GetComponent<MovementManager>();
                manager.SwitchToWalk();
            }
        }
    }

