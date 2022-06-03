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
                LifeSound();
            }

            if (itemType == "Speed")
            {
                GiveSpeed(); 
            }

            if (itemType == "Collision" && collision.gameObject.GetComponent<NewPlayerController>().extraJumps == 1f)
            {
                collision.gameObject.GetComponent<NewPlayerController>().cameraList[0].SetActive(false);
                collision.gameObject.GetComponent<NewPlayerController>().cameraList[1].SetActive(true);
                Destroy(gameObject);
            }
            

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
    public void LifeSound()
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
