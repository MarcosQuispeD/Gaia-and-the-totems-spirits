using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_two : EnemyController
{

    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] List<GameObject> wayPointsShoot = new List<GameObject>();
    [SerializeField] GameObject spawnShoot;
    [SerializeField] Transform innit;
    [SerializeField] float distance;
    public int nextPoint;
    bool standPosition = false;
    float timeMechanics = 0;
    public ParticleSystem particle;

    public static Enemy_two instace;


    // Start is called before the first frame update
    void Start()
    {
        instace = this;
        transform.position = wayPoints[nextPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        NextWayPoints();
        SetLifeEnemy(GetLifeEnemy()- Time.deltaTime);
        timeMechanics += Time.deltaTime;
        if (timeMechanics >= 3.5f)
        {
            MechanicRandom();
        }
    }

    void NextWayPoints()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextPoint].transform.position, speed * Time.deltaTime);
        FlipEnemy();
        if (Vector2.Distance(transform.position, wayPoints[nextPoint].transform.position) < distance && !standPosition)
        {
            StartCoroutine(NextPoint());
        }
       
    }

    public void MechanicRandom()
    {
        var random = Random.Range(0,2);
        switch (random)
        {
            case 0:
                StartCoroutine(ExplosionAttack());
                break;
            case 1:
                if (nextPoint == 0 || nextPoint == 3 || nextPoint == 4)
                {
                    for (int i = 0; i < wayPointsShoot.Count; i++)
                    {
                        Instantiate(spawnShoot, wayPointsShoot[i].transform.position, Quaternion.identity);
                    }
                }
                else
                    Instantiate(spawnShoot, innit.position, Quaternion.identity);
                break;
            default:
                Instantiate(spawnShoot, innit.position, Quaternion.identity);
                break;
        }
        timeMechanics = 0;
    }

    void FlipEnemy()
    {
        if (transform.position.x < wayPoints[nextPoint].transform.position.x) 
            GetComponent<SpriteRenderer>().flipX = false;
        else 
            GetComponent<SpriteRenderer>().flipX = true;
    }

    IEnumerator NextPoint()
    {
        standPosition = true;
        yield return new WaitForSeconds(1.2f);
        standPosition = false;
        if (life < life / 2)
        {
            nextPoint = Random.Range(0, wayPoints.Count);
        }
        else
        {
            nextPoint++;
        }
        if (nextPoint >= wayPoints.Count)
        {
            nextPoint = 0;
        }
    }

    IEnumerator ExplosionAttack()
    {
        particle.gameObject.SetActive(true);
        particle.Play();
        yield return new WaitForSeconds(1f);
        particle.Stop();
        particle.gameObject.SetActive(false);
    }

}