using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{

    public int _command;
    public GameObject _spawner;
    private void Start()
    {
        ChoiceClient();
    }

     void ChoiceClient()
    {
        _command = Random.Range(0, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spawner"))
        {
          _spawner = GetComponent<GameObject>();
        }
    }

}
