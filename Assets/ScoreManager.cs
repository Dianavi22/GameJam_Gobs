using System;
using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    [Serializable] private int PersonServed;
    [Serializable] private int Person;
    private int Second;

    // Use this for initialization
    void Start()
    {
        if (GameManager.Instance.State == GameState.Play)
        {
            Person = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void HandleScore()
    {
        if (GameManager.Instance.State == GameState.Play)
        {
            if (TimeManager.TimerLeftTime > 0)
            {
                // Si le joueur a servi a temps, on augmente les secondes
                if (TimerManager.ServingTime > 0)
                {
                    Second = 1;

                } else
                {
                    Second--;
                }
            }

            // GERER LE CHANGEMENT D'ETAT GAME OVER

        }
    }
}
