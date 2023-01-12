using UnityEngine;
using UnityEngine.Events;

public class Part : MonoBehaviour
{
    public UnityEvent exitHover;
    public UnityEvent enterHover;
    public UnityEvent enterSelection;
    public UnityEvent exitSelection;

    ModelView modelview;
    ColorSettings colorSettings;
    MeshRenderer meshRenderer;
    bool isSelection = false;
    Material mainMaterial;
    public Material MainMaterial { get { return mainMaterial; } }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor(colorSettings.defaultColor);
        mainMaterial = meshRenderer.material;
        modelview = FindObjectOfType<ModelView>();
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
        //if(meshRenderer.material == )
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
