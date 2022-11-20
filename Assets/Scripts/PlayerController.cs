using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityMultiplier;
    [SerializeField] private UIManager uıManager;
    
    private const float BaseGravity = 9.81f;
    private Vector3 gravityForce;
    private bool isGrounded = true;
    public bool isGameOver = false;
    private static readonly int DeathTypeİnt = Animator.StringToHash("DeathType_int");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");

    
    private void Start()
    {
        playerRb.useGravity = false; //Oyuncunun gravitysini kapatıyoruz gravity'i kendimiz uygulayacağız
    }


    private void Update()
    {
        Jump();
    }

    
    private void FixedUpdate()
    {
        ApplyGravity(); //Uyguladığımız gravitynin düzgün çalışması için FixedUpdate'de çapırıyoruz
    }


    void ApplyGravity()
    {
        //Aşağı yönlü kuvvet uyguluyoruz gravity misali
        gravityForce = Vector3.down * (BaseGravity * gravityMultiplier);
        playerRb.AddForce(gravityForce, ForceMode.Acceleration);
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
            playerAnimator.SetTrigger(JumpTrig); //Jump animasyonunu triggerlıyoruz
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UIManager.GetScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Yere dokunduğumuzda
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();
            
        }//Engele Dokunduğumuzda
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            uıManager.ActivateLoseCanvas();
            isGameOver = true;
            UIManager.isGameOver = true;
            Debug.Log("game over");
            playerAnimator.SetBool(DeathB,true); //Ölme animasyonunu triggerlıyoruz
            playerAnimator.SetInteger(DeathTypeİnt,1); //Ölme animasyonu tipini seçiyoruz, animatörden bakabilirsin 2 tip var
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound,1.0f);
        }
    }
    
}
