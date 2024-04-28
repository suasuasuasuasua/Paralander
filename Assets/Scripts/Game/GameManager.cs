using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public GameObject pauseHUDPanel, settingsMenuPanel;
        public TextMeshProUGUI currentSettings;

        /// <summary>
        /// Track the actions for the game using Unity's new input system
        /// 
        /// https://docs.unity3d.com/Packages/com.unity.inputsystem@1.8/manual/index.html
        /// </summary>
        [SerializeField]
        private InputActionReference debugInput, pauseInput;

        /// <summary>
        /// Track if the game is paused
        /// </summary>
        public bool IsGamePaused { get; set; } = false;

        /// <summary>
        /// Track the debug mode for the game
        /// </summary>
        public bool DebugMode { get; private set; } = false;

        /// <summary>
        /// Make the cursor visible on start
        /// </summary>
        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;
        }

        void OnEnable()
        {
            debugInput.action.Enable();
            pauseInput.action.Enable();
        }

        void OnDisable()
        {
            debugInput.action.Disable();
            pauseInput.action.Disable();
        }

        // Update is called once per frame
        void Update()
        {
            // Toggle debug mode when Shift+D is pressed
            debugInput.action.performed += _ => ToggleDebugMode();

            // Toggle pause when Escape is pressed
            pauseInput.action.performed += _ => TogglePause();
        }


        public void ToggleDebugMode()
        {
            DebugMode = !DebugMode;
        }

        public void TogglePause()
        {
            IsGamePaused = !IsGamePaused;
            Cursor.visible = IsGamePaused;
            Cursor.lockState = IsGamePaused
                ? CursorLockMode.None
                : CursorLockMode.Locked;

            TogglePauseInput();

            // Show the pause HUD when the game is paused and freeze the
            // game
            pauseHUDPanel.SetActive(IsGamePaused);
            Time.timeScale = IsGamePaused ? 0 : 1;
        }

        public void TogglePauseInput()
        {
            if (settingsMenuPanel.activeInHierarchy)
            {
                pauseInput.action.Disable();
            }
            else
            {
                pauseInput.action.Enable();
            }
        }

        private void OnGUI()
        {
            currentSettings.text = DebugMode
                ? $@"Resolution {Screen.currentResolution.width}x{Screen.currentResolution.height}
Quality: {QualitySettings.names[QualitySettings.GetQualityLevel()]} [{QualitySettings.GetQualityLevel()}]
VSync: {QualitySettings.vSyncCount}
Fullscreen: {Screen.fullScreen}"
                : "";
        }
    }
}