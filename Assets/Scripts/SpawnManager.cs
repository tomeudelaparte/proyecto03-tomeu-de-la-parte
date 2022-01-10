using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatRate = 2f;

    void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript = FindObjectOfType<PlayerController>();

        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    private void spawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
