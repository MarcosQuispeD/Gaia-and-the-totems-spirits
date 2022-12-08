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
    public AudioClip[] audiosIt;
    public AudioSource audioPlayerIt;
    void Start()
    {

        //Mejorar
        if (ManagerScene.instance == null)
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            gameObject.GetComponent<NewPlayerController>().timer = 0;
            gameObject.GetComponent<NewPlayerController>().currentligth = gameObject.GetComponent<NewPlayerController>().maxligth;
            gameObject.GetComponent<NewPlayerController>().ligthBar.SetMaxHealth(gameObject.GetComponent<NewPlayerController>().maxligth);
        }
        else
        {
            if (!ManagerScene.instance.isInnitGame)
            {
                currentHealth = PlayerPrefs.GetInt("Life", 0);
                healthBar.SetHealth(currentHealth);

                gameObject.GetComponent<NewPlayerController>().currentligth = gameObject.GetComponent<NewPlayerController>().maxligth;
                gameObject.GetComponent<NewPlayerController>().pointLight2D.intensity = PlayerPrefs.GetFloat("Ligth", 0);
                gameObject.GetComponent<NewPlayerController>().ligthBar.slider.value = PlayerPrefs.GetFloat("SideLigth", 0);
  
            }
            else
            {
                currentHealth = maxHealth;
                ManagerScene.instance.isInnitGame = false;
                healthBar.SetMaxHealth(maxHealth);

                gameObject.GetComponent<NewPlayerController>().timer =0;
                gameObject.GetComponent<NewPlayerController>().currentligth = gameObject.GetComponent<NewPlayerController>().maxligth;
                gameObject.GetComponent<NewPlayerController>().ligthBar.SetMaxHealth(gameObject.GetComponent<NewPlayerController>().maxligth);
            }
        }
      
       
        _mySprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            //Debug.Log(SceneManager.GetActiveScene().name);
            if (ManagerScene.instance != null)
            {
                ManagerScene.instance.isInnitGame = true;
            }
            //SceneManager.LoadScene(0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            LifeSound();
            currentHealth +=2;
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
        DamageSound();
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
    public void LifeSound()
    {
        audioPlayerIt.clip = audiosIt[0];
        audioPlayerIt.Play();
    }
    public void DamageSound()
    {
        audioPlayerIt.clip = audiosIt[1];
        audioPlayerIt.Play();
    }

}
