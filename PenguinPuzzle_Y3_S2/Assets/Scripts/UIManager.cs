using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void ChangeScene(String name)
    {
        SceneManager.LoadScene(name);
    }
}
