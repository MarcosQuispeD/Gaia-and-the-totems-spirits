using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UISounds : MonoBehaviour
{
    public AudioClip[] Audios;
    public AudioSource AudioPlayer;

    void Start()
    {
        AudioPlayer = this.GetComponent<AudioSource>(); 
    }
    void Update()
    {
        
    }
}
