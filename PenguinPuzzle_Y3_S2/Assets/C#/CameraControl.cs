//Camera rotation Evan
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;

    [SerializeField]
    public float distance = 20f;
    public float pitch = 45f;
    public float rotateSpeed = 120f;

    float yAngle;

    private PlayerInputActions inputActions;
    private InputAction rotateAction;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        rotateAction = inputActions.Player.RotateCamera;

        
    }
    private void OnEnable()
    {
        inputActions.Enable();

        yAngle = transform.eulerAngles.y;
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    void LateUpdate()
    {
        float inputValue = rotateAction.ReadValue<float>();

        yAngle += inputValue * rotateSpeed * Time.deltaTime;

        Vector3 center = target.position + targetOffset;

        Quaternion rotation = Quaternion.Euler(pitch, yAngle, 0f);

        Vector3 direction = rotation * Vector3.forward;
        Vector3 cameraPosition = center - direction * distance;

        transform.position = cameraPosition;

        transform.LookAt(center);
    }
}
