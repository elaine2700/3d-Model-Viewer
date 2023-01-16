using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Instantiates DropdownElements to the sideBar to see the model structure in a Tree List view.
/// </summary>
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
            return;
        }
        modelList = new TreeList(rootObject);
        DisplayList();
    }

    // Depth-First
    public void DisplayList()
    {
        Node currentNode = modelList.Root;
        Stack<Node> nodes = new Stack<Node>();
        nodes.Push(currentNode);

        DropdownSection currentSection = null;
        while (nodes.Count > 0)
        {
            currentNode = nodes.Pop();
            currentNode.children.Reverse();
            foreach (Node child in currentNode.children)
            {
                nodes.Push(child);
            }

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
                    currentSection = newLabel.GetComponent<DropdownSection>();
                    break;
                case 2:
                    // Parts
                    newLabel = Instantiate(prefabElement, contentSpace);
                    newLabel.ConfigureLabel(currentNode.name, currentNode.refObject, false);
                    // Add to parent section list.
                    if (currentSection != null)
                    {
                        newLabel.AddToSection(currentSection);
                    }   
                    break;
                default:
                    break;
            }
        }
    }

}
