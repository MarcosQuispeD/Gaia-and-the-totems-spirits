using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBossNew : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public ParticleSystem particle;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speedY * Time.deltaTime);
        transform.position = new Vector2(transform.position.x + speedX * Time.deltaTime, transform.position.y);
    }


    private void InstateParticle()
    {
        Instantiate(particle, gameObject.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            InstateParticle();
            Destroy(gameObject);
        }

    }

    public void SetSpeedX(float speed)
    {
        speedX = speed;
    }

    public void SetSpeedY(float speed)
    {
        speedY = speed;
    }




}
