//old character movement + gravity
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    //Character movement speed
    public float moveSpeed = 5f;

    public Transform cameraTransform;

    private CharacterController controller;
    private PlayerInputActions inputActions;
    private InputAction moveAction;
    private InputAction hoverAction;

    //gravity variabe
    float gravity = 1f;
    float vSpeed = 0f; //vertical speed

    //hovering speed
    public float hovSpeed = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;
        hoverAction = inputActions.Player.Hover;

        inputActions.Enable();
    }


    void Update()
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

        Vector3 moveDelta = moveDirection * moveSpeed * Time.deltaTime;

        controller.Move(moveDelta);
        
        //gravity
        if (!controller.isGrounded) {
            vSpeed -= gravity * Time.deltaTime;
            if (hovering > 0)
            {
                vSpeed = -hovSpeed*Time.deltaTime;
            } 
        }
        else {
            vSpeed = 0;
        }
        

        Vector3 vVel = new Vector3(0f,1f * (vSpeed),0f); //vertical velocity

        controller.Move(vVel);

    }
}
