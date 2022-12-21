using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour
{
    public float currentHealth;
    public HealthBar healthBar;
    public SpriteRenderer _mySprite, _headSprite;
    public AudioClip[] audiosIt;
    public AudioSource audioPlayerIt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
    }


    void TakeDamage()
    {
        DamageSound();
        StartCoroutine(Feedback());
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
