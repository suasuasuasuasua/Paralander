using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Enforce a singleton pattern with the game manager
        /// </summary>
        public static GameManager Instance { get; private set; }

        public bool IsGamePaused { get; private set; } = false;

        /// <summary>
        /// Track the debug mode for the game
        /// </summary>
        public bool DebugMode { get; private set; } = false;
        public TextMeshProUGUI currentSettings;

        /// <summary>
        /// Track the input actions for the glider using Unity's new input system
        /// https://docs.unity3d.com/Packages/com.unity.inputsystem@1.8/manual/index.html
        /// </summary>
        [SerializeField]
        private InputActionReference debugInput;

        void Awake()
        {
            // Ensure that there is only one instance of the game manager
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(this);
        }

        void OnEnable()
        {
            debugInput.action.Enable();
        }

        void OnDisable()
        {
            debugInput.action.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            debugInput.action.performed += ctx => DebugMode = !DebugMode;
        }

        void OnGUI()
        {
            currentSettings.text = DebugMode
                ? $@"Resolution {Screen.currentResolution.width}x{Screen.currentResolution.height}
    Quality: {QualitySettings.GetQualityLevel()} [{QualitySettings.names[QualitySettings.GetQualityLevel()]}]
    VSync: {QualitySettings.vSyncCount}
    Fullscreen: {Screen.fullScreen}"
                : "";
        }
    }
}