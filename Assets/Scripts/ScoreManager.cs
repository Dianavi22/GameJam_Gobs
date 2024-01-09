using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private readonly string KEY_HIGH_SCORE = "HIGH_SCORE";
    private readonly string KEY_CURRENT_SCORE = "HIGH_SCORE";

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private int Person;

    private int PersonServed;
    private int PersonNotServedInTime;

    private static int Score;

    private static int highScore;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey(KEY_HIGH_SCORE))
        {
            highScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE);
        }

        if (GameManager.Instance.State == GameState.Play)
        {
            Person = 1;
            PersonServed = 0;
            PersonNotServedInTime = 0;
            Score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleScore();
    }

    void HandleScore()
    {
        if (GameManager.Instance.State == GameState.Play)
        {
            TimerManager.IsBonus = false;
            TimerManager.IsPenalized = false;

            if (TimerManager.TimerLeftTime > 0)
            {
                if (TimerManager.ServingTime > 0)
                {
                    HandleInTimeService(Score);
                }
                else
                {
                    HandleNotInTimeService(Score);
                }
            }

            HandleCurrentGameScore(Score);
            HandleHighScore(Score);

            GameManager.Instance.State = GameState.TimerOver;

        }
    }

    private void HandleHighScore(int score)
    {
        if (PlayerPrefs.HasKey(KEY_HIGH_SCORE))
        {
            if (score > PlayerPrefs.GetInt(KEY_HIGH_SCORE))
            {
                PlayerPrefs.SetInt(KEY_HIGH_SCORE, score);
            }
        }
        else
        {
            PlayerPrefs.SetInt(KEY_HIGH_SCORE, score);
        }
    }

    private void HandleCurrentGameScore(int score)
    {
        PlayerPrefs.SetInt(KEY_CURRENT_SCORE, score);
    }

    private void HandleInTimeService(int score)
    {

        if (PersonServed == 2 && PersonNotServedInTime == 0)
        {
            score += 20;
        }
        else
        {
            score += 10;
        }

        Score = score;
        
        Person--;
        PersonServed++;

        TimerManager.SecondOfPenalityOrBonus = 2;
        TimerManager.IsBonus = true;
        GameManager.Instance.State = GameState.ServedInTime;
    }

    private void HandleNotInTimeService(int score)
    {
        TimerManager.SecondOfPenalityOrBonus = 2;
        TimerManager.IsPenalized = true;
        GameManager.Instance.State = GameState.NotServedInTime;
    }
}
