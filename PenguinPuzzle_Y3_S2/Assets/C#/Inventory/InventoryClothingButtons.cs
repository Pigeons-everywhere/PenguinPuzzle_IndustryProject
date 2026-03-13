using UnityEngine;
using TMPro;

public class InventoryClothingButtons : MonoBehaviour
{
    string whatCloth;//what piece of clothing is attached to this button
    GameManager gM;
    GameObject thisGame;
    GameObject thisDress;
    GameObject thisCostFish;
    public float fishNeeded;

    GameObject thisUIOff;

    [SerializeField]TMP_Text fishCount;

    void Start()
    {
        whatCloth = this.gameObject.name;
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisDress = GameObject.Find("DressupRoom/PenguinWardrobe").transform.Find(whatCloth).gameObject;
        thisGame = GameObject.Find("Penguin").transform.Find(whatCloth).gameObject;
        thisCostFish = GameObject.Find($"Inventory/Bckg/ClothesAndCamPanel/InvBckg/Clothes/{whatCloth}/Fish");
        thisUIOff = GameObject.Find($"Inventory/Bckg/ClothesAndCamPanel/InvBckg/Clothes/{gameObject.name}/{gameObject.name}Off");

        Debug.Log($"{thisCostFish} is the pic, {fishNeeded} is the price");

        if (thisCostFish != null && fishNeeded <= 0){
            
            thisCostFish.SetActive(false);
        }
        
        if(!gM.wearing.Contains(whatCloth)){
            thisDress.SetActive(false);
            thisGame.SetActive(false);
        }

        fishCount = GameObject.Find("Inventory/Bckg/Panel/FishCount").GetComponent<TMP_Text>();
    }

    public void De_EquipCloth()
    {
        if (gM.fish >= fishNeeded && fishNeeded > 0){
            gM.fish -= fishNeeded;
            fishNeeded = 0;
            thisCostFish.SetActive(false);
            gM.clothes.Add(whatCloth);
            if (thisUIOff != null) thisUIOff.SetActive(false);
            fishCount.text = $"{gM.fish}";
        }

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
