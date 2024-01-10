using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] bool isGamePaused = false;
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] Button _resumeButton;
    [SerializeField] EventSystem _eventSysteme;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)

            {
                Time.timeScale = 0f;
                _eventSysteme.SetSelectedGameObject(_resumeButton.gameObject);

                _pauseMenu.SetActive(true);
                isGamePaused = true;
            }
            else
            {
                ResumeButton();
            }

        }
    }

    public void ResumeButton()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResumeButton();

    }

    public void MenuButton()
    {
        ResumeButton();
        SceneManager.LoadScene(0);
    }

}
