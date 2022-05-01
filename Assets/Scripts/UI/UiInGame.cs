using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiInGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool paused = false;
    public AudioClip[] audiosIG;
    public AudioSource audioPlayerIG;

    private void Start()
    {
        audioPlayerIG = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                ClipClick2();
                Resume();
            }
            else
            {
                ClipClick();
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ClipClick()
    {
        audioPlayerIG.clip = audiosIG[0];
        audioPlayerIG.Play();
    }
    public void ClipClick2()
    {
        audioPlayerIG.clip = audiosIG[1];
        audioPlayerIG.Play();
    }
}
