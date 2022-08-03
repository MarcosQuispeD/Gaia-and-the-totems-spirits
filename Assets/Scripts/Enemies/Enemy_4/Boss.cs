using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    //Boss Movement
    private float RotateSpeed = 2.5f;
    private float Radius = 0.25f;

    private Vector2 _centre;
    private float _angle;

    //Boss Ray
    //public LineRenderer lineRenderer;
    //public Transform firePoint;

    private void Start()
    {
        _centre = transform.position;
        DisableLaser();
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;


    }

    void EnableLaser()
    {
        //lineRenderer.enabled = true;
    }
    
    void DisableLaser()
    {
        //lineRenderer.enabled = false;
    }
}
