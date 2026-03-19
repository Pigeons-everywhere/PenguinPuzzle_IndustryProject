using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public IceSlideMovement iceSlideMovement;
    public CameraControl cameraControl;
    public CameraFollow cameraFollow;
    //public CameraControl cameraControl;
    private Animator anim;

    PenguinAudio audioMan;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        characterMovement.enabled = true;
        iceSlideMovement.enabled = false;

        audioMan = this.gameObject.GetComponent<PenguinAudio>();
    }

    public void SwitchToSlide()
    {
        audioMan.StartPenguAudio("slide");

        if (iceSlideMovement.enabled) return;
        //get the horizontal speed in normalwalk
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 horizontalVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);

        characterMovement.enabled = false;
        iceSlideMovement.enabled = true;
        cameraControl.enabled = false;
        cameraFollow.enabled = true;
        //keep the direction in normalwalk
        if (horizontalVelocity.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(horizontalVelocity.normalized);
            //iceSlideMovement.startSlide = true;
        }
        anim.SetBool("IsSliding", true);
    }
    
    public void SwitchToWalk()
    {
        audioMan.StartPenguAudio("walk");

        if (characterMovement.enabled) return;

        iceSlideMovement.enabled = false;
        characterMovement.enabled = true;
        cameraControl.enabled = true;
        cameraFollow.enabled = false;

        //iceSlideMovement.startSlide = false;

        rb.linearVelocity = Vector3.zero;
        anim.SetBool("IsSliding", false);
    }
}
