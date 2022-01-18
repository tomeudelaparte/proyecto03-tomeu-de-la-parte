using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    public ParticleSystem explosion, splatter;

    public AudioClip jumpClip;
    public AudioClip crashClip;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;

    private Vector3 offset = new Vector3(0, 1.5f, 0);
    private Vector3 offset02 = new Vector3(-0.5f, 0, 0);

    [SerializeField] private float jumpForce = 400f;
    public float gravityModifier = 1;
    private bool isOnTheGround = true;

    private int lives = 3;

    void Start()
    {
        gameOver = false;

        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;

        splatter = Instantiate(splatter, transform.position + offset02, splatter.transform.rotation);
        splatter.Play();

        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        lives = 3;
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

                splatter.Stop();

                playerAudioSource.PlayOneShot(jumpClip, 1f);
            }
        }
    }

    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                isOnTheGround = true;

                splatter.Play();
            }

            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Destroy(otherCollider.gameObject);

                lives--;

                if (lives <= 0)
                {
                    GameOver();
                } else
                {
                    playerAnimator.SetTrigger("Crash_Trig");
                }
            }
        }
    }

    private void GameOver()
    {
        gameOver = true;

        int random = Random.Range(1, 3);
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", random);

        explosion = Instantiate(explosion, transform.position + offset, explosion.transform.rotation);
        explosion.Play();

        splatter.Stop();

        playerAudioSource.PlayOneShot(crashClip, 0.75f);
        cameraAudioSource.volume = 0.3f;
    }
}
