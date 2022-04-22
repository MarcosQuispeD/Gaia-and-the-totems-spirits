using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LA_Enemy_01B : MonoBehaviour
{
    int _life = 1;
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
            _life = _life -1;
        }

    }
    
}
