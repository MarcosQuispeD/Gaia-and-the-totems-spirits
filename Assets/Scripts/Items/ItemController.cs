using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public string itemType;
    public GameObject pickUpEffect;

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
