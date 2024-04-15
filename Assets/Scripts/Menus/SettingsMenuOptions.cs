using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Menus
{
    public class SettingsMenuOptions : MonoBehaviour
    {
        public static SettingsMenuOptions Instance { get; private set; }

        /// <summary>
        /// The resolutions that the player's monitor supports
        /// </summary>
        public List<Resolution> Resolutions { get; private set; }

        /// <summary>
        /// The current resolution index
        /// </summary>
        public int SelectedResolutionIndex { get; set; }

        /// <summary>
        /// The quality levels for the game as strings
        /// </summary>
        public List<string> QualityLevels;

        /// <summary>
        /// The current quality level index
        /// </summary>
        public int SelectedQualityIndex { get; set; }

        public AudioSource AudioSource { get; private set; }

        /// <summary>
        /// The current volume of the game
        /// </summary>
        public float CurrentVolume { get; set; }

        /// <summary>
        /// Enforce a singleton pattern with the settings menu
        /// <see cref="https://learn.unity.com/tutorial/implement-data-persistence-between-scenes#634f8281edbc2a65c86270cb"/>
        /// </summary>
        private void Awake()
        {
            // Ensure that there is only one instance of the settings menu
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            SetupResolutions();
            SetupQualityLevels();
            SetupVolume();

            // Don't destroy the settings object across scenes to maintain the
            // settings
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Setup all the resolutions elements for the game
        /// </summary>
        private void SetupResolutions()
        {
            // Get all the available resolutions for the game
            // Need to keep the original array
            Resolutions = Screen.resolutions
                .Reverse()
                .ToList()
            ;

            // Get the current resolution index (this will be the default
            // resolution until the user changes it)
            SelectedResolutionIndex = Resolutions.IndexOf(
                Screen.currentResolution
            );
        }

        /// <summary>
        /// Setup the quality levels for the game
        /// </summary>
        private void SetupQualityLevels()
        {
            QualityLevels = QualitySettings.names
                .ToList()
            ;
            SelectedQualityIndex = QualitySettings.GetQualityLevel();
        }

        /// <summary>
        /// Setup the volume aspects of the game
        /// </summary>
        private void SetupVolume()
        {
            // The default volume is maxed out
            // TODO: maybe we can figure out a way to persist the volume
            CurrentVolume = 100;

            // TODO: set the audio source
            // AudioSource = ...
        }
    }
}