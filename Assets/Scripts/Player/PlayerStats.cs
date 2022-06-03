using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer _mySprite, _headSprite;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _mySprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
        
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TakeDamage();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
            {
            TakeDamage();
            }
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
        if (collision.gameObject.tag == "HealthReg")
        {
            currentHealth+=2;
            if (currentHealth > 10)
            {
                currentHealth = 10;
            }
            healthBar.SetHealth(currentHealth);
        }
        if (collision.gameObject.tag == "Traps")
        {
            TakeDamage();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            TakeDamage();
        }
    }


    void TakeDamage()
    {
        StartCoroutine(Feedback());
        currentHealth --;
        healthBar.SetHealth(currentHealth);
    }
    public IEnumerator Feedback()
    {
        _mySprite.color = Color.red;
        _headSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        _mySprite.color = Color.white;
        _headSprite.color = Color.white;
    }

}
