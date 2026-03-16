using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject PaneltoToggle;

    public void ActivateObjectButton()
    {
        PaneltoToggle.SetActive(false);
    }
}
