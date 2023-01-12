using UnityEngine;
using UnityEngine.Events;

public class ModelView : MonoBehaviour
{
    public enum view { shaded, xRay, transparent};
    public view modelView = view.shaded;
    [SerializeField] Material xRayMaterial;
    [SerializeField] Material transparentMaterial;

    [SerializeField] Material currentMaterial;
    PartManager partManager;

    private void Start()
    {
        partManager = GetComponent<PartManager>();
        FindCurrentMaterial();
    }

    private void FindCurrentMaterial()
    {
        MeshRenderer meshRenderer = partManager.parts[0].GetComponent<MeshRenderer>();
        currentMaterial = meshRenderer.material;
    }

    private void SetMaterial(Material newMaterial)
    {
        if (newMaterial == currentMaterial) return;
        currentMaterial = newMaterial;
        foreach(Part part in partManager.parts)
        {
            part.ChangeMaterial(newMaterial);
        }
    }

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
    }

    public void ChangeToTransparentView()
    {
        SetMaterial(transparentMaterial);
    }

    public void ChangeToShadedView()
    {
        SetMaterial();
    }
}
