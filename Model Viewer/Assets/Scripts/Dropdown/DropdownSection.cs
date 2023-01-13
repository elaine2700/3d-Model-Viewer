using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSection : MonoBehaviour
{
    List<DropdownElement> sectionElements;

    Button sectionButton;
    bool opened = false;

    private void Awake()
    {
        sectionButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        sectionButton.onClick.AddListener(() => DisplaySectionElements(!opened));
    }

    private void OnDisable()
    {
        sectionButton.onClick.RemoveAllListeners();
    }

    public void AddElementToList(DropdownElement dropdownElement)
    {
        sectionElements.Add(dropdownElement);
    }

    private void DisplaySectionElements(bool show)
    {
        opened = !opened;
        foreach(DropdownElement element in sectionElements)
        {
            element.DisplayElement(show);
        }
        // with vertical layout group,
        // the heights update automatically after enabling
        // or disabling game objects.
    }

}
