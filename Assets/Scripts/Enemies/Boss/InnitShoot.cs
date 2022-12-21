using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnitShoot : MonoBehaviour
{
    public ExplosionBossNew spawnShoot;
    float cronometro = 0;
    public Transform innit;
    public float speedX;
    public float speedY;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Shoot();
    }


    public void Shoot()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
        {
            ExplosionBossNew bullet = GameObject.Instantiate(spawnShoot, this.transform.position, Quaternion.identity);
            bullet.SetSpeedX(speedX);
            bullet.SetSpeedY(speedY);
            speedX = -speedX;
            cronometro = 0;
        }

    }


}
