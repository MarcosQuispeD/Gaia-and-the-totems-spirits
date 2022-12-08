using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Clock : MonoBehaviour
{
    public static Clock instance;
    [SerializeField] private float initialTime;

    [Range(-10.0f, 10.0f)]
    [SerializeField] private float scaleTime = 1;
    public TextMeshProUGUI myText;
    private float frameTimeWhitScaleTime = 0f;
    private float timeInSecondsToShow = 0f;
    private float pauseScaleTime;
    private float initialScaleTime;

    private bool paused = false;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);


        initialScaleTime = scaleTime;
        myText = GetComponent<TextMeshProUGUI>();

        timeInSecondsToShow = initialTime;
        ClockUpdate(initialTime);

    }

    void Update()
    {
        frameTimeWhitScaleTime = Time.deltaTime * scaleTime;
        timeInSecondsToShow += frameTimeWhitScaleTime;

        ClockUpdate(timeInSecondsToShow);

        // if (Input.GetKeyDown(KeyCode.I))
        // {
        //     Continue();
        // }


        // if (Input.GetKeyDown(KeyCode.O))
        // {
        //     Restart();

        // }


        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     Pause();
        // }

    }


    public void ClockUpdate(float timeInSeconds)
    {
        int hours = 0;
        int minutes = 0;
        int seconds = 0;
        string clockText;

        if (timeInSeconds < 0)
        {
            timeInSeconds = 0;
        }

        hours = (int)timeInSeconds / 3600;
        minutes = (int)(timeInSeconds - (hours * 3600)) / 60;
        seconds = (int)timeInSeconds % 60;

        clockText = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        myText.text = clockText;

    }


    public void Pause()
    {
        if (!paused)
        {
            paused = true;
            pauseScaleTime = scaleTime;
            scaleTime = 0;
        }
    }

    public void Continue()
    {
        if (paused)
        {
            paused = false;
            scaleTime = pauseScaleTime;
        }
    }

    public void Restart()
    {
        paused = false;
        scaleTime = initialScaleTime;
        timeInSecondsToShow = initialTime;
        ClockUpdate(timeInSecondsToShow);
    }



}
