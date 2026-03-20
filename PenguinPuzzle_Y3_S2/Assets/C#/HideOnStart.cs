//used to hide objects that are not meant to be seen immediately after opening a level

using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        Invoke(nameof(Show), 3f);
    }

    void Show()
    {
        gameObject.SetActive(true);
    }
}