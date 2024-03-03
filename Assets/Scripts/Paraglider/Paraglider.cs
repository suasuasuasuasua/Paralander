using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paraglider : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
// This function is called when another collider enters the trigger collider attached to this object
    private void OnTriggerEnter(Collider other)
    {
        print("hello trigger entered");

        // Check if the entering collider has a tag of "Player"
        if (other.CompareTag("Player"))
        {
            // Get the player script component from the entering collider's GameObject
            ThirdPersonController playerController = other.GetComponent<ThirdPersonController>();
            if (playerController != null)
            {
                // Call the StartParagliding method on the player controller
                print("start gliding");
                playerController.StartParagliding();
            }
        }
    }
}
