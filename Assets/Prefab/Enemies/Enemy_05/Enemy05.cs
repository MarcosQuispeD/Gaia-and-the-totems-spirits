using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy05 : Entity_enemy
{
    public float cronometro;
    public float tiempoFinal;
    public float speedY;

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

        }
    }

    public override void Update()
    {
        if (_life < 0)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector2(transform.position.x, transform.position.y + speedY * Time.deltaTime);

        cronometro += 1 * Time.deltaTime;
        if (cronometro >= tiempoFinal)
        {
            speedY = -speedY;
            cronometro = 0;

        }


    }


}
