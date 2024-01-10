using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerManager : MonoBehaviour
{

    [SerializeField] bool isGameFinished;
    public float seconds;
    private bool isRunning = false;
    public TMP_Text scoreText;


    private void Awake()
    {
      
    }
    void Start()
    {
        seconds = 51;
        StartTimer();
    }
    void Update()
    {
        if (isRunning && isGameFinished == false)
        {
            IncreaseTimer();
        }
    }

    void StartTimer()
    {
        isRunning = true;
    }

    void IncreaseTimer()
    {
        
            seconds -= Time.deltaTime;
            //decompte
            //seconds -= Time.deltaTime;
         //   scoreText.text = seconds.ToString();
            float minute = Mathf.FloorToInt(seconds / 60);
            float sec = Mathf.FloorToInt(seconds % 60);
            if (sec < 10)
            {
                scoreText.text = minute + " : 0" + sec.ToString();
            }
            else
            {
                scoreText.text = minute + " : " + sec.ToString();
            }
        
    }


}
