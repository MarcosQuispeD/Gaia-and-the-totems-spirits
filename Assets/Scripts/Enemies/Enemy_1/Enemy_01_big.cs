using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01_big : Enemy_01_small
{
    public GameObject enemy01B;

    public override void Start()
    {
        base.Start();
        _life = 3;
    }

    public override void OnCollisionEnter2D(Collision2D collision) 
    {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Bullet")
        {
            Spawn_childs(enemy01B);
        }
    }

}
