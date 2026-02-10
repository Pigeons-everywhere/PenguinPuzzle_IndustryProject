//Detect player moving down and exiting the ladder. Evan
using UnityEngine;

public class LeaveLadders : MonoBehaviour
{
    [SerializeField] private bool isBottomExit = true; //Set to true if there is a LadderBottom detect collider.
    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Penguin")) return;
        ClimbLadders climbScript = other.GetComponent<ClimbLadders>();

        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (climbScript.isClimbing && isBottomExit && rb.linearVelocity.y < -0.1f)
        {
            climbScript.ExitClimb();
        }
    }
}
