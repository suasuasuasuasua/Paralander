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

        public float magnetStrength = 300f;
        public float magnetRange = 100f;

        private void Update()
        {
            AttractTargets();
        }

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

        private void AttractTargets()
        {
            // Detect all colliders within the magnet range
            Collider[] targets = Physics.OverlapSphere(transform.position, magnetRange);
            // Iterate over each collider
            foreach (Collider target in targets)
            {
                if (target.tag == "Target")  // Check if it has the "Target" tag
                {
                    Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();

                    // Calculate force direction from target to magnet
                    Vector3 forceDirection = transform.position - target.transform.position;

                    // Apply force to the target's Rigidbody
                    targetRigidbody.AddForce(forceDirection.normalized * magnetStrength * Time.deltaTime);
                
                }
            }
        }


        private void OnGUI()
        {
            scoreText.text = $"Score: {score:F0}";
        }
    }
}
