using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    [SerializeField]GameManager gM;
    [SerializeField]GameObject thisUI;

    private void Start(){
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisUI = GameObject.Find($"Inventory/Bckg/Panel/{gameObject.name}/{gameObject.name}On");

        if (!gM.trophies.Contains(gameObject.name)) thisUI.SetActive(false);
        else this.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Penguin"){
            if (!gM.trophies.Contains(gameObject.name)) {
                gM.trophies.Add(gameObject.name);
                thisUI.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }


}
