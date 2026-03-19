using UnityEngine;

public class UI_Panel_Toggle : MonoBehaviour
{
    public GameObject PaneltoToggle;

    public void ActivateObjectButton()
    {
        PaneltoToggle.SetActive(true);
    }
}
