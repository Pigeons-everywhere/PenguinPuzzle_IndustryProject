using UnityEngine;

public class AccessoryBehaviour : MonoBehaviour
{
    GameManager gM;
    GameObject thisUIOff;

    private void Start(){
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisUIOff = GameObject.Find($"Inventory/Bckg/ClothesAndCamPanel/InvBckg/Clothes/{gameObject.name}/{gameObject.name}Off");

        if (gM.clothes.Contains(gameObject.name)) {
            thisUIOff.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Penguin"){
            if (!gM.clothes.Contains(this.gameObject.name)){
                gM.clothes.Add(gameObject.name);
                gameObject.SetActive(false);
                thisUIOff.SetActive(false);
            }
        }
        
    }
}
