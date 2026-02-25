using UnityEngine;

public class InventoryOpenClose : MonoBehaviour
{
    public GameObject inventory;

    public void OpenInventory()
    {
        inventory.SetActive(true);
    }
    public void CloseInventory()
    {
        inventory.SetActive(false);
    }
}
