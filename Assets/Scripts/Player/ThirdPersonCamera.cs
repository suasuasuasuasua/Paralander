using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    /// <summary>
    /// Make the cursor invisible
    /// </summary>
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
