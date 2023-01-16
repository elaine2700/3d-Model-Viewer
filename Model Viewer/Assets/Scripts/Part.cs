using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] string partName;
    public string PartName { get { return partName; } }

    ModelView view;
    ColorSettings colorSettings;
    MeshRenderer meshRenderer;
    bool isSelection = false;
    Material mainMaterial;
    public Material MainMaterial { get { return mainMaterial; } }

    private void Awake()
    {
        view = FindObjectOfType<ModelView>();
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeColor(colorSettings.defaultColor);
        mainMaterial = meshRenderer.material;

        partName = transform.name;
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
        switch (view.modelView)
        {
            case ModelView.View.transparent:
                newColor.a = meshRenderer.material.GetColor("_Color").a;
                meshRenderer.material.SetColor("_Color", newColor);
                break;
            default:
                newColor.a = meshRenderer.material.color.a;
                meshRenderer.material.color = newColor;
                break;
        }
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
