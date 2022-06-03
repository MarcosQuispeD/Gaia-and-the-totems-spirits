using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeShoot{
    shoot_1,
    shoot_2
}


public class Enemy_Bullet_two : MonoBehaviour
{
    [SerializeField]
    TypeShoot shoot;
    float speed;
    Rigidbody2D rb;
    GameObject player;
    Vector2 direction;
    bool isShoot;

    public ParticleSystem particle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SelectTypeShoot();
        isShoot = false;
        Destroy(gameObject,2.5f);
    }

    void SelectTypeShoot()
    {
        if (shoot == TypeShoot.shoot_1)
        {
            switch (Enemy_two.instace.nextPoint)
            {
                case 0:
                case 3:
                case 4:
                    InstateParticle();
                    speed = 7f;
                    rb.velocity = new Vector2(0, transform.position.y > 0?(-transform.position.y * speed) : transform.position.y * speed);
                    break;
                default:
                    speed = 20f;
                    player = GameObject.FindGameObjectsWithTag("Player")[0];
                    if (player!= null)
                    {
                        direction = (player.transform.position - transform.position).normalized * speed;
                        rb.velocity = new Vector2(direction.x, direction.y);
                    }
                   
                    break;
            }
        }
        else
        {
            speed = 15f;
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            direction = (player.transform.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(direction.x, direction.y);
        }
       
    }

    private void Update()
    {
        if (!isShoot)
        {
            StartCoroutine(ShootAttack());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy_Four") && !collision.gameObject.CompareTag("Confinder"))
        {
            InstateParticle();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private void InstateParticle()
    {
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator ShootAttack()
    {
        isShoot = true;
        yield return new WaitForSeconds(1.5f);
        isShoot = false;
    }
}
