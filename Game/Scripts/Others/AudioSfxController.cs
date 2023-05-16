using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSfxController : MonoBehaviour
{
    public static AudioSfxController instance;
    private void Awake()
    {
        instance = this;
    }
    public AudioSource aud;

    public void Play(AudioClip x)
    {
        aud.PlayOneShot(x);
    }
    
}
