using System;
using UnityEngine;

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
    private float _verticalInput;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Move the player left/right and forward/backward using WASD and arrow
        // keys
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical"); transform.Translate(
            Vector3.right * _horizontalInput * _movementSpeed * Time.deltaTime
        );
        transform.Translate(
            Vector3.forward * _forwardInput * _movementSpeed * Time.deltaTime
        );

        // If the user presses the space bar, the player will fly up
        _verticalInput = Convert.ToInt16(Input.GetKey(KeyCode.Space));
        transform.Translate(
            Vector3.up * _verticalInput * _flyingSpeed * Time.deltaTime
        );

        // Rotate the player left and right with the mouse
        transform.Rotate(
            Vector3.up * _turningSpeed * Time.deltaTime,
            Input.GetAxis("Mouse X")
        );
    }
}
