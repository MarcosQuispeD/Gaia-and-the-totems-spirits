using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02_big : Entity_enemy
{
    public GameObject enemy02Bullet;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _life = 3;
        InvokeRepeating("Spawn_bullets", 3, 3);

    }

    public void Spawn_bullets()
    { 
        bool flipped = GetComponent<SpriteRenderer>().flipX;

        Vector3 posicion = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        GameObject bullet = Instantiate(enemy02Bullet, posicion , transform.rotation );
        bullet.GetComponent<Enemy_02_small>().Movement(1, flipped);

        posicion = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        bullet = Instantiate(enemy02Bullet, posicion , transform.rotation );
        bullet.GetComponent<Enemy_02_small>().Movement(2, flipped);
        
        posicion = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        bullet = Instantiate(enemy02Bullet, posicion , transform.rotation );
        bullet.GetComponent<Enemy_02_small>().Movement(3, flipped);
       
    }

    public virtual void OnTriggerEnter2D(Collider2D other) 
    {

    }
   
}
