using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LA_Enemy_02 : MonoBehaviour
{
   public GameObject enemy02Bullet;
    int _life = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn_bullets", 3, 3);    
    }

    // Update is called once per frame
    void Update()
    {
        // Condicion de muerte.
        if (_life < 1)
        {
        Destroy(gameObject);
        }
        
    }

    public void Spawn_bullets()
    { 
        bool flipped = GetComponent<SpriteRenderer>().flipX;

        Vector3 posicion = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        GameObject bullet = Instantiate(enemy02Bullet, posicion , transform.rotation );
        bullet.GetComponent<LA_Enemy_02_Bullet>().Movement(1, flipped);

        posicion = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        bullet = Instantiate(enemy02Bullet, posicion , transform.rotation );
        bullet.GetComponent<LA_Enemy_02_Bullet>().Movement(2, flipped);
        
        posicion = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        bullet = Instantiate(enemy02Bullet, posicion , transform.rotation );
        bullet.GetComponent<LA_Enemy_02_Bullet>().Movement(3, flipped);
       
    }

}
