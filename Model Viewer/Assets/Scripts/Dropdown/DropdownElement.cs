using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownElement : MonoBehaviour
{
    public Transform refObject;
    [SerializeField] TextMeshProUGUI nameField;

    public void ConfigureLabel(string name, Transform transformRef, bool display)
    {
        SetName(name);
        DisplayElement(display);
        // Set Name
        // Set color depending on level
        // Set refObject
    }

    private void SetName(string labelName)
    {
        nameField.text = labelName;
    }

    public void DisplayElement(bool show)
    {
        gameObject.SetActive(show);
    }

}
