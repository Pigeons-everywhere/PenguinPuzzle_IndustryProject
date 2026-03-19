using UnityEngine;
using UnityEngine.UI;

public class AudioSliderBehaviour : MonoBehaviour
{
    public string whatAuSrc;
    AudioSource thisAuSrc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisAuSrc = GameObject.Find(whatAuSrc).GetComponent<AudioSource>();
    }

    public void SetVol()
    {
        thisAuSrc.volume = this.gameObject.GetComponent<Slider>().value;
    }
}
