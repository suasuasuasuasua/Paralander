using UnityEngine;
using TMPro;

namespace Player
{
    public class TargetScoring : MonoBehaviour
    {
        public AudioClip clip;
        /// <summary>
        /// Track the player's score
        /// </summary>
        private int score = 0;

        /// <summary>
        /// The amount of points that the target is worth
        /// </summary>
        private const int targetValue = 50;
        public TextMeshProUGUI scoreText;

        /// <summary>
        /// If the player collides with a target, then the player gets 50 points
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Target")
            {
                SoundFXManager.instance.PlaySoundFXClip(clip, transform, 1.0f);
                score += targetValue;
                Destroy(other.gameObject);
            }
        }

        private void OnGUI()
        {
            scoreText.text = $"Score: {score:F0}";
        }
    }
}
