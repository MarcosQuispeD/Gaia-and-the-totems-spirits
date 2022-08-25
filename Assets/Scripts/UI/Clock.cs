using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Clock : MonoBehaviour
{
    public float initialTime;
    
    [Range(-10.0f,10.0f)]
    public float scaleTime = 1;

    private TextMeshProUGUI _myText;
    private float _frameTimeWhitScaleTime = 0f;
    private float _timeInSecondsToShow = 0f;
    private float _pauseScaleTime;
    private float _initialScaleTime;
    
    private bool _paused = false;    


    void Start()
    {
        _initialScaleTime = scaleTime;
        _myText = GetComponent<TextMeshProUGUI>();

        _timeInSecondsToShow = initialTime;
        ClockUpdate(initialTime);               
        
    }

    void Update()
    {
        _frameTimeWhitScaleTime = Time.deltaTime * scaleTime;
        _timeInSecondsToShow += _frameTimeWhitScaleTime;

        ClockUpdate(_timeInSecondsToShow);

        if(Input.GetKeyDown(KeyCode.I))
        {
            Continue();                
        }

        
        if(Input.GetKeyDown(KeyCode.O))
        {
            Restart();
    
        }

        
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    
    }


    public void ClockUpdate(float _timeInSeconds)
    {
        int _hours = 0;
        int _minutes = 0;
        int _seconds = 0;
        string _clockText;
        
        if (_timeInSeconds < 0)
        {
            _timeInSeconds = 0;
        }

        _hours = (int)_timeInSeconds / 3600;
        _minutes = (int)(_timeInSeconds - (_hours * 3600)) / 60;
        _seconds = (int)_timeInSeconds % 60;

        _clockText = _hours.ToString("00") + ":" + _minutes.ToString("00") + ":" + _seconds.ToString("00");
        _myText.text = _clockText;   

    }


    public void Pause()
    {
        if (!_paused)
        {
            _paused = true;
            _pauseScaleTime = scaleTime;
            scaleTime = 0;
        }
    }

    public void Continue()
    {
        if (_paused)
        {
            _paused = false;
            scaleTime = _pauseScaleTime;
        }
    }

    public void Restart()
    {
        _paused = false;
        scaleTime = _initialScaleTime;
        _timeInSecondsToShow = initialTime;
        ClockUpdate(_timeInSecondsToShow);
    }



}
