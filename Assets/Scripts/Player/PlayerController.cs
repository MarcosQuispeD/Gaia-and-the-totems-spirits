using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //float direction = 1;
    float normalGravity;
    public int jumpCount;
    public int extraJumps = 1;
    float jumpCooldown;
    private float lastShoot;
    public GameObject bulletPrefab;
    public Animator animator;
    public float live;
    public bool isInmune;
    public float dashForce = 50;

    //PRUEBA FEDE BARRA DE VIDA
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        normalGravity = rb2d.gravityScale;

        //PRUEBA FEDE BARRA DE VIDA
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (live <=0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }

       
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        else if (horizontal > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

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
        //FlipCharacter();

        //PRUEBA FEDE BARRA DE VIDA
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TakeDamage(1);
        }
    }

    /*public void FlipCharacter()
    {
        if (rb2d.velocity.x > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (rb2d.velocity.x < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }*/

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * movSpeed * Time.deltaTime, rb2d.velocity.y);
        if (isDashing)
        {
            rb2d.AddForce(new Vector2(horizontal * dashForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

        if (rb2d.velocity.x != 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
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
        //Vector3 bDirection;

        //if (transform.localScale.x == 1.0f) bDirection = Vector3.right;

        //else

        //{
        //    bDirection = Vector3.left;
        //}

        //GameObject bullet = Instantiate(bulletPrefab, transform.position + bDirection * 0.4f, Quaternion.identity);
        //bullet.GetComponent<Bullet>().setDirection(bDirection);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy") && !isInmune)
        {
            StartCoroutine(Inmune());
        }
    }

    IEnumerator Inmune()
    {
        isInmune = true;
        live -= 1;
        GetComponentInParent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
        yield return new WaitForSeconds(1.2f);
        GetComponentInParent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        isInmune = false;
    }

    //PRUEBA FEDE BARRA DE VIDA
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
