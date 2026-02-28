using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryOpenClose : MonoBehaviour
{
    public GameObject inventory;
    public GameObject dressupPengu;
    public GameObject normiePengu;

    void Start(){
            dressupPengu = GameObject.Find("DressupRoom/PenguinWardrobe");
            normiePengu = GameObject.Find("Penguin");
            inventory.GetComponent<CanvasScaler>().referenceResolution = new Vector2(1, 1);
            StartCoroutine(lateClose());
    }

    
    IEnumerator lateClose(){
        yield return new WaitForSeconds(0.01f);
        inventory.SetActive(false);
        inventory.GetComponent<CanvasScaler>().referenceResolution = new Vector2(800, 600);
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
