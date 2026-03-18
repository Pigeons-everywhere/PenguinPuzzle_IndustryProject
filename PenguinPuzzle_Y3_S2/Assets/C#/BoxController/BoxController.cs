using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class BoxController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isPushing = false;
    private bool onIce = false;

    [SerializeField] private PhysicsMaterial iceMaterial;
    [SerializeField] private PhysicsMaterial normalMaterial;
    private Collider boxCollider;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<Collider>();
        rb.linearDamping = Mathf.Infinity;
        rb.angularDamping = Mathf.Infinity;
    }
    void FixedUpdate()
    {
        if (!isPushing && !onIce)
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
            rb.angularVelocity = Vector3.zero;
        }
        isPushing = false;  
    }
    public void Push(Vector3 direction, float speed)
    {
        Vector3 boxDir = transform.InverseTransformDirection(direction);
        float inputX = boxDir.x;
        float inputZ = boxDir.z;

        Vector3 boxMoveDir;
        if (Mathf.Abs(inputX) >= Mathf.Abs(inputZ))
            boxMoveDir = new Vector3(Mathf.Sign(inputX), 0, 0);
        else
            boxMoveDir = new Vector3(0, 0, Mathf.Sign(inputZ));

        Vector3 worldMoveDir = transform.TransformDirection(boxMoveDir);

        isPushing = true;
        rb.linearDamping = 0;
        rb.linearVelocity = new Vector3(worldMoveDir.x * speed, rb.linearVelocity.y, worldMoveDir.z * speed);
    }
    private void OnTriggerEnter(Collider isOnIce)
    {
        if (isOnIce.CompareTag("IceBox"))
        {
            onIce = true;
            boxCollider.material = iceMaterial;
        }
    }

    private void OnTriggerExit(Collider isOnIce)
    {
        if (isOnIce.CompareTag("IceBox"))
        {
            onIce = false;
            rb.linearVelocity = Vector3.zero;
            boxCollider.material = normalMaterial;
        }
    }
}
