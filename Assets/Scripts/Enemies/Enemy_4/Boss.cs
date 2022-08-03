using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BossState
{
    Idle,
    RaySimple,
    RayMultiple,
    Wave,
    Bomb,
    Dead,
}

public class Boss : MonoBehaviour
{

    public BossState state;
    public Vector3 forward;
    public GameObject startVFX;
    public GameObject endVFX;


    Animator myAnimator;
    PlayerStats playerStats;
    private AudioSource _myAudioSource;
    public float stateChanger;
    public float CurrentTimeChanger;


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
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    private void Start()
    {
        FillLists();
        DisableLaser();
        state = BossState.Idle;
        myAnimator = GetComponent<Animator>();
        _centre = transform.position;
        bossCurrentLife = bossMaxLife;
        StartCoroutine(BossStates());
        CurrentTimeChanger = stateChanger;

    }

    private void Update()
    {

        //Vector2 laserDirection = firePoint.position - gaia.position;
        //RaycastHit2D hit = Physics2D.Raycast(firePoint.position, gaia.transform.position);
        //forward = transform.TransformDirection(gaia.transform.position - firePoint.position);
        //Debug.DrawRay(firePoint.position, forward, Color.red);

        //if (hit)
        //{
        //    lineRenderer.SetPosition(1, hit.point);
        //}



        CurrentTimeChanger -= Time.deltaTime;
        shootCount -= Time.deltaTime;
        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;


        if (shootCount <= 0)
        {
            shootCount = 0;
            StartCoroutine(ShootBoss());
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Play();
        }
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;

        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].Stop();
        }
    }

    private IEnumerator ShootBoss()
    {

        //Vector2 laserDirection = firePoint.position - gaia.position;
        //RaycastHit2D hit = Physics2D.Raycast(firePoint.position, gaia.transform.position);
        //forward = transform.TransformDirection(gaia.transform.position - firePoint.position);
        //Debug.DrawRay(firePoint.position, forward, Color.red);



        yield return new WaitForSeconds(1.5f);
        RotateSpeed = 0;
        yield return new WaitForSeconds(0.2f);
        Laser();
        //lineRenderer.SetPosition(0, firePoint.position);
        //lineRenderer.SetPosition(1, gaia.position);
        //if (hit)
        //{
        //    lineRenderer.SetPosition(1, hit.point);
        //}

        EnableLaser();
        yield return new WaitForSeconds(2f);
        DisableLaser();
        yield return new WaitForSeconds(0.2f);
        RotateSpeed = 2.5f;
        shootCount = 3;
    }

    void Laser()
    {
        Vector2 laserDirection = gaia.position - firePoint.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, laserDirection.normalized, laserDirection.magnitude);
        forward = transform.TransformDirection(gaia.position - firePoint.position);
        Debug.DrawRay(firePoint.position, forward, Color.red);

        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startVFX.transform.position = (Vector2)firePoint.position;
        lineRenderer.SetPosition(1, (Vector2)gaia.position);
        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);
        }
        endVFX.transform.position = lineRenderer.GetPosition(1);
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
        if (collision.gameObject.tag == "Bullet")
        {
            bossCurrentLife -= 10;
        }
    }

    IEnumerator BossStates()
    {
        var randomAttack = Random.Range(1, 6); ;

        yield return new WaitForSeconds(stateChanger);

        switch (randomAttack)
        {
            case 1:
                state = BossState.Idle;
                _angle += RotateSpeed * Time.deltaTime;

                var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
                transform.position = _centre + offset;
                break;
            case 2:
                state = BossState.RaySimple;
                //if (shootCount <= 0)
                //{
                //    shootCount = 0;
                //    StartCoroutine(ShootBoss());
                //}
                break;
            case 3:
                state = BossState.RayMultiple;
                break;
            case 4:
                state = BossState.Wave;
                break;
            case 5:
                state = BossState.Bomb;
                break;
            default:
                break;

        }
        StateChanger();
    }

    public void StateChanger()
    {
        switch (state)
        {
            case BossState.Idle:
                StartCoroutine(BossStates());
                break;
            case BossState.RaySimple:
                StartCoroutine(BossStates());
                break;
            case BossState.RayMultiple:
                StartCoroutine(BossStates());
                break;
            case BossState.Wave:
                StartCoroutine(BossStates());
                break;
            case BossState.Bomb:
                StartCoroutine(BossStates());
                break;
            default:
                break;
        }
    }

    void FillLists()
    {
        for (int i = 0; i < startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);

        }

        for (int i = 0; i < endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);

        }
    }
}
