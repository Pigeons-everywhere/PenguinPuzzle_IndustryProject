//ice slide and hover Evan & Terry

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceSlideMovement : MonoBehaviour
{
  
    [SerializeField]
    //Slide speed
    public float moveSpeed = 5f;
    public float turnSpeed = 25f;

    public Transform cameraTransform;

    //Max Speed
    public float maxSpeed = 5f;

    public Rigidbody rb;

    private PlayerInputActions inputActions;
    private InputAction moveAction;

    public bool startSlide = false;

    //hovering
    [SerializeField] bool isGrounded = true;
    private InputAction hoverAction;
    public float hoverSpeed = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;
        hoverAction = inputActions.Player.Hover;

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

        if (!isGrounded){
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (hoverAction.ReadValue<float>() > 0) rb.linearDamping = hoverSpeed;
            else rb.linearDamping = 0;
        }
        else{
            rb.constraints = RigidbodyConstraints.None;
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground") isGrounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = false;
    }

    void normalWalk()
    {
        Vector2 inputValue = moveAction.ReadValue<Vector2>();


        float hovering = hoverAction.ReadValue<float>();//is or is not hovering

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 moveDirection = cameraForward * inputValue.y + cameraRight * inputValue.x;

        if (moveDirection.sqrMagnitude > 1f)
        {
            moveDirection.Normalize();
        }

        Vector3 penguinVelocity = moveDirection * moveSpeed;

        penguinVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = penguinVelocity;
    }
}


