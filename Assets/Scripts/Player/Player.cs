using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _currentFood;
    [SerializeField] StandFood _standFood;
    [SerializeField] Client _currentClient;
    [SerializeField] SpawnerManager _spawnerManager;
    [SerializeField] int idSpawner;
    [SerializeField] Collider _collider;
    [SerializeField] GameObject _itemSelectionned;
    [SerializeField] GameObject _spawner;
    [SerializeField] GameObject _spawner2;
    [SerializeField] GameObject _spawner3;
    


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            _standFood = collision.collider.gameObject.GetComponent<StandFood>();
            _currentFood = _standFood.standFood;
        }

        if (collision.gameObject.CompareTag("Client"))
        {

            _currentClient = collision.collider.gameObject.GetComponent<Client>();
            if (_currentFood == _currentClient._command)
            {

                idSpawner = _currentClient._spawner;
                Destroy(collision.collider.gameObject);
                Invoke("SpawnTaMere",0.5f);
              
                Debug.Log("_currentClient._spawner " + _currentClient._spawner);

                //StartCoroutine(SpawnClient());
                // Add ref to GameManager with +1 client
                _currentFood = 100;

            }
            else
            {
               
                _currentFood = 100;
            }
        }





    }

    public void SpawnTaMere()
    {
        if (idSpawner == 0)
        {
            _spawner.GetComponent<SpawnerManager>().SpawnObject();
        }
        else if (idSpawner == 1)
        {
            _spawner2.GetComponent<SpawnerManager>().SpawnObject();

        }
        else
        {
            _spawner3.GetComponent<SpawnerManager>().SpawnObject();

        }
    }

    private void Update()
    {
        _itemSelectionned.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0,3.2f,0));
    }

    private void OnCollisionExit()
    {
        if ( _standFood != null) { 
        _standFood = null;
        }
        if (_currentClient != null)
        {
            _currentClient = null;
        }
    }
}
