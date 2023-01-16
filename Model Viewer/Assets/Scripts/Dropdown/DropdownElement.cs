using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class refers to every element on the side bar.
/// </summary>
public class DropdownElement : MonoBehaviour
{
    public Transform refObject;
    [SerializeField] TextMeshProUGUI nameField;
    [SerializeField] ColorSettings colorSettings;

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
            background.color = colorSettings.selectedColor;
            return true;
        }

        background.color = colorSettings.defaultColor;   
        return false;
    }

    // Change selected object when this button is clicked.
    private void SelectObject()
    {
        selectScript.canMove = false;
        Debug.Log($"Selecting: {refObject.name}");
        refObject.TryGetComponent<Part>(out Part partRef);
        if(partRef != null)
        {
            selectScript.SelectPart(partRef);
        }    
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
