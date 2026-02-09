using UnityEngine;

public class SpikeBehaviour: MonoBehaviour
{
    public Vector3 starterPosition = new Vector3(-13f,1f,-6.5f);
    public Vector3 starterRotation = new Vector3(0f,90f,0f);

    [SerializeField] IceSlideMovement penguinMoves;

    private void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Penguin"){

            penguinMoves = col.gameObject.GetComponent<IceSlideMovement>();

            penguinMoves.startSlide = false;

            col.rigidbody.linearVelocity = new Vector3(0f,0f,0f);
            col.rigidbody.angularVelocity = new Vector3(0f,0f,0f);
            col.rigidbody.position = starterPosition;
            col.rigidbody.rotation = Quaternion.Euler(starterRotation.x,starterRotation.y,starterRotation.z);
        }
    }
    
}
