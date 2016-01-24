using UnityEngine;
using System.Collections;

public class PlayerAudio_script : MonoBehaviour {

    AudioSource audiosrc;
    public AudioClip shotClip;

    void Awake()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            audiosrc.PlayOneShot(shotClip, 1.0F);
        }
    }
}
