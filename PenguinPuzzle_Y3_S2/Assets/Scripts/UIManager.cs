using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ChangeScene(String name)
    {
        GameManager.Instance.SetSceneName(name);
    }

}
