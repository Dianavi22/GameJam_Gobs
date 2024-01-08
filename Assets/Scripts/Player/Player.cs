using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _currentFood;
    [SerializeField] StandFood _standFood;
    [SerializeField] Client _currentClient;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            _standFood = collision.collider.gameObject.GetComponent<StandFood>();
            if(_curr)
            _currentFood = _standFood.standFood;
        }

        if (collision.gameObject.CompareTag("Client"))
        {
            Debug.Log("Detected");

            _currentClient = collision.collider.gameObject.GetComponent<Client>();
            if (_currentFood == _currentClient._command)
            {

                 Destroy(collision.collider.gameObject);
                // Add ref to GameManager with +1 client
                _currentFood = 100;

            }
            else
            {
                _currentFood = 100;
            }
        }
    }
}
