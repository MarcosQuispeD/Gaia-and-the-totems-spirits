using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public float speed = 20f;
    public GameObject player;

    private void Start()
    {
        var find = GameObject.FindObjectOfType<NewPlayerController>();

        rb2d.velocity = transform.right * speed;

        if (find.transform.localScale.x < 0)
        {
            //speed = -speed;
            Debug.Log("e¿ntrobala");
            rb2d.velocity = transform.right * -speed;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        Destroy(gameObject, 1.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
