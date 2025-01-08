using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class PanelColorBreathing : MonoBehaviour
{
    public Image panel; // Reference to the panel whose color will be randomized
    public float breathingSpeed = 1.0f; // Speed of the breathing effect

    private Color targetColor;
    private Color initialColor;
    private float breathingFactor;

    void Start()
    {
        // Initialize the panel color
        if (panel != null)
        {
            initialColor = panel.color;
            targetColor = GetRandomColor();
        }
    }

    void Update()
    {
        // Breathing effect
        if (panel != null)
        {
            breathingFactor = Mathf.PingPong(Time.time * breathingSpeed, 1.0f);
            panel.color = Color.Lerp(initialColor, targetColor, breathingFactor);

            // Randomize color when fully transitioned
            if (breathingFactor >= 0.99f)
            {
                initialColor = targetColor;
                targetColor = GetRandomColor();
            }
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
