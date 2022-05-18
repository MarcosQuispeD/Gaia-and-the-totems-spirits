using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
            currentHealth++;
            healthBar.SetHealth(currentHealth);
        }

    }

        void TakeDamage()
    {
        currentHealth --;
        healthBar.SetHealth(currentHealth);
    }
}
