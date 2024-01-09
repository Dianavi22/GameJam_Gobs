using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    /*public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Instance of Null. Game manager is NULL");
            }
            return _instance;
        }
    }*/

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameState(GameState gameState)
    {
        State = gameState;

        switch(State)
        {
            case GameState.Play:
                StartGame();
                break;
            case GameState.Stop:
                MenuManager.Instance.Pause();
                break;
            case GameState.Continue:
                MenuManager.Instance.Continue();
                break;
            case GameState.Lose:
                /// Ne sera probablement pas gérer non plus, sauf si aucun clientn n'a été
                /// servi durant toute la partie
                break;
            case GameState.Victory:
                // Ne sera probablement pas gérer
                break;
            case GameState.ServedInTime:
                break;
            case GameState.NotServedInTime:
                // Afficher peut-être quelque chose ( ou non )
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }

        OnGameStateChanged?.Invoke(gameState);
    }

    public void IsGameOver()
    {
        
    }

    public void StartGame()
    {
        // Scene of the game
        SceneManager.LoadScene("Scenes/JadeScene");
    }
}

public enum GameState
{
    Victory,
    Lose,
    Stop,
    Continue,
    Play,
    TimerOver,
    TimerBonus,
    ServedInTime,
    NotServedInTime,
}
