using System;
using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{
    private GameObject select;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateCHanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateCHanged;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
