//used to hide objects that are not meant to be seen immediately after opening a level

using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }
}
