using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public GameObject objectToSpawn;  
    public Transform spawnPoint;

    public List<GameObject> spawnerList = new List<GameObject>();

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnObject();
        //}

    }
    public void SpawnObject(int intdwd)
    {

            Debug.Log("SPAWN");
            Instantiate(objectToSpawn, spawnerList[0].transform.position, spawnPoint.rotation);
            
    }
}
