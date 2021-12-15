using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(BoxCollider)))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _anim;
    public float jumpHeight;
    public float gravityModifier;
    public float movementSpeed;

    private bool isGrounded;
    public bool gameover;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle; //Running dirt particle.

    public static PlayerController instance;

    public AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }
    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameover)
        {
            dirtParticle.Stop();
            _rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            isGrounded = false;
            _anim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 0.3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isGrounded = true;
        }

        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 0.5f);
            dirtParticle.Stop();
            explosionParticle.Play();
            gameover = true;
            _anim.SetBool("Death_b", true);
            _anim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
        }
    }
}
