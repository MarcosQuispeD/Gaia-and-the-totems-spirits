using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyChanges : MonoBehaviour
{
    public List<GameObject> entity;
    public List<GameObject> block;
    public List<GameObject> buttons;
    public Transform innit;
    public Transform innit2;
    public Transform innit3;
    public GameObject text_1;
    public GameObject text_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ViewObjects_1()
    {
        text_1.SetActive(true);
        text_2.SetActive(false);
      
        Instantiate(block[0], innit.position, innit.rotation);
    }

    public void ViewObjects_2()
    {
        text_2.SetActive(true);
        text_1.SetActive(false);
       
        Instantiate(block[1], innit3.position, innit3.rotation);
    }

    public void InnitEnemy_0()
    {
        text_1.SetActive(false);
        text_2.SetActive(false);
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[0], innit2.position, innit2.rotation);
    }
    public void InnitEnemy_1()
    {
        text_1.SetActive(false);
        text_2.SetActive(false);
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[1], innit2.position, innit2.rotation);
    }
    public void InnitEnemy_2()
    {
        text_1.SetActive(false);
        text_2.SetActive(false);
        var enemy = FindObjectsOfType<Entity_enemy>();
        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }
        Instantiate(entity[2], innit2.position, innit2.rotation);
    }
    public void InnitEnemy_3()
    {
        text_1.SetActive(false);
        text_2.SetActive(false);
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
