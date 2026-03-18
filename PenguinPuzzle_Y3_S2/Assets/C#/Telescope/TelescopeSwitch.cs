using UnityEngine;
using UnityEngine.InputSystem;

public class TelescopeSwitch : MonoBehaviour
{
    //audios
    AudioSource thisAudio;
    public AudioClip engageA;
    public AudioClip disengageA;


    public GameObject cameraObject;
    public GameObject telescopeCameraObject;
    public GameObject telescopeShadowUI;

    private bool canUseTelescope = false;
    private bool usingTelescope;

    private PlayerInputActions inputActions;//now is key E (interaction)
    private InputAction interactionAction;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        interactionAction = inputActions.Player.Interaction;
        thisAudio = this.gameObject.GetComponent<AudioSource>(); 
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

        //audio
        if (usingTelescope) thisAudio.clip = engageA;
        else thisAudio.clip = disengageA;
        thisAudio.Play(0);
        //end of audio        

        usingTelescope = !usingTelescope;

        cameraObject.SetActive(!usingTelescope);
        telescopeCameraObject.SetActive(usingTelescope);
        telescopeShadowUI.SetActive(usingTelescope);
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
