using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public float spawnTime = 0f;
    public float maxTime = 10f;
    public float minTime = 5f;

    public GameObject[] objects;

    private int arrayLength = 0;

    void Awake()
    {
        arrayLength = objects.GetLength(0);
        spawnTime = Random.Range(maxTime, minTime);

        spawnObject();
    }

    void spawnObject()
    {
        Instantiate(objects[Random.Range(0, arrayLength)], transform.position, Quaternion.identity);

        spawnTime = Random.Range(maxTime, minTime);

        Invoke("spawnObject", spawnTime);
    }
}
