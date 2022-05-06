using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
     public string itemType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            if (itemType == "Health")
            {
                Debug.Log("Choque con el player, deberia darle SALUD");
                Destroy(gameObject);
            }

            if (itemType == "Speed")
            {
                Debug.Log("Choque con el player, deberia darle VELOCIDAD");
                Destroy(gameObject);
            }
            
        }
    }

    
}
