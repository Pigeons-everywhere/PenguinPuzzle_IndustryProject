using UnityEngine;
using System.Collections;

public class BreakPlatformBehaviour : MonoBehaviour
{
    bool stepped = false;
    float howFar = 1f;
    float turnt = 0f;
    public GameObject platform;
    bool dir = false;


    IEnumerator StartBreaking(){
        yield return new WaitForSeconds(2f);
        stepped = false;
        platform.SetActive(false);
        yield return new WaitForSeconds(3f);
        platform.SetActive(true);
    }

    void Update(){
        if(stepped){
            if(turnt < howFar && !dir){
                platform.transform.Rotate(0f,1*Time.deltaTime*150,0f,Space.Self);
                turnt += 1*Time.deltaTime*20;
            }
            else{
                dir = true;
            }
            if(turnt > -howFar && dir){
                platform.transform.Rotate(0f,-1*Time.deltaTime*150,0f,Space.Self);
                turnt -= 1*Time.deltaTime*20;
            }
            else dir = false;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Penguin"){
            stepped = true;
            StartCoroutine(StartBreaking());
        }
    }

    

}
