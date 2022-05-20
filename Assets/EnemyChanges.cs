using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChanges : MonoBehaviour
{
    public List<GameObject> entity;
    public List<GameObject> buttons;
    public Transform innit;
    public Transform innit2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void InnitEnemy_0()
    {
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[0], innit2.position, innit2.rotation);
    }
    public void InnitEnemy_1()
    {
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[1], innit2.position, innit2.rotation);
    }
    public void InnitEnemy_2()
    {
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[2], innit2.position, innit2.rotation);
    }
    public void InnitEnemy_3()
    {
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[3], innit.position, innit.rotation);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
