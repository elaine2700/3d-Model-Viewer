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

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor(colorSettings.defaultColor);
    }

    public void EnterHover()
    {
        ChangeColor(colorSettings.hoverColor);
    }

    public void ExitHover()
    {
        ChangeColor(colorSettings.defaultColor);
    }

    public void EnterSelection()
    {
        ChangeColor(colorSettings.selectedColor);
    }

    public void ExitSelection()
    {
        ChangeColor(colorSettings.defaultColor);
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
