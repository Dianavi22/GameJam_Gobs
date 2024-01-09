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
        SpawnObject();
    }

    public void SpawnObject()
    {

            Debug.Log("SPAWN");
            Instantiate(objectToSpawn,transform.position, Quaternion.identity);
        isEmpty = false;
    }
}
