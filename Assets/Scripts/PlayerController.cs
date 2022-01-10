using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    private Rigidbody playerRigidbody;
    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;

    void Start()
    {
        gameOver = false;

        playerRigidbody = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {

        if (!gameOver)
        {

            if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround)
            {
                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnTheGround = false;
            }
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
        }

        if (otherCollider.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
        }
    }
}
