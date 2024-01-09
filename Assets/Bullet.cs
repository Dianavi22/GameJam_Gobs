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

    [SerializeField] private Collider playercollision;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        playercollision = FindObjectOfType<Player>().GetComponent<Collider>();
        bulletcollision = GetComponent<Collider>();
    }
    void Update()
    {
        Destroy(gameObject, 10f);
        Physics.IgnoreCollision(playercollision, bulletcollision);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food") || collision.gameObject.CompareTag("Wall") )
        {
            DestroyBullet();
        }
        if (collision.gameObject.CompareTag("Client"))
        {
            _client = collision.collider.GetComponent<Client>();
            if(id == _client._command)
            {
                player.idSpawner = _client._spawner;
                player.IsGoodClient();
                Destroy(collision.collider.gameObject);
                DestroyBullet();

            }
            else
            {
                DestroyBullet();
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
