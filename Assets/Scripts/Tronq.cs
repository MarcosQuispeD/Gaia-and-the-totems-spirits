using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronq : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            rigidbody.bodyType = RigidbodyType2D.Dynamic;
            rigidbody.constraints = ~RigidbodyConstraints2D.FreezePositionY;
            rigidbody.gravityScale = 8;
        }
    }
}
