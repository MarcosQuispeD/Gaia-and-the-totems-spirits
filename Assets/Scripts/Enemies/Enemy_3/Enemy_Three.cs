using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Three : EnemyController
{

    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] float distance;
    [SerializeField] GameObject spawnShoot;
    [SerializeField] Transform innit;
    int nextPoint;
    bool standPosition = false;
    bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = wayPoints[nextPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        NextWayPoints();
    }
    
    void NextWayPoints()
    {
        if (!standPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextPoint].transform.position, speed * Time.deltaTime);
            FlipEnemy();
            if (Vector2.Distance(transform.position, wayPoints[nextPoint].transform.position) < distance)
            {
                StartCoroutine(NextPoint());
            }
        }
        

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
        yield return new WaitForSeconds(1.5f);
        standPosition = false;
        nextPoint++;
        if (nextPoint >= wayPoints.Count)
        {
            nextPoint = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isShoot)
        {
            standPosition = true;
            if (transform.position.x < collision.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            StartCoroutine(ShootAttack());
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            standPosition = false;
            FlipEnemy();
        }
       
    }

    IEnumerator ShootAttack()
    {
        isShoot = true;
        Instantiate(spawnShoot, innit.position, Quaternion.identity);
        yield return new WaitForSeconds(2.5f);
        isShoot = false;
       
    }
}
