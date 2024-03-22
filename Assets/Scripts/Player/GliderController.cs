using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Specialized;

public class GliderController : MonoBehaviour
{
    [Header("Plane Stats")]
    [Tooltip("How much the throttle rampus up or down")]
    public float throttleIncrement = 0.1f; //how much throttle goes up or down

    [Tooltip("Maximum engine thrust when at 100% throttle")]
    public float maxThrust = 200f;

    [Tooltip("Responsiveness")] 
    public float responsiveness = 10f; //how twitchy the glider is

    [Tooltip("How much lift force this glider generates as it gains speed")]
    public float lift = 135f;

    private float throttle;

    //3 different planes of rotation
    private float roll;
    private float pitch;
    private float yaw;

    private float responseModifier {
        get {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    Rigidbody rb;
    [SerializeField] TextMeshProUGUI hud;

    // called when the script object is initialised, regardless of whether or not the script is enabled.
    private void Awake() {

        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs() {
        //set rotational values from our axis inputs

        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        //handle throttle value being sure to clamp between 0 and 100.
        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;

        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    private void Update() {
        HandleInputs();
        UpdateHUD();
    }

    //fixed update to handle physics (avoids weird things in physics)
    private void FixedUpdate() {

        //Apply forces to our glider
        rb.AddForce(transform.forward * maxThrust * throttle);

        //adds rotational force to glider
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);

        //get off ground! just press space
        rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);

    }

    private void UpdateHUD() {

        hud.text = "Throttle: " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + " km/h \n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + " m";
    }
}
