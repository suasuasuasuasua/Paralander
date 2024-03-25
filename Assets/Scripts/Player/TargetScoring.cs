using UnityEngine;
using TMPro;

namespace Player
{
    public class TargetScoring : MonoBehaviour
    {
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
                score += targetValue;
                scoreText.text = $"Score: {score:F0}";

                Destroy(other.gameObject);
            }
        }
    }
}
