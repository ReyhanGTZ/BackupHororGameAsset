using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Sound
    AudioSource gameSound;
    AudioClip clipWalk;
    AudioClip clipReload;
    AudioClip clipAutoFire;

    //Animation
    public Animator animator;

    public CharacterController controller;
    public float speed = 2f;
    public float gravity = -10f;
    public float jumpHeight = 0.5f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        //Sound
        gameSound = GetComponent<AudioSource>();
        clipWalk = Resources.Load<AudioClip>("Audio/Character/FootStep/FootStepSound");
        //clipAutoFire = Resources.Load<AudioClip>("Audio/AK47/Vandal auto fire");
        //clipReload = Resources.Load<AudioClip>("Audio/AK47/AK47_Reload");
    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y =Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //SPRINT//
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            speed= 3f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            speed= 2f;
        }

        //WALK
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            gameSound.clip = clipWalk;
            gameSound.Play();
            animator.SetBool("Walk", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            gameSound.clip = clipWalk;
            gameSound.Stop();
            animator.SetBool("Walk", false);
        }

        /*if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Walk", false);
            gameSound.clip = clipWalk;
            gameSound.Stop();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Walk", false);
            gameSound.clip = clipWalk;
            gameSound.Stop();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Walk", false);
            gameSound.clip = clipWalk;
            gameSound.Stop();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk", false);
            gameSound.clip = clipWalk;
            gameSound.Stop();
        }*/


        //WALK Strafe
        if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A) && isGrounded)
        {
            speed= 2f;
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }

        if(Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D) && isGrounded)
        {
            speed= 2f;
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }

        if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A) && isGrounded)
        {
            speed= 2f;
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }

        if(Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D) && isGrounded)
        {
            speed= 2f;
            animator.SetBool("Walk", true);
            gameSound.clip = clipWalk;
            gameSound.Play();
        }
    }
}
