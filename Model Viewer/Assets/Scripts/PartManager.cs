using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    public List<Part> parts = new List<Part>();
    [SerializeField] ColorSettings colorSettings;

    private void Awake()
    {
        Part[] partsList = GetComponentsInChildren<Part>();
        foreach(Part part in partsList)
        {
            parts.Add(part);
            part.SetColorSettings(colorSettings);
        }
    }
}
