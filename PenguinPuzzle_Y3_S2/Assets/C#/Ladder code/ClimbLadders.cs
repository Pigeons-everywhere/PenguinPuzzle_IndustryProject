using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UI;

public class ClimbLadders : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private CharacterMovement normalMovement;//Default movement can be switch to other modes eg. sliding.

    [SerializeField] private float climbSpeed = 3f;

    //[SerializeField] private Image climbIconImage;

    private PlayerInputActions inputActions;
    private InputAction moveAction;

    public bool isClimbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalMovement = GetComponent<CharacterMovement>();
        inputActions = new PlayerInputActions();
        moveAction = inputActions.Player.Move;
        inputActions.Enable();
    }
    void FixedUpdate()
    {
        if (!isClimbing) return;

        Vector2 input = moveAction.ReadValue<Vector2>();
        float climbLadder = input.y;
        Vector3 velocity = new Vector3(0f, climbLadder * climbSpeed, 0f);
        rb.linearVelocity = velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ladder")) return;
        //Debug.Log("in");
        isClimbing = true;

        normalMovement.enabled = false;
        rb.useGravity = false;
        rb.linearVelocity = Vector3.zero;

        rb.constraints = RigidbodyConstraints.FreezeRotation |
                         RigidbodyConstraints.FreezePositionX |
                         RigidbodyConstraints.FreezePositionZ;
    }
    
    private void OnTriggerExit(Collider other) //Now for leave ladder at top
    {
        if (!other.CompareTag("Ladder")) return;
        ExitClimb();
        //Debug.Log("leave");
        /*
        isClimbing = false;
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
        normalMovement.enabled = true;
        */
    }

    public void ExitClimb() 
    {
        if (!isClimbing) return;

        isClimbing = false;
        rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints.None;
        normalMovement.enabled = true;
    }
}
