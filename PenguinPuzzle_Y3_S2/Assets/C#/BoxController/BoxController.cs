using UnityEngine;
using UnityEngine.Windows;

public class BoxController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isPushing = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
        rb.linearDamping = Mathf.Infinity;
        rb.angularDamping = Mathf.Infinity;
    }
    void FixedUpdate()
    {
        if (!isPushing)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        isPushing = false;  
    }
    public void Push(Vector3 direction, float speed)
    {
        float inputX = direction.x;
        float inputZ = direction.z;

        Vector3 moveDir;

        if (Mathf.Abs(inputX) >= Mathf.Abs(inputZ))
            moveDir = new Vector3(Mathf.Sign(inputX), 0, 0);
        else
            moveDir = new Vector3(0, 0, Mathf.Sign(inputZ));

        isPushing = true;
        rb.linearVelocity = moveDir * speed;
    }
}
