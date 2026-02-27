using UnityEngine;
using TMPro;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField]GameManager gM;
    [SerializeField]TMP_Text fishCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
        fishCount = GameObject.Find("Inventory/Bckg/Panel/FishCount").GetComponent<TMP_Text>();

        fishCount.text = $"{gM.fish}";
    }

    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Penguin"){
            gM.fish += 1;
            fishCount.text = $"{gM.fish}";
            gameObject.SetActive(false);
        }
    }
}
