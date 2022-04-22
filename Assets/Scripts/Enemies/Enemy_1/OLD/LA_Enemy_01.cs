using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LA_Enemy_01 : MonoBehaviour
{

    GameObject _player;
    int _speed = 3;

    // Start is called before the first frame update
    void Start()
    {
       //No lo agrego desde el proyecto, porque el prefab no me lo permite 
       _player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        // Para seguir al player.
        transform.position = Vector3.MoveTowards( transform.position, _player.transform.position, _speed * Time.deltaTime); 

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.tag == "Player")
        {
            // para controlar el daño al player.
            Debug.Log("Aca deberia sacarle vida al player");   
        }
    }

}
