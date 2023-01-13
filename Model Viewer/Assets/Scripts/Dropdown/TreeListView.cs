using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// todo new name TreeList View
public class TreeListView : MonoBehaviour
{
    [Header("Model Data")]
    [SerializeField] Transform rootObject;

    [Header("UI View Settings")]
    [SerializeField] TextMeshProUGUI modelNameField;
    [SerializeField] DropdownElement prefabElement;
    [SerializeField] DropdownElement prefabSection;
    [SerializeField] RectTransform contentSpace;

    TreeList modelList;

    private void Start()
    {

        if (rootObject == null)
        {
            Debug.LogWarning("Add a root Object to Tree List to view hierarchy");
            // todo Disable side bar.
            return;
        }
        modelList = new TreeList(rootObject);
        DisplayList();
    }

    public void DisplayList()
    {
        Debug.Log("Displayig TreeList");
        Node currentNode = modelList.Root;
        Stack<Node> nodes = new Stack<Node>();
        nodes.Push(currentNode);

        // count for testing
        int count = 0;
        while (nodes != null)
        {
            currentNode = nodes.Pop();
            currentNode.children.Reverse();
            foreach (Node child in currentNode.children)
            {
                nodes.Push(child);
            }
            string spaces = new String('_', currentNode.level * 2);
            Debug.Log($"{spaces} {currentNode.name}");

            // Instantiating List Elements
            DropdownElement newLabel = null;
            switch (currentNode.level)
            {
                case 0:
                    // Model Name - tree root
                    modelNameField.text = currentNode.name;
                    break;
                case 1:
                    // Sections
                    newLabel = Instantiate(prefabSection, contentSpace);
                    newLabel.ConfigureLabel(currentNode.name, currentNode.refObject, true);
                    break;
                case 2:
                    // Parts
                    newLabel = Instantiate(prefabElement, contentSpace);
                    newLabel.ConfigureLabel(currentNode.name, currentNode.refObject, false);
                    break;
                default:
                    break;
            }
            
            count++;
            if (count >= 40) break;
        }
    }

    // To update list, just sect element SetActive(false),
    // the heights update automatically.

    // Get parent
    // Get sections
    // Get children for each section

    // UI
    // Section is a dropdown
    // Children is a new box.

    // When a section is selected
    // Other sections shift down
    

}
