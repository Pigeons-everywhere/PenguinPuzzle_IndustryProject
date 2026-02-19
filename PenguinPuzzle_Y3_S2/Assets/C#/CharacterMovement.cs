//old character movement + gravity Evan & Terry
//Maybe used to switch movement
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    //Character movement speed
    public float moveSpeed = 5f;
    public float turnSpeed = 25f;
    public float maxSpeed = 5f;

    public Transform cameraTransform;
    private Rigidbody rb;
    //private CharacterController controller;
    private PlayerInputActions inputActions;
    private InputAction moveAction;

    public bool startSlide = false;

    private Vector2 inputValue;


    //is this character on ice right now?
    [SerializeField] bool isOnIce = false;


     //hovering
    [SerializeField] bool isGrounded = true;
    private InputAction hoverAction;
    public float hoverSpeed = 5;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;
        hoverAction = inputActions.Player.Hover;

        inputActions.Enable();
    }


    void FixedUpdate()
    {
        inputValue = moveAction.ReadValue<Vector2>();
        
//decide if we're walking or sliding and call the appropriate function
        if (isOnIce) IceSlide();
        else NormalWalk();
        
//hovering
        if (!isGrounded){
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (hoverAction.ReadValue<float>() > 0) rb.linearDamping = hoverSpeed;
            else rb.linearDamping = 0;
        }
        else rb.constraints = RigidbodyConstraints.None;
    }

//Sliding on ice movement controls
    void IceSlide()
    {
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

//Regular movement controls
    void NormalWalk()
    {
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


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = true;
        //if character touches ice, make it slide
        if (other.gameObject.GetComponent<Renderer>().materials[0].name.Contains("Ice")) isOnIce = true;
        //if it touches anything else, make it walk
        else isOnIce = false;
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.GetComponent<Renderer>().materials[0].name.Contains("Ice")) isOnIce = true;
        else isOnIce = false;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = false;
        if (other.gameObject.GetComponent<Renderer>().materials[0].name.Contains("Ice")) isOnIce = false;
    }
}
