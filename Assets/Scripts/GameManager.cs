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



    public void IsGameOver()
    {
        
    }

    public void GameIsPause()
    {

    }
 
}




