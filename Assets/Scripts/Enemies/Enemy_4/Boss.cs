using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    PlayerStats playerStats;
    private AudioSource _myAudioSource;

    //Boss Base
    private float RotateSpeed = 2.5f;
    private float Radius = 0.25f;
    public float bossMaxLife = 100;
    public float bossCurrentLife = 0;
    

    private Vector2 _centre;
    private float _angle;

    //Boss Ray
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public Transform gaia;
    public float shootCount = 3;
    public int rayDamage = 5;
    

    private void Start()
    {
        _centre = transform.position;
        DisableLaser();
        bossCurrentLife = bossMaxLife;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

        shootCount -= Time.deltaTime;
        if (shootCount <= 0)
        {
            StartCoroutine(ShootBoss());
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }
    
    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }

    private IEnumerator ShootBoss()
    {
        yield return new WaitForSeconds(1.5f);
        RotateSpeed = 0;
        yield return new WaitForSeconds(0.2f);
        EnableLaser();
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, gaia.position);
        yield return new WaitForSeconds(2f);
        DisableLaser();
        yield return new WaitForSeconds(0.2f);
        RotateSpeed = 2.5f;
        shootCount = 3;
    }

    void Damage()
    {
        playerStats.currentHealth -= rayDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //if (_myAudioSource != null)
            //{
            //    _myAudioSource.Play();
            //}
            //else
            //{
            //    _myAudioSource = gameObject.GetComponentInChildren<AudioSource>();
            //    _myAudioSource.Play();
            //}

            bossCurrentLife -= 10;
          
        }
        
    }
}
