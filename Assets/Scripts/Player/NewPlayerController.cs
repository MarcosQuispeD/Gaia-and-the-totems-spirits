using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public enum TypeTotems
{
    eagle,
    cheetah
}

public class NewPlayerController : MonoBehaviour
{
    public int maxligth = 2;
    public int currentligth;
    public LigthBar ligthBar;
    public float maxTimer;
    public float timer;
    public Light2D pointLight2D;

    public List<GameObject> cameraList = new List<GameObject>();
    public GameObject itemCheck;
    public Transform pointInnitParticle;

    private bool isTransforPower = true;
    private Rigidbody2D rb;
    private float movementInputDirection;
    private bool isFacingRight = true;
    public bool canJump;
    public bool canDash = true;
    public bool itemDash;
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

    public GameObject bulletSpecialPrefab;
    public GameObject bulletPrefab;
    public GameObject bulletFX;
    public Transform bulletOrigin;
    public Transform bulletFXOrigin;
    private float lastShoot;
    float lastShootSpecial;

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

    //JumpBuff
    public float jumpBufferTime = 0.2f;
    public float jumpBufferCounter;

    //Para animaciones
    private Animator _myAnim;

    //Double Jump
    public float extraJumps = 0f;
    public float extraJumpCount;
    public float extraJumpForce;

    //Sounds
    public AudioClip[] audiosPl;
    public AudioSource audioPlayerPl;

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
        if (isTransforPower)
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

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpBufferCounter = jumpBufferTime;
            }

            else
            {
                jumpBufferCounter -= Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShoot + 0.25f)
            {
                //var gaia = Instantiate(bulletFX, bulletFXOrigin.position, bulletFXOrigin.rotation);

                //gaia.transform.SetParent(transform);

                //shoot();
                //lastShoot = Time.time;

            }

            //Para animaciones
            //Attack:

            if (Input.GetKeyUp(KeyCode.Z) && ligthBar.slider.value >= 1f && Time.time > lastShootSpecial + 0.1f)
            {

                var gaia = Instantiate(bulletFX, bulletFXOrigin.position, bulletFXOrigin.rotation);

                gaia.transform.SetParent(transform);


                Instantiate(bulletSpecialPrefab, bulletOrigin.position, bulletOrigin.rotation);

                ligthBar.slider.value -= 0.49f;
                pointLight2D.intensity -= 0.15f;
                lastShoot = Time.time;
                ShootSound();
            }

            if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShoot + 0.1f)
            {

                _myAnim.SetBool("Attack", true);
                if (_myAnim.GetBool("Attack") == true)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            else
            {
                _myAnim.SetBool("Attack", false);
            }

            //Jump
            if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
            {
                _myAnim.SetBool("Jump", true);
                JumpOneSound();
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
            if (Input.GetKeyDown(KeyCode.LeftControl) && canDash == true && itemDash)
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
    }

    private void FixedUpdate()
    {
        LigthPlayer();

        if (isTransforPower)
        {
            ApplyMovement();
            if (isDashing)
            {
                rb.AddForce(new Vector2(movementInputDirection * dashForce * Time.deltaTime, 0), ForceMode2D.Impulse);
            }
        }
    }

    public void LigthPlayer()
    {
        if (pointLight2D.intensity >= 0.7)
        {
            if (maxTimer >= timer)
            {
                timer += Time.deltaTime * 0.1f;
            }
            else
            {
                if (pointLight2D.intensity <= 0.7f)
                {
                    pointLight2D.intensity = 0.7f;
                }
                else
                {
                    ligthBar.slider.value -= 0.49f;
                    pointLight2D.intensity -= 0.15f;
                }
                timer = 0;
            }
        }
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        //if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)
        //{
        //    jumpBufferCounter = 0f;
        //    Jump();
        //}

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            coyoteTimeCounter = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canDash == true && movementInputDirection != 0 && itemDash)
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
        DashSound();
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
        //rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);

        if (canJump || extraJumpCount < extraJumps)
        {
            Debug.Log("entro salto");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            extraJumpCount++;
            JumpTwoSound();

        }
        else if (canJump == false)
        {
            extraJumpReset();
        }

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

    }
    public void CheckJump()
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
        extraJumpReset();

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
    public void extraJumpReset()
    {
        if (canJump)
        {
            extraJumpCount = 0;
        }
    }


    public void shoot()
    {
        var gaia = Instantiate(bulletFX, bulletFXOrigin.position, bulletFXOrigin.rotation);

        gaia.transform.SetParent(transform);



        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);

        lastShoot = Time.time;
        ShootSound();
    }

    private void CreateDust()
    {
        dust.Play();
        if (movementInputDirection < 0)
        {//
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 11)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Totem"))
        {
            TotemSound();
            StartCoroutine(EffectTotems(collision.gameObject));
        }
    }

    IEnumerator EffectTotems(GameObject other)
    {
        _myAnim.SetBool("Walk", false);
        isTransforPower = false;
        rb.velocity = Vector2.zero;

        switch (other.GetComponent<Totems>().Type)
        {
            case TypeTotems.eagle:
                extraJumps = 1f;
                break;
            case TypeTotems.cheetah:
                itemDash = true;
                break;
        }
        other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Instantiate(itemCheck, pointInnitParticle.position, Quaternion.Euler(new Vector3(-90, 135, 135)));
        Totems.instance.ActivatePanel();
        yield return new WaitForSeconds(3f);
        isTransforPower = true;
    }

    //SOUND

    public void JumpOneSound()
    {
        audioPlayerPl.clip = audiosPl[0];
        audioPlayerPl.Play();
    }
    public void JumpTwoSound()
    {
        audioPlayerPl.clip = audiosPl[1];
        audioPlayerPl.Play();
    }
    public void DashSound()
    {
        audioPlayerPl.clip = audiosPl[2];
        audioPlayerPl.Play();
    }
    public void ShootSound()
    {
        audioPlayerPl.clip = audiosPl[3];
        audioPlayerPl.Play();
    }

    public void TotemSound()
    {
        audioPlayerPl.clip = audiosPl[5];
        audioPlayerPl.Play();
    }

    public void LifeSound()
    {
        audioPlayerPl.clip = audiosPl[6];
        audioPlayerPl.Play();
    }
    public void StepsSound()
    {
        audioPlayerPl.clip = audiosPl[7];
        audioPlayerPl.Play();
    }


}
