using UnityEngine;
using TMPro;

namespace Player
{
    /// <summary>
    /// Script to control the glider plane
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// The maximium thrust of the engine. This is the force applied to the
        /// glider when at 100% throttle. 
        /// 
        /// Thrust is quantitatively equal to force and is measured in Newtons.
        /// 
        /// <see cref="https://en.wikipedia.org/wiki/Thrust"/>
        /// </summary>
        [Tooltip("Maximum engine thrust when at 100% throttle")]
        public float maxThrust = 200.0f;

        /// <summary>
        /// How much throttle goes up or down
        /// </summary>
        [Header("Plane Stats")]
        [Tooltip("How much the throttle rampus up or down")]
        public float throttleIncrement = 1.0f;

        /// <summary>
        /// Determines the responsiveness of the glider to the player's input.
        /// 
        /// A higher responsiveness value means the glider will respond more and
        /// be more "twitchy" so to speak.
        /// </summary>
        [Tooltip("Responsiveness")]
        public float responsiveness = 80.0f;

        /// <summary>
        /// A calculated value that determines how much the glider responds to
        /// the player's input based on the mass of the object and the
        /// responsiveness.
        /// </summary>
        private float ResponseModifier
        {
            get
            {
                return rb.mass * responsiveness / 10.0f;
            }
        }

        /// <summary>
        /// The lift force that glider experiences as the 
        /// </summary>
        [Tooltip("How much lift force this glider generates as it gains speed")]
        public float lift = 135.0f;

        /// <summary>
        /// Internally track the current throttle of the glider
        /// </summary>
        private float throttle;

        /// Track the 3 different planes of rotation
        /// 
        /// Assume that z-axis is forward, x-axis is right, and y-axis is up

        /// <summary>
        /// The roll of the glider. This is the rotation around the z-axis.
        /// </summary>
        private float roll;

        /// <summary>
        /// The pitch of the glider. This is the rotation around the x-axis.
        /// </summary>
        private float pitch;

        /// <summary>
        /// The yaw of the glider. This is the rotation around the y-axis.
        /// </summary>
        private float yaw;

        Rigidbody rb;
        public TextMeshProUGUI statsHud;
        public TextMeshProUGUI currentSettings;

        /// <summary>
        /// Track the debug mode for the glider
        /// </summary>
        private bool Debug = false;

        // Called when the script object is initialised, regardless of whether
        // or not the script is enabled.
        private void Awake()
        {

            rb = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Update the glider's physics and HUD
        /// </summary>
        private void Update()
        {
            HandleInputs();
        }

        /// <summary>
        /// Fixed update to handle physics (avoids weird things in physics)
        /// </summary>
        private void FixedUpdate()
        {
            // Apply forces to our glider
            rb.AddForce(transform.forward * maxThrust * throttle);

            // Adds rotational force to glider
            rb.AddTorque(transform.up * yaw * ResponseModifier);
            rb.AddTorque(transform.right * pitch * ResponseModifier);
            rb.AddTorque(-transform.forward * roll * ResponseModifier);

            // Get off ground! just press space
            rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);
        }

        private void OnGUI()
        {
            UpdateStatsHud();
        }

        /// <summary>
        /// Handle the player's inputs for the glider for thrust and rotation
        /// </summary>
        private void HandleInputs()
        {
            /// 
            roll = Input.GetAxis("Roll");
            pitch = Input.GetAxis("Pitch");
            yaw = Input.GetAxis("Yaw");

            // Handle throttle value being sure to clamp between 0 and 100.
            if (Input.GetKey(KeyCode.Space))
            {
                throttle += throttleIncrement;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                throttle -= throttleIncrement;
            }

            // Toggle the debug mode if the Shift+D is pressed
            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
            {
                Debug = !Debug;
            }

            throttle = Mathf.Clamp(throttle, 0f, 100f);
        }

        /// <summary>
        /// Update the HUD with the current throttle, airspeed, and altitude
        /// </summary>
        private void UpdateStatsHud()
        {
            statsHud.text = $@"Throttle: {throttle:F0}%
Airspeed: {rb.velocity.magnitude * 3.6f:F0} km/h
Altitude: {transform.position.y:F0} m";

            currentSettings.text = Debug
            ? $@"Resolution {Screen.currentResolution.width}x{Screen.currentResolution.height}
Quality: {QualitySettings.GetQualityLevel()} [{QualitySettings.names[QualitySettings.GetQualityLevel()]}]
VSync: {QualitySettings.vSyncCount}
Fullscreen: {Screen.fullScreen}"
            : "";
        }
    }
}