using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoardMenu : MonoBehaviour
{
    [SerializeField] TimerManager _timer;
    [SerializeField] GameManager _gameManager;
    [SerializeField] PauseManager _pauseManager;
    [SerializeField] GameObject _scoreBoard;
    [SerializeField] EventSystem _eventSysteme;
    [SerializeField] Button _retryButton;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _eventSysteme2;
    [SerializeField] GameObject _eventSysteme1;


    void Start()
    {
        
    }

    void Update()
    {
        if (_timer.seconds <=45)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        _timer.seconds = 0;
        _timer.scoreText.text = "0 : 00";
        Time.timeScale = 1f;
     //  _eventSysteme.SetSelectedGameObject(_retryButton.gameObject);
        _eventSysteme1.SetActive(false);
        _eventSysteme2.SetActive(true);
        _scoreBoard.SetActive(true);
        _player.SetActive(false);

    }

    public void Retry()
    {
        _pauseManager.RetryButton();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
