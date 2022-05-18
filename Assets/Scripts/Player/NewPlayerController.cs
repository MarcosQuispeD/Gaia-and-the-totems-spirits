using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove;
    public bool canJump;
    public bool canDash = true;
    public bool isDashing;
    private float normalGravity;
    public float dashForce = 50;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed;

    [SerializeField] private float rayLenght;
    [SerializeField] private float rayPositionOffset;

    Vector3 rayPositionCenter;
    Vector3 rayPositionLeft;
    Vector3 rayPositionRight;

    RaycastHit2D[] groundHitsCenter;
    RaycastHit2D[] groundHitsLeft;
    RaycastHit2D[] groundHitsRight;

    RaycastHit2D[][] allRaycastHits = new RaycastHit2D[3][];

    IEnumerator dashCoroutine;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;
    private float lastShoot;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        normalGravity = rb.gravityScale;
    }

    private void Update()
    {
        Movement();
        Jump();


        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash == true)
        {
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.1f, 1);
            StartCoroutine(dashCoroutine);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            shoot();
            lastShoot = Time.time;

        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.AddForce(new Vector2(horizontalMove * dashForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
    }

    private void Movement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove > 0)
        {
            rb.velocity = new Vector2(movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }
        else if (horizontalMove < 0)
        {
            rb.velocity = new Vector2(-movementSpeed * Time.fixedDeltaTime, rb.velocity.y);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private void Jump()
    {
        rayPositionCenter = transform.position + new Vector3(0, rayLenght * .5f, 0);
        rayPositionLeft = transform.position + new Vector3(-rayPositionOffset, rayLenght * .5f, 0);
        rayPositionRight = transform.position + new Vector3(rayPositionOffset, rayLenght * .5f, 0);

        groundHitsCenter = Physics2D.RaycastAll(rayPositionCenter, -Vector2.up, rayLenght);
        groundHitsLeft = Physics2D.RaycastAll(rayPositionLeft, -Vector2.up, rayLenght);
        groundHitsRight = Physics2D.RaycastAll(rayPositionRight, -Vector2.up, rayLenght);

        allRaycastHits[0] = groundHitsCenter;
        allRaycastHits[1] = groundHitsLeft;
        allRaycastHits[2] = groundHitsRight;

        canJump = GroundCheck(allRaycastHits);

        Debug.DrawRay(rayPositionCenter, -Vector2.up * rayLenght, Color.red);
        Debug.DrawRay(rayPositionLeft, -Vector2.up * rayLenght, Color.red);
        Debug.DrawRay(rayPositionRight, -Vector2.up * rayLenght, Color.red);
    }

    private bool GroundCheck(RaycastHit2D[][] groundHits)
    {
        foreach (RaycastHit2D[] hitList in groundHits)
        {
            foreach (RaycastHit2D hit in hitList)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag != "PlayerCollider")
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        Vector2 originalVelocity = rb.velocity;
        isDashing = true;
        canDash = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb.gravityScale = normalGravity;
        rb.velocity = originalVelocity;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void shoot()
    {
        //Vector3 bDirection;

        //if (transform.localScale.x == 1.0f) bDirection = Vector3.right;

        //else

        //{
        //    bDirection = Vector3.left;
        //}

        //GameObject bullet = Instantiate(bulletPrefab, transform.position + bDirection * 0.4f, Quaternion.identity);
        //bullet.GetComponent<Bullet>().setDirection(bDirection);

        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);

    }
}
