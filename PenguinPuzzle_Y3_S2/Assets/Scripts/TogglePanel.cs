using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject PaneltoToggle;

    public void ActivateObjectButton()
    {
        PaneltoToggle.SetActive(true);
    }
}
