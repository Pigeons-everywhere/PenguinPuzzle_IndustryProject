using UnityEngine;

public class InventoryOpenClose : MonoBehaviour
{
    public GameObject inventory;
    public GameObject dressupPengu;
    public GameObject normiePengu;

    void Start(){
            dressupPengu = GameObject.Find("DressupRoom/PenguinWardrobe");
            normiePengu = GameObject.Find("Penguin");
    }

    
    IEnumerator lateClose(){
        inventory
    }

    public void OpenCloseInventory()
    {
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
            normiePengu.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePosition;
            dressupPengu.transform.localRotation = Quaternion.Euler(new Vector3(-90f,0f,180f));
        }
        else {
            normiePengu.GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePosition;
            inventory.SetActive(true);
        }
    }
}
