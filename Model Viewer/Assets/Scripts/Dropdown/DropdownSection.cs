using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A Dropdown section is every element on the sidebar with
/// a level 1 (starts at 0) on the TreeList structure.
/// </summary>
public class DropdownSection : MonoBehaviour
{
    [SerializeField] Sprite closedSprite;
    [SerializeField] Sprite openSprite;
    [SerializeField] Image arrowField;

    [SerializeField] List<DropdownElement> sectionElements;

    Select selectScript;
    Button sectionButton;
    bool opened = false;

    private void Awake()
    {
        sectionButton = GetComponent<Button>();
        selectScript = FindObjectOfType<Select>();
    }

    private void OnEnable()
    {
        sectionButton.onClick.AddListener(() => DisplaySectionElements(!opened));
        selectScript.changedSelection.AddListener(CheckSelectionInChildren);
    }

    private void OnDisable()
    {
        sectionButton.onClick.RemoveAllListeners();
        selectScript.changedSelection.RemoveAllListeners();
    }

    public void AddElementToList(DropdownElement dropdownElement)
    {
        sectionElements.Add(dropdownElement);
    }

    private void DisplaySectionElements(bool show)
    {
        if (opened == show) return;
        opened = show;

        // Changing Sprite 
        if (opened)
            arrowField.sprite = openSprite;
        else
            arrowField.sprite = closedSprite;

        if (sectionElements.Count == 0) return;
        foreach(DropdownElement element in sectionElements)
        {
            element.DisplayElement(show);
        }
        // with vertical layout group,
        // the heights update automatically after enabling
        // or disabling game objects.
    }

    private void CheckSelectionInChildren(Part currentSelection)
    {
        foreach(DropdownElement element in sectionElements)
        {
            if (element.TransformIsSelection(currentSelection))
            {
                DisplaySectionElements(true);
            }   
        }
    }

}
