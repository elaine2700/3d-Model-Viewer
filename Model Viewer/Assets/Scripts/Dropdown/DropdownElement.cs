using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownElement : MonoBehaviour
{
    public Transform refObject;
    [SerializeField] TextMeshProUGUI nameField;

    Button elementButton;

    private void Awake()
    {
        elementButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        elementButton.onClick.AddListener(SelectObject);
    }

    private void OnDisable()
    {
        elementButton.onClick.RemoveAllListeners();
    }
    // Change selected object when this button is clicked.

    private void SelectObject()
    {
        Debug.Log($"Selecting: {refObject.name}");
    }

    private void SetName(string labelName)
    {
        nameField.text = labelName;
    }

    public void ConfigureLabel(string name, Transform transformRef, bool display)
    {
        SetName(name);
        DisplayElement(display);
        refObject = transformRef;
    }

    public void DisplayElement(bool show)
    {
        gameObject.SetActive(show);
    }

    public void AddToSection(DropdownSection parentSection)
    {
        parentSection.AddElementToList(this);
    }
}
