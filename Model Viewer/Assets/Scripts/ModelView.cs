using UnityEngine;

public class ModelView : MonoBehaviour
{
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

    private void SetNewMaterial(Material newMaterial)
    {
        if (newMaterial == currentMaterial) return;
        currentMaterial = newMaterial;
        foreach(Part part in partManager.parts)
        {
            part.ChangeMaterial(newMaterial);
        }
    }

    private void SetNewMaterial()
    {
        currentMaterial = partManager.parts[0].MainMaterial;
        foreach (Part part in partManager.parts)
        {
            part.ChangeMaterial(part.MainMaterial);
        }
    }

    public void ChangeToXRayView()
    {
        SetNewMaterial(xRayMaterial);
    }

    public void ChangeToTransparentView()
    {
        SetNewMaterial(transparentMaterial);
    }

    public void ChangeToShadedView()
    {
        SetNewMaterial();
    }
}
