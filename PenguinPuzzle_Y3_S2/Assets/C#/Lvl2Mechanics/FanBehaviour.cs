using UnityEngine;

public class FanBehaviour : MonoBehaviour
{
    GameObject whereToEnd;
    bool effectOn = false;
    GameObject pengu;
    UIGameSceneManager gM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        whereToEnd = GameObject.Find($"{this.gameObject.name}/EndPlace");
        gM = GameObject.Find("GameManager").GetComponent<UIGameSceneManager>();
    }

    void Update(){
        if (effectOn && !gM.endFan) {
            pengu.transform.position = Vector3.MoveTowards(pengu.transform.position,whereToEnd.transform.position,5f*Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Penguin"){
            gM.endFan = false;
            effectOn = true;
            pengu = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Penguin"){
            effectOn = false;
            pengu = null;
        }
    }
}
