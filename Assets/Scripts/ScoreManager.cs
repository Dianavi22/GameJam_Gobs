//using System;
//using UnityEngine;
//using System.Collections;
//using TMPro;

//public class ScoreManager : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI ScoreText;
//    [SerializeField] private TextMeshProUGUI totalScoreText;
//    [SerializeField] private int Person;
//    private int PersonServed;
//    private int PersonNotServedInTime;
//    [SerializeField] private int Score;

//    // Use this for initialization
//    void Start()
//    {
//        if (GameManager.Instance.State == GameState.Play)
//        {
//            Person = 1;
//            PersonServed = 0;
//            PersonNotServedInTime = 0;
//            Score = 0;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    void HandleScore()
//    {
//        if (GameManager.Instance.State == GameState.Play)
//        {
//            TimerManager.IsBonus = false;
//            TimerManager.IsPenalized = false;
            
//            if (TimerManager.TimerLeftTime > 0)
//            {
//                // Si le joueur a servi a temps, on augmente les secondes
//                if (TimerManager.ServingTime > 0)
//                {
//                    Person--;
//                    PersonServed++;

//                    if (PersonServed == 2 && PersonNotServedInTime == 0)
//                    {
//                        Score += 20;
//                    }
//                    else
//                    {
//                        Score += 10;
//                    }
                    
//                    TimerManager.SecondOfPenalityOrBonus = 2;
//                    TimerManager.IsBonus = true;
//                    GameManager.Instance.State = GameState.ServedInTime;
//                } else
//                {
//                    TimerManager.SecondOfPenalityOrBonus = 2;
//                    TimerManager.IsPenalized = true;
//                    GameManager.Instance.State = GameState.NotServedInTime;

//                }
//            }
//            // GERER LE CHANGEMENT D'ETAT GAME OVER
//            //totalScoreText = string.Format("Le score total est ")
//            GameManager.Instance.State = GameState.TimerOver;


//        }
//    }
//}
