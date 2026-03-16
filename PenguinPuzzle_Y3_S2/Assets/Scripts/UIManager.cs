using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ChangeScene(String name)
    {
        UISceneManager.Instance.SetSceneName(name);
    }

}
