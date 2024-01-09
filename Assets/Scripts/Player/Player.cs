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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            _standFood = collision.collider.gameObject.GetComponent<StandFood>();
            _currentFood = _standFood.standFood;
        }

        if (collision.gameObject.CompareTag("Client"))
        {
            Debug.Log("Detected");

            _currentClient = collision.collider.gameObject.GetComponent<Client>();
            if (_currentFood == _currentClient._command)
            {
                idSpawner = _currentClient._spawner;
                Debug.Log("DestroyClient" + idSpawner);
                StartCoroutine(SpawnClient());
                Destroy(collision.collider.gameObject);
                // Add ref to GameManager with +1 client
                _currentFood = 100;
                _collider.enabled = false;
                Invoke("DisableCollider", 0.3f);

            }
            else
            {
                _collider.enabled = false;
                Invoke("DisableCollider", 0.3f);
                _currentFood = 100;
            }
        }


        IEnumerator SpawnClient()
        {
            new WaitForSeconds(0.5f);
            Debug.Log(idSpawner);
            _spawnerManager.SpawnObject(idSpawner);
            yield return null;
        }

        void DisableCollider()
        {
            _collider.enabled = true;

        }

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
