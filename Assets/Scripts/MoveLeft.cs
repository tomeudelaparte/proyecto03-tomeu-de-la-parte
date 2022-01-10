using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10f;

    private PlayerController playerControllerScript;

    private void Start()
    {
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
