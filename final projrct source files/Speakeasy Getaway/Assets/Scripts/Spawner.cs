using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Spawn1;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        Instantiate(Spawn1, transform.position, transform.rotation);

        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
