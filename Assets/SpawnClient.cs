using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClient : MonoBehaviour
{

    public GameObject objectToSpawn;  
    public Transform spawnPoint;
    public bool isEmpty = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }

        if (isEmpty == true)
        {
            SpawnObject();
        }
    }
    public void SpawnObject()
    {

            Debug.Log("SPAWN");
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            isEmpty = false;
    }
}
