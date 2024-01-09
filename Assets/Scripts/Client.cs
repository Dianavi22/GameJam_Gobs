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
    [SerializeField] GameObject _itemSelectionned;
    private void Start()
    {
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

        Debug.Log("HERE");
        new WaitForSeconds(1f);
        _collider.enabled = true;
        _gfx.SetActive(true);
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spawner"))
        {
          _spawner = GetComponent<Spawner>().idSpawner;
        }
    }

    private void Update()
    {
       // Destroy(gameObject, 20f);
    }

}
