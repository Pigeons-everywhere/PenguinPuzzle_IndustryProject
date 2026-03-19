using UnityEngine;

public class ToggleButtonBehaviourUI : MonoBehaviour
{
    public string auSrcName;
    [SerializeField] AudioSource thisAuSrc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisAuSrc = GameObject.Find(auSrcName).GetComponent<AudioSource>();
    }

    public void StopStartAudio()
    {
        if (thisAuSrc.isPlaying) thisAuSrc.Pause();
        else thisAuSrc.Play(0);
    }
}
