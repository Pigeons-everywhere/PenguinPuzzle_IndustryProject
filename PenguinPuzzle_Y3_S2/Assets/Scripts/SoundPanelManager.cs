using UnityEngine;
using UnityEngine.UI;

public class SoundPanelManager : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider, _ambientSlider;


    //TOGGLE - MUTE
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
    }
    public void ToggleAmb()
    {
        AudioManager.Instance.ToggleAmb();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
    }


    //VOLUME - SLIDERS
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void AmbVolume()
    {
        
        AudioManager.Instance.AmbVolume(_ambientSlider.value); 
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }


}
