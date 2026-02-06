using UnityEngine;
using UnityEngine.InputSystem;

public class IceSlideMovementEvan : MonoBehaviour
{
  
    [SerializeField]
    //Slide speed
    public float moveSpeed = 5f;
    public float turnSpeed = 25f;

    //Max Speed
    public float maxSpeed = 5f;

    public Rigidbody rb;

    private PlayerInputActions inputActions;
    private InputAction moveAction;

    private bool startSlide = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;

        inputActions.Enable();
    }

    void FixedUpdate()
    {
        Vector2 inputValue = moveAction.ReadValue<Vector2>();
        
        if (!startSlide && inputValue.y > 0.1f)
        {
            startSlide = true;
        }

        float moveForward, rotation;
        float forwardInput = 0f;

        rotation = inputValue.x * turnSpeed * Time.fixedDeltaTime;

        if (startSlide)
        {
            forwardInput = 1f;
        }

        moveForward = forwardInput * moveSpeed;

        //Ignore Y-axis acceleration
        Vector3 v = rb.linearVelocity;
        Vector3 flatV = new Vector3(v.x, 0f, v.z);

        if (flatV.magnitude < maxSpeed)
        {
            rb.AddRelativeForce(Vector3.forward * moveForward);
        }

        Quaternion turn = Quaternion.Euler(0f, rotation, 0f);

        rb.MoveRotation(rb.rotation * turn);
        
    }
}


