using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System.Globalization;

namespace Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        public GameObject settingsPanel;

        // TODO: actually make the sliders change the volume
        /// <summary>
        /// A slider for the volume
        /// </summary>
        public Slider volumeSlider;

        /// <summary>
        /// The text representation of the volume slider
        /// </summary>
        public TextMeshProUGUI volumeSliderText;

        /// <summary>
        /// A dropdown for the resolution options
        /// </summary>
        public TMP_Dropdown resolutionDropdown;

        /// <summary>
        /// A dropdown for the quality options
        /// </summary>
        public TMP_Dropdown qualityDropdown;

        /// <summary>
        /// A toggle for fullscreen mode
        /// </summary>
        public Toggle fullscreenToggle;

        /// <summary>
        /// Track the fullscreen mode based on the toggle
        /// </summary>
        public FullScreenMode FullScreenMode
        {
            get
            {
                return fullscreenToggle.isOn
                    ? FullScreenMode.FullScreenWindow
                    : FullScreenMode.Windowed;
            }
        }

        /// <summary>
        /// A toggle for vsync
        /// </summary>
        public Toggle vsyncToggle;

        public int VSync
        {
            get
            {
                return vsyncToggle.isOn
                    ? 1
                    : 0;
            }
        }

        public void Start()
        {
            UpdateVolume(SettingsMenuOptions.Instance.CurrentVolume);
            UpdateResolution();
            UpdateQuality();

            ApplyChanges();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                settingsPanel.SetActive(false);
            }
        }

        /// <summary>
        /// Set the current volume to the slider's value
        /// </summary>
        /// <param name="value"></param>
        private void UpdateVolume(float value)
        {
            volumeSliderText.text = value.ToString(CultureInfo.CurrentCulture);
            // Update the global volume as well as the slider's value
            SettingsMenuOptions.Instance.CurrentVolume = volumeSlider.value = value;
        }

        /// <summary>
        /// Fill in the resolution dropdowns with the available resolutions
        /// </summary>
        private void UpdateResolution()
        {
            // Clear the resolution dropdown options
            resolutionDropdown.ClearOptions();

            // Get the resolution options from the settings option singleton
            // instance, but map the resolutions to a string representation for
            // the dropdown representation
            resolutionDropdown.AddOptions(SettingsMenuOptions.Instance.Resolutions
                .Select(resolution =>
                    $"{resolution.width}x{resolution.height}@{resolution.refreshRateRatio.value:0.00}Hz"
                )
                .ToList()
            );

            // Set the current resolution index to the selected index
            resolutionDropdown.value = SettingsMenuOptions.Instance.SelectedResolutionIndex;

            // Make sure to refresh the dropdown to show the new options
            resolutionDropdown.RefreshShownValue();
        }

        /// <summary>
        /// Fill in the quality dropdown with the available quality levels
        /// </summary>
        private void UpdateQuality()
        {
            // Clear the quality dropdown options
            qualityDropdown.ClearOptions();

            // Get the quality options from the settings option singleton instance
            qualityDropdown.AddOptions(
                Enumerable.Reverse(SettingsMenuOptions.Instance.QualityLevels)
                .ToList()
            );

            // Set the current quality index to the selected index
            qualityDropdown.value = SettingsMenuOptions.Instance.SelectedQualityIndex;

            // Make sure to refresh the dropdown to show the new options
            qualityDropdown.RefreshShownValue();
        }

        /// <summary>
        /// Set the resolution index when the dropdown's value changes
        /// </summary>
        /// <param name="resolutionIndex"></param>
        public void ChangeResolution(int resolutionIndex)
        {
            SettingsMenuOptions.Instance.SelectedResolutionIndex = resolutionIndex;
        }

        /// <summary>
        /// Set the quality index when the dropdown's value changes
        /// </summary>
        /// <param name="qualityIndex"></param>
        public void ChangeQuality(int qualityIndex)
        {
            SettingsMenuOptions.Instance.SelectedQualityIndex = qualityIndex;
        }

        /// <summary>
        /// Apply the changes to the settings when the apply button is pressed
        /// </summary>
        public void ApplyChanges()
        {
            // Set the quality level
            QualitySettings.SetQualityLevel(SettingsMenuOptions.Instance.SelectedQualityIndex);

            // Get the resolution from the settings options
            Resolution resolution = SettingsMenuOptions.Instance.Resolutions[
                SettingsMenuOptions.Instance.SelectedResolutionIndex
            ];

            // Set the resolution and framerate
            Screen.SetResolution(
                resolution.width,
                resolution.height,
                FullScreenMode,
                resolution.refreshRateRatio
            );

            // Update the vsync settings
            QualitySettings.vSyncCount = VSync;
        }
    }
}
