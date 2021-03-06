using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LA_Enemy_02_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement(int bullet_number, bool flipped)
    {  
        int _speedX = 5;
        int _speedY = 5; 

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
}
