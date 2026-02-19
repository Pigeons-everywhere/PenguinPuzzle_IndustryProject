using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public CharacterMovement characterMovement;
    public IceSlideMovement iceSlideMovement;
    //public CameraControl cameraControl;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        characterMovement.enabled = true;
        iceSlideMovement.enabled = false;
    }

    public void SwitchToSlide()
    {
        if (iceSlideMovement.enabled) return;
        //get the horizontal speed in normalwalk
        Vector3 currentVelocity = rb.linearVelocity;
        Vector3 horizontalVelocity = new Vector3(currentVelocity.x, 0f, currentVelocity.z);

        characterMovement.enabled = false;
        iceSlideMovement.enabled = true;
        //keep the direction in normalwalk
        if (horizontalVelocity.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(horizontalVelocity.normalized);
            iceSlideMovement.startSlide = true;
        }
        else
        {
            iceSlideMovement.startSlide = false;
        }
        //iceSlideMovement.startSlide = true;
    }
    
    public void SwitchToWalk()
    {
        if (characterMovement.enabled) return;

        iceSlideMovement.enabled = false;
        characterMovement.enabled = true;

        iceSlideMovement.startSlide = false;

        rb.linearVelocity = Vector3.zero;

    }
}
