using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02_small : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);    
    }


    public void Movement(int bullet_number, bool flipped)
    {  
        int _speedX = 10;
        int _speedY = 10; 
        //Para mover izquierda o derecha.
        if (flipped)
        {
            _speedX = -_speedX;
        }
        GetComponent<Rigidbody2D>().AddForce(transform.right * _speedX, ForceMode2D.Impulse);

        //Para detectar rotacion.
        if(bullet_number == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * _speedY, ForceMode2D.Impulse);
        }
        else if (bullet_number == 2)
        {
             GetComponent<Rigidbody2D>().AddForce(transform.up * -_speedY, ForceMode2D.Impulse);

        }    
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Confinder"))
        {
            Destroy(gameObject);
        }
    }

}
