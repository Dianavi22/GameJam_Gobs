using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public int _command;
    private void Start()
    {
        
    }

     void ChoiceClient()
    {
        _command = Random.Range(0, 5);
    }
}
