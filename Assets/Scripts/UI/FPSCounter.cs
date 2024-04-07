using TMPro;
using UnityEngine;
using System;

namespace UI
{
    /// <summary>
    /// An FPS counter
    ///
    /// <see cref="https://github.com/MirzaBeig/FPS-Display"/>
    /// </summary>
    [ExecuteAlways]
    public class FPSCounter : MonoBehaviour
    {
        /// <summary>
        /// Frmames per second (interval average)
        /// </summary>
        public float Fps { get; private set; }
        /// <summary>
        /// Milliseconds per frame (interval average)
        /// </summary>
        public float FrameMS { get; private set; }

        GUIStyle style = new();

        public int size = 16;

        public Vector2 position = new(16.0f, 16.0f);

        public enum Alignment { Left, Right }
        public Alignment alignment = Alignment.Left;

        public Color colour = Color.green;

        public float updateInterval = 0.5f;

        float elapsedIntervalTime;
        int intervalFrameCount;

        [Tooltip("Optional. Will render using GUI if not assigned.")]
        public TextMeshProUGUI textMesh;

        /// <summary>
        /// Get average FPS and frame delta (ms) for current interval (so far, if called early).
        /// </summary>
        /// <returns></returns>
        public float GetIntervalFPS()
        {
            // 1 / time.unscaledDeltaTime for same-frame results.
            // Same as above, but uses accumulated frameCount and deltaTime.

            return intervalFrameCount / elapsedIntervalTime;
        }
        
        /// <summary>
        /// Get average frame delta (ms) for current interval (so far, if called early).
        /// </summary>
        /// <returns></returns>
        public float GetIntervalFrameMS()
        {
            // Calculate average frame delta during interval (time / frames).
            // Same as Time.unscaledDeltaTime * 1000.0f, using accumulation.

            return elapsedIntervalTime * 1000.0f / intervalFrameCount;
        }

        void Update()
        {
            intervalFrameCount++;
            elapsedIntervalTime += Time.unscaledDeltaTime;

            if (elapsedIntervalTime >= updateInterval)
            {
                Fps = GetIntervalFPS();
                FrameMS = GetIntervalFrameMS();

                Fps = (float)Math.Round(Fps, 2);
                FrameMS = (float)Math.Round(FrameMS, 2);

                intervalFrameCount = 0;
                elapsedIntervalTime = 0.0f;
            }

            if (textMesh)
            {
                textMesh.text = GetFPSText();
            }
            else
            {
                style.fontSize = size;
                style.fontStyle = FontStyle.Bold;
                style.normal.textColor = colour;
            }
        }

        string GetFPSText()
        {
            return $"FPS: {Fps:.00} ({FrameMS:.00} ms)";
        }

        void OnGUI()
        {
            string fpsText = GetFPSText();

            if (!textMesh)
            {
                float x = position.x;

                if (alignment == Alignment.Right)
                {
                    x = Screen.width - x - style.CalcSize(new GUIContent(fpsText)).x;
                }

                GUI.Label(new Rect(x, position.y, 200, 100), fpsText, style);
            }
        }
    }
}