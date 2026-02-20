//old character movement + gravity Evan & Terry
//Maybe used to switch movement
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/*public class CharacterMovement : MonoBehaviour
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

    private Vector3 lastMoveDirection = Vector3.forward;


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

        //float moveForward, rotation;
        //float forwardInput = 0f;

        float rotation = inputValue.x * turnSpeed * Time.fixedDeltaTime;

        if (startSlide)
        {
            //forwardInput = 1f;
            float yaw = rb.rotation.eulerAngles.y;
            lastMoveDirection = Quaternion.Euler(0f, yaw, 0f) * Vector3.forward;

            Vector3 trueForward = new Vector3(lastMoveDirection.x, 0f, lastMoveDirection.z).normalized;
            Vector3 v = rb.linearVelocity;
            Vector3 flatV = new Vector3(v.x, 0f, v.z);
            if (flatV.magnitude < maxSpeed)
            {
                rb.AddForce(trueForward * moveSpeed);
            }
        }

        //moveForward = forwardInput * moveSpeed;

        //Ignore Y-axis acceleration

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

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            moveDirection.Normalize();
            lastMoveDirection = moveDirection;
        }

        Vector3 penguinVelocity = moveDirection * moveSpeed;

        penguinVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = penguinVelocity;

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = true;
        //if character touches ice, make it slide
        if (other.gameObject.GetComponent<Renderer>().materials[0].name.Contains("Ice"))
        {
            isOnIce = true;
        }
        //if it touches anything else, make it walk
        else if (other.gameObject.tag == "Ground")
        {
            isOnIce = false;
            startSlide = false;
        }
    }

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.GetComponent<Renderer>().materials[0].name.Contains("Ice")) isOnIce = true;
        else isOnIce = false;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = false;
        if (other.gameObject.GetComponent<Renderer>().materials[0].name.Contains("Ice"))
        {
            isOnIce = false;
            startSlide = false;
        }
    }
}*/

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    //Character movement speed
    public float moveSpeed = 5f;

    public Transform cameraTransform;
    private Rigidbody rb;
    //private CharacterController controller;
    private PlayerInputActions inputActions;
    private InputAction moveAction;
    private InputAction hoverAction;


    //hovering speed
    public float hoverSpeed = 0.5f;
    [SerializeField] bool isGrounded = true;


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
        Vector2 inputValue = moveAction.ReadValue<Vector2>();

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        Vector3 moveDirection = cameraForward * inputValue.y + cameraRight * inputValue.x;

        if (moveDirection.sqrMagnitude > 0.1f)
        {
            moveDirection.Normalize();
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        Vector3 penguinVelocity = moveDirection * moveSpeed;

        penguinVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = penguinVelocity;

        if (!isGrounded)
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (hoverAction.ReadValue<float>() > 0) rb.linearDamping = hoverSpeed;
            else rb.linearDamping = 0;
        }
        //else{rb.constraints = RigidbodyConstraints.None;}
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = true;
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = false;
    }
}
