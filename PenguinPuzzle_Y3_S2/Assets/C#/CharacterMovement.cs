//character movement + hover Evan & Terry
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    PenguinAudio audioMan;


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
    [SerializeField] public float swimSpeed = 10f;
    [SerializeField] public float pushForce = 5f;


    void Start()
    {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;
        hoverAction = inputActions.Player.Hover;

        inputActions.Enable();

        //audio manager
        audioMan = this.gameObject.GetComponent<PenguinAudio>();
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
        if (swimming) 
        {
            rb.AddForce(moveDirection.x * swimSpeed, 0f, moveDirection.z * swimSpeed);
            rb.linearDamping = 5f;
            anim.SetBool("IsSwimming", true);
        }
        else
        {
        Vector3 penguinVelocity = moveDirection * moveSpeed;

        penguinVelocity.y = rb.linearVelocity.y;

        rb.linearVelocity = penguinVelocity;

        float speed = moveDirection.magnitude;
        bool isHovering = !isGrounded && hoverAction.ReadValue<float>() > 0;

        anim.SetFloat("Speed", speed);
        anim.SetBool("IsHover", isHovering);
        anim.SetBool("IsSwimming", false);
        }

        if (!isGrounded && !swimming)
        {
            if (hoverAction.ReadValue<float>() > 0) {
                rb.linearDamping = hoverSpeed;
                audioMan.StartPenguAudio("hover");

            }
            else
            {
                rb.linearDamping = 0;
                audioMan.StopPenguAudio();
            }

            return;
        }

        if (inputValue.x != 0 || inputValue.y != 0)
        {
            audioMan.StartPenguAudio("walk");
        }
        else if (isGrounded) audioMan.StopPenguAudio();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Floor") isGrounded = true;
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = false;
    }

    private void OnCollisionStay(Collision push)
    {
        if (push.gameObject.tag == "Ground") isGrounded = true;

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
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            swimming = false;
            rb.linearDamping = 0f;
        }
    }
}
