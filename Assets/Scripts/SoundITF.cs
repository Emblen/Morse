using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundITF : MonoBehaviour
{
    public AudioClip ITF;
    AudioSource adSource;
    void Start()
    {
        adSource = GetComponent<AudioSource>();
        adSource.PlayOneShot(ITF);
    }

}
