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

    //Max Speed
    public float maxSpeed = 5f;

    public Rigidbody rb;

    private PlayerInputActions inputActions;
    private InputAction moveAction;

    //public bool startSlide = false;

    //hovering
    [SerializeField] bool isGrounded = true;
    private InputAction hoverAction;
    public float hoverSpeed = 5;

    //audio
    PenguinAudio audioMan;

    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;
        hoverAction = inputActions.Player.Hover;

        inputActions.Enable();
        anim = GetComponent<Animator>();

        //audio manager
        audioMan = this.gameObject.GetComponent<PenguinAudio>();
    }

    void FixedUpdate()
    {
        Vector2 inputValue = moveAction.ReadValue<Vector2>();

        rb.angularVelocity = Vector3.zero;
        float slideRotation = inputValue.x * turnSpeed * Time.fixedDeltaTime;
        //transform.Rotate( 0f, slideRotation, 0f);
        Quaternion deltaTimeRotation = Quaternion.Euler(0f, slideRotation, 0f);
        rb.MoveRotation(rb.rotation * deltaTimeRotation);

        Vector3 slideDir = transform.forward * inputValue.y * moveSpeed;
        rb.AddForce(slideDir, ForceMode.Force);
        

        Vector3 slideV = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (slideV.magnitude > maxSpeed)
        {
            Vector3 KeepV = slideV.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(KeepV.x, rb.linearVelocity.y, KeepV.z);
        }
        /*if (!startSlide && inputValue.y > 0.1f)
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

        rb.MoveRotation(rb.rotation * turn);*/


        anim.SetFloat("VY", rb.linearVelocity.y);

        bool isHovering = !isGrounded && hoverAction.ReadValue<float>() > 0 && rb.linearVelocity.y <= 0;
        anim.SetBool("IsHover", isHovering);

        if (!isGrounded)
        {
            if (hoverAction.ReadValue<float>() > 0 && rb.linearVelocity.y <= 0)
            {
                rb.linearDamping = 0;
                rb.AddForce(Vector3.up * Mathf.Abs(Physics.gravity.y) * rb.mass * 0.8f);
                Vector3 hoverV = rb.linearVelocity;
                Vector3 hoverFlatV = new Vector3(hoverV.x, 0f, hoverV.z);
                rb.AddForce(-hoverFlatV * 0.05f, ForceMode.VelocityChange);
                audioMan.StartPenguAudio("hover");
            }
            else
            {
                audioMan.StopPenguAudio();
                rb.linearDamping = 0;
            }
            return;
        }

        if (inputValue.x != 0 || inputValue.y != 0)
        {
            audioMan.StartPenguAudio("slide");
        }
        else if (isGrounded) audioMan.StopPenguAudio();

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = true;
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground") isGrounded = false;
    }
}

