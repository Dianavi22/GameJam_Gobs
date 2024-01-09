using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public SpawnerManager spawnerManager;
    public int _command;
    public int _spawner;
    private void Start()
    {
        ChoiceClient();
    }

     void ChoiceClient()
    {
        _command = Random.Range(0, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spawner"))
        {
          _spawner = GetComponent<Spawner>().idSpawner;
        }
    }

    private void Update()
    {
        Destroy(gameObject, 20f);
    }

}
