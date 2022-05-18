using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Vector2 backgroundVel;

    private Vector2 offset;

    private Material material;

    private Rigidbody2D playerRb;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        offset = (playerRb.velocity.x /100) * backgroundVel * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
