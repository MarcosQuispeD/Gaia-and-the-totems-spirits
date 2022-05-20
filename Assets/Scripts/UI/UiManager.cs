using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = this.GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void PlayCombat()
    {
        SceneManager.LoadScene(4);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ClipClick()
    {
        audioPlayer.clip = audios[0];
        audioPlayer.Play();
    }
    public void ClipClick2()
    {
        audioPlayer.clip = audios[1];
        audioPlayer.Play();
    }
}