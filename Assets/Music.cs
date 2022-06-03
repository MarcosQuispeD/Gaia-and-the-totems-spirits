using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip[] audiosMs;
    public AudioSource audioPlayerMs;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //void OnT(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        RepoMusic();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCollider")
        {
            RepoMusic();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void BattleMusic()
    {
        audioPlayerMs.clip = audiosMs[0];
        audioPlayerMs.Play();
    }
    public void RepoMusic()
    {
        audioPlayerMs.clip = audiosMs[0];
        audioPlayerMs.Play();
    }
}
