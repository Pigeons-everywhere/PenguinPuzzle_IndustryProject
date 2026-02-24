using UnityEngine;
//using UnityEngine.WSA;

public class Spri : MonoBehaviour
{
    public float sprintAngle = 60f;
    public float sprintSpeedUp = 5f;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

       
        float speed = 8f;

        Vector3 forward = other.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 sprintDirection = Quaternion.AngleAxis(-sprintAngle, other.transform.right) * forward;

        rb.linearVelocity = sprintDirection * speed * sprintSpeedUp;
        rb.linearDamping = 0f;

    }
}
