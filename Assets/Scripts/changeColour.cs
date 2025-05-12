using UnityEngine;

public class changeColour : MonoBehaviour
{
    public Transform button; 
    public Color normalColor = Color.white;  // The normal color of the button
    public Color neonColor = Color.cyan;  // The neon color to apply
    public float neonIntensity = 2f;  // Intensity of the glow (you can adjust this for more/less glow)

    private Material buttonMaterial;
    private bool isNeon = false;

    void Start()
    {
        if (button == null)
            button = GetComponent<Button>();

        // Make sure you have a button component attached to this GameObject
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }

        // Get the material of the button (assuming button is using an Image or MeshRenderer)
        buttonMaterial = button.GetComponent<MeshRenderer>().material; // Change to MeshRenderer if necessary

        // Set initial button color
        buttonMaterial.color = normalColor;
        SetNeonEffect(false);
    }

    // Called when the button is pressed
    void OnButtonClick()
    {
        if (isNeon)
        {
            // If it's already glowing, reset to normal color
            buttonMaterial.color = normalColor;
            SetNeonEffect(false);
        }
        else
        {
            // Apply the neon glow effect
            buttonMaterial.color = neonColor;
            SetNeonEffect(true);
        }

        // Toggle the state for next press
        isNeon = !isNeon;
    }

    // Set the emission properties for the neon glow effect
    void SetNeonEffect(bool enable)
    {
        if (enable)
        {
            buttonMaterial.SetColor("_EmissionColor", neonColor * neonIntensity);
            buttonMaterial.EnableKeyword("_EMISSION");
        }
        else
        {
            buttonMaterial.SetColor("_EmissionColor", Color.black);
            buttonMaterial.DisableKeyword("_EMISSION");
        }
    }
}
