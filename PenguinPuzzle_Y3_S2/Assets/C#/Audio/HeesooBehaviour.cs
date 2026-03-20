using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeesooBehaviour : MonoBehaviour
{
    IEnumerator HeesooVidDone()
    {
        yield return new WaitForSeconds(100f);
        SceneManager.LoadScene("01_Menu_Scene");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(HeesooVidDone());
    }
}
