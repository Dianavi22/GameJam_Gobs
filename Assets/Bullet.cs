using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] Collider bulletcollision;
    [SerializeField] GameObject _gfx;
    [SerializeField] ParticleSystem _destroyParticules;
    [SerializeField] Client _client;
    [SerializeField] int id;
    [SerializeField] Player player;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _hitWall;

    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        _audioSource = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();
        bulletcollision = GetComponent<Collider>();
    }
    void Update()
    {
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food") || collision.gameObject.CompareTag("Wall"))
        {
            _audioSource.PlayOneShot(_hitWall, 0.6f);
            DestroyBullet();
        }
        if (collision.gameObject.CompareTag("Client"))
        {
            _client = collision.collider.GetComponent<Client>();
            if (id == _client._command)
            {
                player.idSpawner = _client._spawner;
                player.IsGoodClient();
                Destroy(collision.collider.gameObject);
                DestroyBullet();

            }
            else
            {
                DestroyBullet();
                _audioSource.PlayOneShot(_hitWall, 0.6f);

            }

            if (collision.gameObject.CompareTag("Floor"))
            {
                DestroyBullet();
                _audioSource.PlayOneShot(_hitWall, 0.6f);

            }
        }
    }
    public void DestroyBullet()
    {
        bulletcollision.enabled = false;
        _gfx.SetActive(false);
        _destroyParticules.Play();
        Destroy(gameObject, 3f);
    }
}
