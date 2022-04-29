using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void VolumeChange(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
}
