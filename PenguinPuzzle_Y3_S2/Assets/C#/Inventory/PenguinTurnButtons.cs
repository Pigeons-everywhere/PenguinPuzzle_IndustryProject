using UnityEngine;

public class PenguinTurnButtons : MonoBehaviour
{
    public GameObject dressupPengu;
    [SerializeField] bool thisPrest = false;
    [SerializeField] private float turnSpeed = 80f;

    void Start()
    {
        dressupPengu = GameObject.Find("DressupRoom/PenguinWardrobe");
    }

    void Update(){
        if (thisPrest){
            if (gameObject.name == "LeftButton"){
                TurnHim(1f);
            }
            else{
                TurnHim(-1f);
            }
        }
    }

    public void TurnPengu(){
        thisPrest = !thisPrest;
    }

    void TurnHim(float direction){
        dressupPengu.transform.localRotation *= Quaternion.Euler(new Vector3(0f,0f,1f*Time.deltaTime*direction*turnSpeed));
    }
}