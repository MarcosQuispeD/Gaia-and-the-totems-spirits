using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTiled : MonoBehaviour
{
    public GameObject florLigth;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (florLigth != null)
            {
                florLigth.SetActive(true);
            }
            Destroy(text);
            Destroy(gameObject);
        }
    }

}
