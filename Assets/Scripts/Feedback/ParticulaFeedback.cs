using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulaFeedback : MonoBehaviour
{
    public float life_time;
    
    void Start()
    {
        Destroy(gameObject, life_time);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
