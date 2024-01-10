using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardMenu : MonoBehaviour
{
    [SerializeField] TimerManager _timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (_timer.seconds <= 0)
        {

        }
    }

    public void GameOver()
    {
        _timer.seconds = 0;
        Time.timeScale = 1f;

    }
}
