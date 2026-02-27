using UnityEngine;

public class InventoryClothingButtons : MonoBehaviour
{
    [SerializeField] string whatCloth;//what piece of clothing is attached to this button
    GameManager gM;
    [SerializeField] GameObject thisGame;
    [SerializeField] GameObject thisDress;
    public float fishNeeded;

    void Start()
    {
        whatCloth = this.gameObject.name;
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisDress = GameObject.Find("DressupRoom/PenguinWardrobe").transform.Find(whatCloth).gameObject;
        thisGame = GameObject.Find("Penguin").transform.Find(whatCloth).gameObject;
        
        if(!gM.wearing.Contains(whatCloth)){
            thisDress.SetActive(false);
            thisGame.SetActive(false);
        }
    }

    public void De_EquipCloth()
    {
        if (gM.clothes.Contains(whatCloth)){
            if (thisDress.activeSelf == false){
                gM.wearing.Add(whatCloth);
                thisDress.SetActive(true);
                thisGame.SetActive(true);
            }
            else{
                gM.wearing.Remove(whatCloth);
                thisDress.SetActive(false);
                thisGame.SetActive(false);
            }
        }
    }



}
