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

    public Transform cameraTransform;
    private Rigidbody rb;
    //private CharacterController controller;
    private PlayerInputActions inputActions;
    private InputAction moveAction;
    private InputAction hoverAction;
    private Animator anim;

    bool swimming = false;

    //hovering speed
    public float hoverSpeed = 0.5f;
    [SerializeField] bool isGrounded = true;

    public float pushForce = 5f;


    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;
        hoverAction = inputActions.Player.Hover;

        inputActions.Enable();
    }


    void FixedUpdate()
    {
        rb.angularVelocity = new Vector3(0f,0f,0f);

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

        float speed = moveDirection.magnitude;
        bool isHovering = !isGrounded && hoverAction.ReadValue<float>() > 0;

        anim.SetFloat("Speed", speed);
        anim.SetBool("IsHover", isHovering);

        if (!isGrounded)
        {
            //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            if (hoverAction.ReadValue<float>() > 0) rb.linearDamping = hoverSpeed;
            else rb.linearDamping = 0;
        }

        if(swimming){
            Debug.Log("currently swimming");
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

    private void OnCollisionStay(Collision push)
    {
        BoxController box = push.collider.GetComponent<BoxController>();
        if (box != null)
        {
            Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (moveDirection.sqrMagnitude > 0)
            {
                Vector3 pushDirection = box.transform.position - transform.position;
                pushDirection.y = 0;
                box.Push(pushDirection, moveSpeed);
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Water"){
            this.transform.position = new Vector3(this.transform.position.x,other.gameObject.transform.position.y,this.transform.position.z);
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            swimming = true;
        }
    }
}
