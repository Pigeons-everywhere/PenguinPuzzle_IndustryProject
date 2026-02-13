using UnityEngine;
using UnityEngine.InputSystem;

public class TelescopeSwitch : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject telescopeCameraObject;

    private bool canUseTelescope = false;
    private bool usingTelescope;

    private PlayerInputActions inputActions;//now is key E (interaction)
    private InputAction interactionAction;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        interactionAction = inputActions.Player.Interaction;
    }
    private void OnEnable()
    {
        inputActions.Enable();
        interactionAction.performed += OnInteraction;
    }
    private void OnDisable()
    {
        inputActions.Disable();
        interactionAction.performed -= OnInteraction;
    }
    private void Start()
    {
        usingTelescope = false;
        cameraObject.SetActive(true);
        telescopeCameraObject.SetActive(false);
    }

    private void OnInteraction(InputAction.CallbackContext context)
    {
        if (!canUseTelescope) return;
        usingTelescope = !usingTelescope;

        cameraObject.SetActive(!usingTelescope);
        telescopeCameraObject.SetActive(usingTelescope);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Penguin"))
        {
            canUseTelescope = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Penguin"))
        {
            canUseTelescope = false;
        }
    }
}
