using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewMonoBehaviour : MonoBehaviour
{
    private GameObject panel;

    void Awake()
    {
        //GameManager.OnGameStateChanged += GameManagerOnGameStateCHanged;
    }

    void OnDestroy()
    {
        //GameManager.OnGameStateChanged -= GameManagerOnGameStateCHanged;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
        // OU bien on pourrait revenir sur la scène menu principal
    }

    public void Continue()
    {
       panel.SetActive(false);
       Time.timeScale = 1;
    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }


}
