using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnitEnemies : MonoBehaviour
{

    public GameObject enemy;
    float cronometro = 0;
    public Transform innit;

    // Start is called before the first frame update
    void Start()
    {
        GameObject enemigo = GameObject.Instantiate(enemy, this.transform.position, Quaternion.identity);

    }

}
