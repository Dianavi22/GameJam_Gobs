using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public SpawnerManager spawnerManager;
    public int _command;
    public int _spawner;
    [SerializeField] GameObject _gfx;
    [SerializeField] Collider _collider;
    [SerializeField] ParticleSystem _spawnParticules;
    [SerializeField] Canvas _canvas;
 
    [SerializeField] AudioSource _audioSource;

    [SerializeField] Camera _camera;
    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _canvas.GetComponent<Canvas>().worldCamera = _camera;
        _spawnParticules.Play();
        _collider.enabled = false;
        _gfx.SetActive(false);
        ChoiceClient();
        StartCoroutine(SpawnGfx());
    }

     void ChoiceClient()
    {
        _command = Random.Range(0, 4);
    }

    IEnumerator SpawnGfx()
    {

        new WaitForSeconds(1f);
        _collider.enabled = true;
        _gfx.SetActive(true);
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HERE");

        if (collision.gameObject.CompareTag("Spawner"))
        {
          _spawner = collision.collider.GetComponent<Spawner>().idSpawner;
            Debug.Log("spawner" + _spawner);

        }
    }

    private void Update()
    {
       // Destroy(gameObject, 20f);
    }

}
