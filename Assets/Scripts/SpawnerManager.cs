using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public GameObject objectToSpawn;  
    public int nbSpawn;
    public List<GameObject> spawnerList = new List<GameObject>();
    public bool isEmpty;
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnObject();
        //}

    }

    private void Start()
    {
        SpawnObject(0);
        SpawnObject(1);
        SpawnObject(2);
    }

    public void SpawnObject(int nbSpawn)
    {

            Debug.Log("SPAWN");
            Instantiate(objectToSpawn, spawnerList[nbSpawn].transform.position, Quaternion.identity);
        isEmpty = false;
    }
}
