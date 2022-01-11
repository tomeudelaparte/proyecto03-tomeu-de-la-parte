using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;

    void Start()
    {
        gameOver = false;

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

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
                playerAnimator.SetTrigger("Jump_trig");
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

            int random = Random.Range(1, 3);
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", random);
        }
    }
}
