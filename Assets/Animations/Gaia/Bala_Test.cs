using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Test : MonoBehaviour
{
void Start()
    {
        Destroy(gameObject, 3);  
    }

//  public void Movement(bool looking, float speed)
//     {
//         GetComponent<SpriteRenderer>().flipX= looking;
//         GetComponent<Rigidbody2D>().AddForce(transform.right * speed, ForceMode2D.Impulse);
//     }

}
