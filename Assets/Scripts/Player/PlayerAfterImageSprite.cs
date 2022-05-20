using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{

    [SerializeField]
    private float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    [SerializeField]
    private float alphaSet = 0.8f;
    private float alphaMultiplier = 0.95f;
    
    private Transform player;

    private SpriteRenderer SR;
    private SpriteRenderer playerSR;

    private Color color;

    private void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;

        FlipCharacterAfter();
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(0f, 255f, 255f, alpha);
        SR.color = color;

        if (Time.time >= (timeActivated + activeTime))
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
    }
    public void FlipCharacterAfter()
    {
        var play = GameObject.FindGameObjectWithTag("Player");
        var rigid = play.GetComponent<Rigidbody2D>();

        if (rigid.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (rigid.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }
}
