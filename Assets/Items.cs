using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Items : MonoBehaviour
{
    public AudioClip[] audiosIt;
    public AudioSource audioPlayerIt;
    public float timer;
    bool isTime;

    private void Update()
    {
        if (isTime)
        {
            timer += Time.deltaTime;
        }
        if (isTime && timer > 10f)
        {
            isTime = false;
            timer = 0;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponentInChildren<Light2D>().enabled = true;
        }
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<NewPlayerController>();
        if (player != null)
        {
            KeySound();
            isTime = true;
            timer = 0;

            player.ligthBar.slider.value += 1.5f;
            player.pointLight2D.intensity += 0.45f;
            if (player.pointLight2D.intensity > 1.7f)
            {
                player.ligthBar.slider.value = 3f;
                player.pointLight2D.intensity = 1.7f;
            }
           
           
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponentInChildren<Light2D>().enabled = false;
            //Destroy(gameObject);
        }

    }
    public void KeySound()
    {
        audioPlayerIt.clip = audiosIt[0];
        audioPlayerIt.Play();
    }
}
