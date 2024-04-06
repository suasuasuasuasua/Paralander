using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public float fps;
    public const float updateTimer = 0.2f;
    public float counter = updateTimer;

    [SerializeField] TextMeshProUGUI fpsTitle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter -= Time.deltaTime;
        if (counter <= 0.0f)
        {
            fps = 1.0f / Time.unscaledDeltaTime;
            fpsTitle.text = $"FPS: {Mathf.Round(fps)}";
            counter = updateTimer;
        }
    }
}
