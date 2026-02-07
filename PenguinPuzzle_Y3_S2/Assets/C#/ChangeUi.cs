//Evan
//Only detecting and change the UI now
//will be update
using UnityEngine;
using UnityEngine.UI;

public class ChangeUi : MonoBehaviour
{
    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private Sprite questionIcon;
    [SerializeField]
    private Sprite buttonIcon;

    void Start()
    {
        ShowQuestionIcon();
    }

    private void OnTriggerEnter(Collider other)
    {
        ShowButtonIcon();
    }
    private void OnTriggerExit(Collider other)
    {
        ShowQuestionIcon();
    }

    private void ShowQuestionIcon() 
    {
        iconImage.sprite = questionIcon;
    }
    private void ShowButtonIcon()
    {
        iconImage.sprite = buttonIcon;
    }
}
