using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public string itemType;
    public GameObject pickUpEffect;
    //Sounds
    public AudioClip[] audiosIt;
    public AudioSource audioPlayerIt;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (itemType == "Health")
            {
                GiveHealth();
               
            }

            if (itemType == "Speed")
            {
                GiveSpeed(); 
            } 
        }

        if (collision.gameObject.tag == "Rock")
        {
            WoodSound();
            //collision.gameObject.GetComponent<NewPlayerController>().cameraList[0].SetActive(false);
            //collision.gameObject.GetComponent<NewPlayerController>().cameraList[1].SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<DialogController>().enabled = false;
            Destroy(collision.gameObject);

        }
    }

    void GiveHealth()
    {
        
        Debug.Log("Choque con el player, deberia darle SALUD");
        Destroy(gameObject);

    }
    void GiveSpeed()
    {
        Debug.Log("Choque con el player, deberia darle VELOCIDAD");
        Destroy(gameObject);


    }

    public void WoodSound()
    {
        audioPlayerIt.clip = audiosIt[0];
        audioPlayerIt.Play();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("PLayer"))
    //    {
    //        PickUp();
    //    }
    //}

    //void PickUp()
    //{
    //    Debug.Log("lo agarro");
    //}

}
