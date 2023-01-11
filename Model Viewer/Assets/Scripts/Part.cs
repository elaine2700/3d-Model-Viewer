using UnityEngine;
using UnityEngine.Events;

public class Part : MonoBehaviour
{
    public UnityEvent exitHover;
    public UnityEvent enterHover;
    public UnityEvent enterSelection;
    public UnityEvent exitSelection;

    ColorSettings colorSettings;
    MeshRenderer meshRenderer;
    bool isSelection = false;
    Material mainMaterial;
    float colorOpacity = 1f;
    public Material MainMaterial { get { return mainMaterial; } }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor(colorSettings.defaultColor);
        mainMaterial = meshRenderer.material;
    }

    // todo dont allow if moving a part.
    public void EnterHover()
    {
        if (isSelection) return;
        ChangeColor(colorSettings.hoverColor);
    }

    public void ExitHover()
    {
        if (isSelection) return;
        ChangeColor(colorSettings.defaultColor);
    }

    public void EnterSelection()
    {
        isSelection = true;
        ChangeColor(colorSettings.selectedColor);
    }

    public void ExitSelection()
    {
        ChangeColor(colorSettings.defaultColor);
        isSelection = false;
    }

    private void ChangeColor(Color newColor)
    {
        newColor.a = meshRenderer.material.color.a;
        meshRenderer.material.color = newColor;
        
    }

    public void ChangeMaterial(Material newMaterial)
    {
        if (newMaterial == meshRenderer.material) return; 
        meshRenderer.material = newMaterial;
    }

    public void SetColorSettings(ColorSettings colorTheme)
    {
        colorSettings = colorTheme;
    }
}
