using UnityEngine;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    

    /// <summary>
    /// The movement speed of the player
    /// TODO: delete later because this is just used for testing
    /// </summary>
    [SerializeField] private readonly float _movementSpeed = 5.0f;

    /// <summary>
    /// Speed at which the player flies up
    /// TODO: delete later because we don't want the player flying like this --
    /// or do we?
    /// </summary>
    [SerializeField] private readonly float _flyingSpeed = 5.0f;

    /// <summary>
    /// Sensitivity of the mouse movement
    /// </summary>
    [SerializeField] private readonly float _turningSpeed = 3.0f;

    /// <summary>
    /// The input from the horizontal axis
    /// </summary>
    private float _horizontalInput;

    /// <summary>
    /// The input from the vertical axis
    /// </summary>
    private float _forwardInput;

    /// <summary>
    /// The input from the space bar
    /// </summary>

    private float verticalVelocity;
    private float gravityScale = 5;
    private float jumpHeight = 5;
    public float groundCheckDistance;
    private float bufferCheckDistance = 0.1f;
    public bool isGrounded;
    public TextMeshProUGUI verticalSpeedText;
    public TextMeshProUGUI horizontalSpeedText;


    private Vector3 horizontalVelocity = Vector3.zero;

    private float horizontalAcceleration = 10.0f;
    // Add a new variable to control the glide gravity scale, which determines how slow the glide is.
    [SerializeField] private float glideGravityScale = 0.5f; // Adjust this value as needed for the desired glide effect

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /// Jump
        //add gravity to object
            
        float appliedGravityScale = gravityScale;
            
        // Check if the player has jumped and is currently holding down the space bar (not grounded)
        if (!isGrounded && Input.GetKey(KeyCode.Space))
        {
            // Change the gravity scale to the gliding gravity when the player is gliding
            appliedGravityScale = glideGravityScale;
        }

        // Apply the gravity to the vertical velocity
        verticalVelocity += Physics.gravity.y * appliedGravityScale * Time.deltaTime;

        // Check if object is grounded
        groundCheckDistance = (GetComponent<CapsuleCollider>().height / 2) + bufferCheckDistance;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            if (verticalVelocity < 0) // This ensures that we only reset vertical velocity on a downward trajectory
            {
                verticalVelocity = 0; // Reset vertical velocity to prevent accumulation
            }
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Jumping logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Apply initial jump velocity
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
        }

        // Apply vertical movement
        transform.Translate(new Vector3(0, verticalVelocity, 0) * Time.deltaTime, Space.World);
        
        verticalSpeedText.text = "Vertical Speed: " + Math.Abs(verticalVelocity).ToString("F2");
        /// WASD
        // Move the player left/right and forward/backward using WASD and arrow
        // keys
        
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _forwardInput);

        // Get the camera's forward and right vectors, ignoring the Y component to stay on the horizontal plane
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        
        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();

        // Combine the forward and right vectors based on the input to get the desired movement direction
        Vector3 targetDirection = (forward * _forwardInput + right * _horizontalInput).normalized;

        Vector3 targetVelocity = targetDirection * _movementSpeed;

        horizontalVelocity = Vector3.MoveTowards(horizontalVelocity, targetVelocity, horizontalAcceleration * Time.deltaTime);

        // Move the player in the calculated direction
        transform.Translate(horizontalVelocity * _movementSpeed * Time.deltaTime, Space.World);

        // Calculate the horizontal speed as the magnitude of the horizontalVelocity vector
        float horizontalSpeed = horizontalVelocity.magnitude;

        horizontalSpeedText.text = "Horizontal Speed: " + horizontalSpeed.ToString("F2");
  
    }
}
