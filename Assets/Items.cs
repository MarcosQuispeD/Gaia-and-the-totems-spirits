using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Items : MonoBehaviour
{
    public AudioClip[] audiosIt;
    public AudioSource audioPlayerIt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        KeySound();
        NewScene.instance.check = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponentInChildren<Light2D>().enabled = false;
        //Destroy(gameObject);
    }
    public void KeySound()
    {
        audioPlayerIt.clip = audiosIt[0];
        audioPlayerIt.Play();
    }
}
