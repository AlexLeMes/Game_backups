using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTower : MonoBehaviour {

    GameObject player;

    public GameObject tower01;
    public GameObject tower02;

    GameObject spawnedTower;

    public bool canSpawnHere = true;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canSpawnHere = true;
    }

    public void spawnTowerOne()
    {
        if(canSpawnHere == true)
        {
            spawnedTower = Instantiate(tower01);
            spawnedTower.transform.position = player.transform.position;
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

}
