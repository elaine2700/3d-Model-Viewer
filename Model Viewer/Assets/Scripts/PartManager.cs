using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    List<Part> parts = new List<Part>();
    [SerializeField] ColorSettings colorSettings;

    private void Start()
    {
        Part[] partsList = GetComponentsInChildren<Part>();
        foreach(Part part in partsList)
        {
            parts.Add(part);
            part.SetColorSettings(colorSettings);
        }
    }
}
