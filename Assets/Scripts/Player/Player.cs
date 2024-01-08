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
            _currentFood = _standFood.standFood;
        }

        if (collision.gameObject.CompareTag("Client"))
        {
            _currentClient = collision.collider.gameObject.GetComponent<Client>();
            Debug.Log("_currentFood" + _currentFood + " / " + "_currentClient._command" + _currentClient._command);
            if(_currentFood == _currentClient._command)
            {
                Destroy(collision.collider);
                // Add ref to GameManager with +1 client
                _currentClient = null;

            }
            else
            {
                _currentClient = null;
            }
        }
    }
}
