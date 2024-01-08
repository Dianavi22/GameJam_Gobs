using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public int _command;
    private void Start()
    {
        ChoiceClient();
    }

     void ChoiceClient()
    {
        _command = Random.Range(0, 5);
    }
}
