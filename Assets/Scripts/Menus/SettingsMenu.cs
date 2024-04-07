using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

namespace Menus
{
    public class SettingsMenu : MonoBehaviour
    {
        /// <summary>
        /// Track the settings menu options singleton instance
        /// </summary>
        public SettingsMenuOptions settingsMenuOptions;

        /// <summary>
        /// A toggle for fullscreen mode
        /// </summary>
        public Toggle fullscreenToggle;

        /// <summary>
        /// A dropdown for the resolution options
        /// </summary>
        public TMP_Dropdown resolutionDropdown;

        /// <summary>
        /// A dropdown for the quality options
        /// </summary>
        public TMP_Dropdown qualityDropdown;

        private void Awake()
        {
            // Update the resolution and quality dropdowns
            UpdateResolution();
            UpdateQuality();

            settingsMenuOptions = SettingsMenuOptions.Instance;
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
            resolutionDropdown.AddOptions(settingsMenuOptions.Resolutions
                .Select(resolution =>
                    $"{resolution.width}x{resolution.height}@{resolution.refreshRateRatio.value:0.00}Hz"
                )
                .ToList()
            );

            // Set the current resolution index to the selected index
            resolutionDropdown.value = settingsMenuOptions.SelectedResolutionIndex;

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
            qualityDropdown.AddOptions(settingsMenuOptions.QualityLevels);

            // Set the current quality index to the selected index
            qualityDropdown.value = settingsMenuOptions.QualityIndex;

            // Make sure to refresh the dropdown to show the new options
            qualityDropdown.RefreshShownValue();
        }

        /// <summary>
        /// Set the resolution index when the dropdown's value changes
        /// </summary>
        /// <param name="resolutionIndex"></param>
        public void ChangeResolution(int resolutionIndex)
        {
            settingsMenuOptions.SelectedResolutionIndex = resolutionIndex;
        }

        /// <summary>
        /// Set the quality index when the dropdown's value changes
        /// </summary>
        /// <param name="qualityIndex"></param>
        public void ChangeQuality(int qualityIndex)
        {
            settingsMenuOptions.QualityIndex = qualityIndex;
        }

        /// <summary>
        /// Apply the changes to the settings when the apply button is pressed
        /// </summary>
        public void ApplyChanges()
        {
            // Set the quality level
            QualitySettings.SetQualityLevel(settingsMenuOptions.QualityIndex);

            // Set the resolution and framerate
            Resolution resolution = settingsMenuOptions.Resolutions[
                settingsMenuOptions.SelectedResolutionIndex
            ];

            FullScreenMode fullScreenMode = fullscreenToggle.isOn
                ? FullScreenMode.FullScreenWindow
                : FullScreenMode.Windowed;

            Debug.Log(fullScreenMode);

            Screen.SetResolution(
                resolution.width,
                resolution.height,
                fullScreenMode,
                resolution.refreshRateRatio
            );
        }
    }
}
