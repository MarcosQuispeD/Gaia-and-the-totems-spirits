using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LA_Enemy_01A : MonoBehaviour
{
    public GameObject enemy01B;
    int _life = 3;
 
    // Start is called before the first frame update
    void Start()
    {
        
    

    }

    // Update is called once per frame
    void Update()
    {
        // Condicion de muerte.
        if (_life < 1)
        {
        Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.tag == "Bullet")
        {
            //Cada vez que es atacado, suelta 2 enemigos.
            _life = _life -1;
            Spawn_childs();
        }


    }

    void Spawn_childs()
    { 
        //Cada vez que es atacado, suelta 2 enemigos.
        Vector3 _position = new Vector3 (transform.position.x -1, transform.position.y -1, transform.position.z);
        GameObject enemy_child = Instantiate(enemy01B, _position , transform.rotation );
        _position = new Vector3 (transform.position.x +1, transform.position.y -1, transform.position.z);
        enemy_child = Instantiate(enemy01B, _position , transform.rotation );
    }

}
