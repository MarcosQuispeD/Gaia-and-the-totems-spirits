using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 1:
                    RepoMusic();
                    break;
                case 2:
                    RepoMusic();
                    break;
                case 3:
                    BattleMusic();
                    break;
                case 4:
                    RepoMusic();
                    break;
                case 5:
                    RepoMusic();
                    break;
                case 6:
                    BattleMusic();
                    break;
                case 7:
                    BattleMusic();
                    break;
                case 8:
                    BattleMusic();
                    break;
            }

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }


    }

    public void BattleMusic()
    {
        audioPlayerMs.clip = audiosMs[1];
        audioPlayerMs.Play();
    }
    public void RepoMusic()
    {
        audioPlayerMs.clip = audiosMs[0];
        audioPlayerMs.Play();
    }
}
