using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public int nbClients;
    [SerializeField] TMP_Text _nbClientsTxt;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Instance of Null. Game manager is NULL");
            }
            return _instance;
        }
    }

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _nbClientsTxt.text = nbClients.ToString();
    }

    public void UpdateGameState(GameState gameState)
    {
        State = gameState;

        switch(State)
        {
            case GameState.Play:
                break;
            case GameState.Stop:
                break;
            case GameState.Lose:
                break;
            case GameState.Victory:
                break;
            case GameState.ServedInTime:
                break;
            case GameState.NotServedInTime:
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
    Play,
    TimerOver,
    TimerBonus,
    ServedInTime,
    NotServedInTime,
}
