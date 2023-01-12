using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public string name;
    public int level = 0;
    public Transform refObject;
    public List<Node> children = new List<Node>();

    public Node(Transform nodeObject, int nodeLevel = 0)
    {
        this.refObject = nodeObject;
        this.name = nodeObject.name;
        this.children = new List<Node>();
        this.level = nodeLevel;
    }   
}

public class TreeList : MonoBehaviour
{
    
    [SerializeField] Transform rootObject;
    
    Node root;

    private void Start()
    {
        if (rootObject == null)
        {
            Debug.LogWarning("Add a root Object to Tree List to view hierarchy");
            // todo Disable side bar.
            return;
        }
            
        root = new Node(rootObject);
        PopulateList();

        foreach(Node node in root.children)
        {
            Debug.Log($"Section: {node.name}");
        }
    }

    private Node AddNode(Transform newObject, Node parent)
    {
        Node newNode = new Node(newObject);
        parent.children.Add(newNode);

        return newNode;
    }

    // Populate Tree List with name information
    private void PopulateList()
    {
        Node currentNode = root;
        Stack<Node> nodes = new Stack<Node>();
        //nodes.Push(currentNode);

        // while currentNode is not null
        while (currentNode != null)
        {
            

            // Get current Transform -direct children-, make them nodes, and add them to stack
            if (currentNode.refObject.childCount > 0)
            {
                foreach (Transform transform in currentNode.refObject)
                {
                    Node newNode = AddNode(transform, currentNode);
                    nodes.Push(newNode);
                    Debug.Log($"Adding {newNode.refObject.name} to list");
                }
            }

            if (nodes.Count <= 0) break;
            currentNode = nodes.Pop();
        }
    }

    // Get parent
    // Get sections
    // Get children for each section

    // UI
    // Section is a dropdown
    // Children is a new box.

    // When a section is selected
    // Other sections shift down
    // Next section checks if dropdown parent is opened
    // if open, see last children position
    // set section position, after last children.
    // And do the same for all sections.
}
