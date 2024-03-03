using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.Lumin;

public class ThirdPersonController : MonoBehaviour
{
    public float sensitivity;
    public float playerSpeed = 2.0f;
    private float JumpForce = 1.0f;

    private CharacterController m_Controller;
    private Animator m_Animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        m_Controller = gameObject.GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        groundedPlayer = m_Controller.isGrounded;

                // Paragliding logic
        if (isParagliding)
        {
            HandleParagliding();
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -0.5f;
        }

        Vector3 input = new(Input.GetAxis("Horizontal"), 0, Mathf.Clamp(Input.GetAxis("Vertical"), 0, 1)); 
        // no moving backwards

        // Calculate movement direction based on player's orientation
        Vector3 moveDirection = transform.forward * input.z + transform.right * input.x;
        moveDirection.y = 0; // Ensure movement is strictly horizontal

        if (moveDirection != Vector3.zero)
        {
            // Calculate the target rotation based on the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

            // Smoothly interpolate the player's rotation towards the target rotation
            float rotationSpeed = 2.0f; // Adjust this value to control the rotation speed
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // Move the player
        m_Controller.Move(moveDirection.normalized * Time.deltaTime * playerSpeed);

        // Update the animator if you're using one
        m_Animator.SetFloat("MovementX", input.x);
        m_Animator.SetFloat("MovementZ", input.z);



        // Changes the height position of the player..
        if (Input.GetButton("Jump"))
        {
            playerVelocity.y = JumpForce; // Apply continuous upward force
            //m_Animator.SetBool("IsFlying", true); // Consider adding an IsFlying parameter to your Animator
        }
        else
        {
            //m_Animator.SetBool("IsFlying", false);
            // Apply gravity if not flying (space not pressed)
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        m_Controller.Move(playerVelocity * Time.deltaTime);

    }

    // Paragliding variables
    public float glideGravity = -1.0f; // Reduced gravity while gliding
    public float glideSpeed = 5.0f; // Forward speed while gliding
    public float turnSpeed = 2.0f; // Turn speed while gliding
    private bool isParagliding = false; // Is the player currently paragliding?

    public float initialLiftForce = 10000; // Adjust this value as needed for your game
    private bool hasInitiatedLift = false;

    public void StartParagliding()
    {
        isParagliding = true;
        // Any other setup you need to do when starting to paraglide
    }

    private void HandleParagliding()
    {


        //push player in air
            // Initial lift to send the player into the air
        if (!hasInitiatedLift)
        {
            playerVelocity.y += initialLiftForce; // Apply an initial upward force
            hasInitiatedLift = true; // Ensure we only do this once at the start
        }
        // Handle horizontal movement
        Vector3 glideDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 1).normalized;
        glideDirection = transform.TransformDirection(glideDirection);
        
        // Apply forward glide movement
        Vector3 glideForward = transform.forward * glideSpeed * Time.deltaTime;
        m_Controller.Move(glideForward);

        // Apply turning
        if (glideDirection.x != 0)
        {
            transform.Rotate(0, glideDirection.x * turnSpeed, 0);
        }

        // Apply glide gravity
        playerVelocity.y += glideGravity * Time.deltaTime;
        m_Controller.Move(playerVelocity * Time.deltaTime);

        // Check if paragliding should stop (e.g., player touches the ground)
        if (groundedPlayer)
        {
            StopParagliding();
        }
    }

    private void StopParagliding()
    {
        isParagliding = false;
        hasInitiatedLift = false; // Reset for next time paragliding starts
        // Any other cleanup you need to do when stopping paragliding
    }

}
