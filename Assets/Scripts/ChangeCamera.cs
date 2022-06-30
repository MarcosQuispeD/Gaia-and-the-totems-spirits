using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<NewPlayerController>().cameraList[0].SetActive(false);
            collision.gameObject.GetComponent<NewPlayerController>().cameraList[1].SetActive(true);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<NewPlayerController>().cameraList[0].SetActive(false);
            collision.gameObject.GetComponent<NewPlayerController>().cameraList[1].SetActive(true);
            Destroy(gameObject);
        }
    }
}
