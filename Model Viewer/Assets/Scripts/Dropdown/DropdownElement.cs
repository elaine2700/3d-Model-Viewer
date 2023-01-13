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
    Select selectScript;
    Image background;

    private void Awake()
    {
        elementButton = GetComponent<Button>();
        selectScript = FindObjectOfType<Select>();
        background = GetComponent<Image>();
    }

    private void OnEnable()
    {
        elementButton.onClick.AddListener(SelectObject);
    }

    private void OnDisable()
    {
        elementButton.onClick.RemoveAllListeners();
    }

    public bool TransformIsSelection(Part currentSelection)
    {
        if (currentSelection.transform == refObject)
        {
            background.color = Color.cyan;
            return true;
        }
        background.color = Color.grey;   
        return false;
    }

    // Change selected object when this button is clicked.
    private void SelectObject()
    {
        Debug.Log($"Selecting: {refObject.name}");
        refObject.TryGetComponent<Part>(out Part partRef);
        if(partRef != null)
            selectScript.SelectPart(partRef);
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
