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
    public int idSpawner;
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

    [SerializeField] GameObject prefab;
    [SerializeField] GameObject bulletSpawn;

    [SerializeField] GameManager gameManager;

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
                prefab = _standFood.bullet;
                _currentFood = _standFood.standFood;
                _spriteCurrrentBackground.sprite = _bg1;
                _spriteCurrrentObject.sprite = _standFood.sprite;
                _soundEffect.PlayOneShot(_takeItem, 0.6f);
            }
          

            _spriteCurrrentObject.enabled = true;

        }



        if (collision.gameObject.CompareTag("Wall"))
        {
            _soundEffect.PlayOneShot(_hitSound, 0.6f);

            LostItem();
            _playerController.enabled = false;
            Invoke("ActivePlayerController", 0.3f);
        }
    }

    public void IsGoodClient()
    {
        Invoke("SpawnTaMere", 0.5f);
        gameManager.nbClients++;
        LostItem();
    }
    
    public void ShootFood()
    {
        GameObject bullet = Instantiate(prefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        rbBullet.AddForce(transform.forward * 10f, ForceMode.Impulse);
        LostItem();
    }

    public void LostItem()
    {
        _spriteCurrrentObject.enabled = false;
        _spriteCurrrentBackground.sprite = _bg2;
        _currentFood = 100;
        prefab = null;
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

        if (Input.GetButtonDown("Fire1") && prefab != null)
        {
            ShootFood();
        }
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


