using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistance = 0.4f;
    [SerializeField]
    private LayerMask groundMask;
    private AudioSource ac;
    [SerializeField]
    private AudioClip[] clips;

    private Vector3 velocity;
    bool isGrounded;

    float StepTimeDefault = 0.5f;
    float StepTime;

    void Start(){
        StepTime = StepTimeDefault;
        controller = gameObject.GetComponent<CharacterController>();
        ac = GetComponent<AudioSource>();
    }


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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * 2f * Time.deltaTime);
        } else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.LeftControl)){
            controller.height = 1.68f;
        }else{
            controller.height = 3.8f;
        }
        if (StepTime > 0)
        {
            StepTime -= Time.deltaTime;
        }
        //Debug.Log(controller.velocity.magnitude);
        if(isGrounded == true  && ac.isPlaying == false && StepTime <= 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)) { StepTime = StepTimeDefault/2; } else { StepTime = StepTimeDefault; }
            Debug.Log(StepTime);
            if(x > 0.5f || x < -0.5f || z > 0.5f || z < -0.5f)
            {
                ac.volume = Random.Range(0.8f, 1f);
                ac.pitch = Random.Range(0.8f, 1.1f);
                ac.Play();
            }
        }
    }

    
}
