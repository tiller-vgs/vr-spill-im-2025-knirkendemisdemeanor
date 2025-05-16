using UnityEngine;

public class ChangeAccentButtonColor : MonoBehaviour
{
    public Renderer targetRenderer;
    public Color pressedColor = Color.green;
    public Color releasedColor = Color.red;

    private Material accentMaterial;

    void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("ChangeAccentButtonColor: No Renderer assigned!");
            return;
        }

        // Find the material named "AccentButton" in the renderer's materials
        foreach (var mat in targetRenderer.materials)
        {
            if (mat.name.StartsWith("AccentButton"))
            {
                accentMaterial = mat;
                break;
            }
        }

        if (accentMaterial == null)
        {
            Debug.LogError("ChangeAccentButtonColor: No material named 'AccentButton' found!");
            return;
        }

        // Set initial color
        accentMaterial.color = releasedColor;
    }

    public void SetPressedColor()
    {
        if (accentMaterial != null)
            accentMaterial.color = pressedColor;
    }

    public void SetReleasedColor()
    {
        if (accentMaterial != null)
            accentMaterial.color = releasedColor;
    }
}