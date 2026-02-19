using UnityEngine;

public class SpikeBehaviour: MonoBehaviour
{
    public Vector3 starterPosition;
    GameObject gameManagerObj;
    GameManager gMan;
    public Vector3 starterRotation = new Vector3(0f,90f,0f);

    [SerializeField] CharacterMovement penguinMoves;

    
    [SerializeField] GameObject[] keys = null;
    [SerializeField] GameObject[] doors = null;
    public GameObject keyIcon;

    public GameObject[] platforms;
    [SerializeField] Animator platformAnims;

    private void Start(){
        keys = GameObject.FindGameObjectsWithTag("Key");
        doors =  GameObject.FindGameObjectsWithTag("Door");
        platforms = GameObject.FindGameObjectsWithTag("MovingObject");
        gameManagerObj = GameObject.Find("GameManager");
        starterPosition = gameManagerObj.GetComponent<GameManager>().respawnPoint;
    }

    private void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Penguin"){

            penguinMoves = col.gameObject.GetComponent<CharacterMovement>();

            //penguinMoves.startSlide = false;

            col.rigidbody.linearVelocity = new Vector3(0f,0f,0f);
            col.rigidbody.angularVelocity = new Vector3(0f,0f,0f);
            col.rigidbody.position = starterPosition;
            col.rigidbody.rotation = Quaternion.Euler(starterRotation.x,starterRotation.y,starterRotation.z);

            foreach(GameObject keyO in keys){
                keyO.SetActive(true);
            }
            foreach(GameObject doorO in doors){
                doorO.SetActive(true);
            }
            keyIcon.SetActive(false);

            foreach(GameObject movingObject in platforms)
            {
                platformAnims = movingObject.GetComponent<Animator>();
                platformAnims.Play("MovingPlatform",-1,0);
                platformAnims.speed = 0f;
            }
        }
    }
    
}
