using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] Image _spriteCurrrentObject;
    [SerializeField] Image _spriteCurrrentBackground;

    [SerializeField] PlayerController _playerController;


    [SerializeField] Sprite _noneSprite;
    [SerializeField] Sprite _bg1;
    [SerializeField] Sprite _bg2;


    [SerializeField] AudioClip _hitSound;
    [SerializeField] AudioClip _takeItem;
    [SerializeField] AudioSource _soundEffect;

    private void Start()
    {
        _spriteCurrrentObject.enabled = false;
        _spriteCurrrentBackground.sprite = _bg2;
        _currentFood = 100;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            _standFood = collision.collider.gameObject.GetComponent<StandFood>();
            if (_standFood.standFood != _currentFood)
            {
                _currentFood = _standFood.standFood;
                _spriteCurrrentBackground.sprite = _bg1;
                _spriteCurrrentObject.sprite = _standFood.sprite;
                _soundEffect.PlayOneShot(_takeItem, 0.6f);
            }
          

            _spriteCurrrentObject.enabled = true;

        }

        if (collision.gameObject.CompareTag("Client"))
        {

            _currentClient = collision.collider.gameObject.GetComponent<Client>();
            if (_currentFood == _currentClient._command)
            {

                idSpawner = _currentClient._spawner;
                Destroy(collision.collider.gameObject);
                Invoke("SpawnTaMere", 0.5f);

                Debug.Log("_currentClient._spawner " + _currentClient._spawner);

                //StartCoroutine(SpawnClient());
                // Add ref to GameManager with +1 client
                _currentFood = 100;
                _spriteCurrrentObject.enabled = false;
                _spriteCurrrentBackground.sprite = _bg2;
                Debug.Log("EMPTY");


            }
            else
            {
                _spriteCurrrentObject.enabled = false;
                _spriteCurrrentBackground.sprite = _bg2;
                _currentFood = 100;
                Debug.Log("EMPTY");

            }




        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            _spriteCurrrentObject.enabled = false;
            _spriteCurrrentBackground.sprite = _bg2;
            _soundEffect.PlayOneShot(_hitSound, 0.6f);
            _currentFood = 100;
            _playerController.enabled = false;
            Invoke("ActivePlayerController", 0.3f);
        }
    }

    public void ActivePlayerController()
    {
        _playerController.enabled = true;
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
        _itemSelectionned.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 3.2f, 0));
    }

    private void OnCollisionExit()
    {
        if (_standFood != null)
        {
            _standFood = null;
        }
        if (_currentClient != null)
        {
            _currentClient = null;
        }
    }
}


