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

    void Start()
    {
        controller = GetComponent<CharacterController>();

        inputActions = new PlayerInputActions();

        moveAction = inputActions.Player.Move;

        inputActions.Enable();
    }


    void Update()
    {
        Vector2 inputValue = moveAction.ReadValue<Vector2>();

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
    }
}
