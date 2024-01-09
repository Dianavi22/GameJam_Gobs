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
                Debug.Log("SpawnClient");

                _spawnerManager.SpawnObject(idSpawner);
                Destroy(collision.collider.gameObject);
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
