using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetScoring : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

        private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Target") 
        {
            score += 50;
            scoreText.text = "Score: " + score.ToString("F0");
            Destroy(other.gameObject);
        }
    }
}
