using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontal;
    float vertical;
    public float movSpeed;
    public float jumpForce;
    Rigidbody2D rb2d;
    IEnumerator dashCoroutine;
    bool isDashing;
    bool canDash = true;
    bool grounded;
    float direction = 1;
    float normalGravity;
    public int jumpCount;
    public int extraJumps = 1;
    float jumpCooldown;
    private float lastShoot;
    public GameObject bulletPrefab;

    public float live;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        normalGravity = rb2d.gravityScale;
    }

    private void Update()
    {
        if (horizontal != 0)
        {
            direction = horizontal;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        Debug.DrawRay(transform.position, Vector3.down * 0.55f, Color.red);
        /*if (Physics2D.Raycast(transform.position, Vector3.down, 0.55f))
        {
            grounded = true;
        }

        else grounded = false;*/

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
            Debug.Log("hoa");
        }

        CheckGrounded();

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
        rb2d.velocity = new Vector2(horizontal * movSpeed, rb2d.velocity.y);
        if (isDashing)
        {
            rb2d.AddForce(new Vector2(direction * 50, 0), ForceMode2D.Impulse);
        }
    }

    private void jump()
    {

        if (grounded || jumpCount < extraJumps)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            jumpCount++;
        }
        
    }

    private void shoot()
    {
        Vector3 bDirection;

        if (horizontal >= 0) bDirection = Vector3.right;

        else

        {
            bDirection = Vector3.left;
        }

        GameObject bullet = Instantiate(bulletPrefab, transform.position + bDirection * 0.4f, Quaternion.identity);
        bullet.GetComponent<Bullet>().setDirection(bDirection);
        
    }

    void CheckGrounded()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.75f))
        {
            grounded = true;
            jumpCount = 0;
            jumpCooldown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCooldown)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        Vector2 originalVelocity = rb2d.velocity;
        isDashing = true;
        canDash = false;
        rb2d.gravityScale = 0;
        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        rb2d.gravityScale = normalGravity;
        rb2d.velocity = originalVelocity;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Golpe");
    }
}
