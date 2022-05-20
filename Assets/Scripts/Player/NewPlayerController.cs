using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementInputDirection;
    private bool isFacingRight = true;
    public bool canJump;
    public bool canDash = true;
    private float normalGravity;
    public float dashForce = 50;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;

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
    public GameObject bulletFX;
    public Transform bulletOrigin;
    public Transform bulletFXOrigin;
    private float lastShoot;

    public ParticleSystem dust;

    //new dash
    private bool isDashing;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCooldown;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100f;

    //CoyoteTime
    public float coyoteTime = 0.2f;
    public float coyoteTimeCounter;

    //Para animaciones
    private Animator _myAnim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //Para animaciones
        _myAnim = GetComponent<Animator>();
        //Para animaciones
    }

    private void Start()
    {
        normalGravity = rb.gravityScale;
    }

    private void Update()
    {
        CheckInput();
        CheckMovementDIrection();
        CheckJump();
        CheckDash();

        if (GroundCheck(allRaycastHits))
        {
            coyoteTimeCounter = coyoteTime;
        }

        else
        {
            coyoteTimeCounter -= Time.deltaTime;
            if (coyoteTimeCounter <= 0)
            {
                coyoteTimeCounter = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            var gaia = Instantiate(bulletFX, bulletFXOrigin.position, bulletFXOrigin.rotation);

            gaia.transform.SetParent(transform);

            shoot();
            lastShoot = Time.time;

        }

        //Para animaciones
        //Attack:
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myAnim.SetBool("Attack", true);
        }
        else
        {
            _myAnim.SetBool("Attack", false);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            _myAnim.SetBool("Jump", true);
        }
        else
        {
            _myAnim.SetBool("Jump", false);
        }

        //Walk
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _myAnim.SetBool("Walk", true);

        }
        else
        {
            _myAnim.SetBool("Walk", false);
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash == true)
        {
            _myAnim.SetBool("Dash", true);
        }
        else
        {
            _myAnim.SetBool("Dash", false);
        }
        //Para verificar
        //Damage
        if (Input.GetKeyDown(KeyCode.L))
        {
            _myAnim.SetBool("Damage", true);
        }
        else
        {
            _myAnim.SetBool("Damage", false);
        }

        //Para verificar
        //Death
        if (Input.GetKeyDown(KeyCode.M))
        {
            _myAnim.SetBool("Death", true);
        }
        else
        {
            _myAnim.SetBool("Death", false);
        }
        //Para animaciones

    }

    private void FixedUpdate()
    {
        ApplyMovement();
        if (isDashing)
        {
            rb.AddForce(new Vector2(movementInputDirection * dashForce * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) && coyoteTimeCounter > 0)
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            coyoteTimeCounter = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash == true)
        {
            if (Time.time >= (lastDash + dashCooldown))
            {
                AttempToDash();
            }

        }
    }

    private void AttempToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }

    private void CheckDash()
    {
        if (isDashing)
        {

            if (dashTimeLeft > 0)
            {

                rb.velocity = new Vector2(dashSpeed * movementInputDirection, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }

            if (dashTimeLeft <= 0)
            {
                isDashing = false;

            }
        }
    }
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementInputDirection * movementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);

    }
    private void CheckMovementDIrection()
    {
        Flip();
    }

    private void Flip()
    {
        if (movementInputDirection > 0)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            CreateDust();

        }
        else if (movementInputDirection < 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            CreateDust();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }
    }
    private void CheckJump()
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

    public bool GroundCheck(RaycastHit2D[][] groundHits)
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



    private void shoot()
    {

        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);


    }

    private void CreateDust()
    {
        dust.Play();
        if (movementInputDirection < 0)
        {//
        }
    }
}
