using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTarget : MonoBehaviour
{

    public Transform rayOrigin;
    LineRenderer laser;

    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
