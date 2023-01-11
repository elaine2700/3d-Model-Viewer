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

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor(colorSettings.defaultColor);
    }

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
        meshRenderer.material.color = newColor;
    }

    public void SetColorSettings(ColorSettings colorTheme)
    {
        colorSettings = colorTheme;
    }
}
