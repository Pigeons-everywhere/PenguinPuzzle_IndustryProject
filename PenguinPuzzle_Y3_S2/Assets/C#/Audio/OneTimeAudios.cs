using UnityEngine;

public class OneTimeAudios : MonoBehaviour
{
    AudioSource thisAudio;
    public AudioClip thisClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisAudio = GameObject.Find("OneTimeAudios").GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Penguin")
        {
            thisAudio.clip = thisClip;
            thisAudio.Play(0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Penguin")
        {
            thisAudio.clip = thisClip;
            thisAudio.Play(0);
        }
    }

}
