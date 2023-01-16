using UnityEngine;

/// <summary>
/// Changes the material on all the model parts depending on the current view.
/// </summary>
public class ModelView : MonoBehaviour
{
    // Transparent Shader
    // from: https://gamedev.stackexchange.com/questions/158128/how-to-write-a-transparent-shader-for-a-sprite-that-ignores-transparent-sprites

    public enum View { shaded, xRay, transparent};
    public View modelView = View.shaded;

    [SerializeField] Material xRayMaterial;
    [SerializeField] Material transparentMaterial;

    [SerializeField] Material currentMaterial;
    PartManager partManager;

    private void Awake()
    {
        partManager = GetComponent<PartManager>();
    }

    private void Start()
    {
        FindCurrentMaterial();
        modelView = View.shaded;
    }

    private void FindCurrentMaterial()
    {
        MeshRenderer meshRenderer = partManager.parts[0].GetComponent<MeshRenderer>();
        currentMaterial = meshRenderer.material;
    }

    /// <summary>
    /// Change material to a new one.
    /// </summary>
    /// <param name="newMaterial"></param>
    private void SetMaterial(Material newMaterial)
    {
        if (newMaterial == currentMaterial) return;
        currentMaterial = newMaterial;
        foreach(Part part in partManager.parts)
        {
            part.ChangeMaterial(newMaterial);
        }
    }

    /// <summary>
    /// This function is used to change back to the main material's model.
    /// </summary>
    private void SetMaterial()
    {
        currentMaterial = partManager.parts[0].MainMaterial;
        foreach (Part part in partManager.parts)
        {
            part.ChangeMaterial(part.MainMaterial);
        }
    }

    public void ChangeToXRayView()
    {
        SetMaterial(xRayMaterial);
        modelView = View.xRay;
    }

    public void ChangeToTransparentView()
    {
        SetMaterial(transparentMaterial);
        modelView = View.transparent;
    }

    public void ChangeToShadedView()
    {
        SetMaterial();
        modelView = View.shaded;
    }
}
