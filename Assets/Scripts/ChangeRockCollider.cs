using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRockCollider : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
