using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public string name;
    public int level = 0;
    public Transform refObject;
    public List<Node> children = new List<Node>();
    public Node parent = null;

    public Node(Transform nodeObject, int nodeLevel = 0)
    {
        this.refObject = nodeObject;
        this.name = nodeObject.name;
        this.children = new List<Node>();
        this.level = nodeLevel;
    }
}

public class TreeList
{
    Transform rootObject;
    Node root;
    public Node Root { get { return root; } }

    public TreeList(Transform rootTransform)
    {
        this.rootObject = rootTransform;
        root = new Node(rootObject);
        PopulateList();
    }

    private Node AddNode(Transform newObject, Node parent)
    {
        Node newNode = new Node(newObject);
        parent.children.Add(newNode);
        newNode.parent = parent;
        if (newNode.parent != null)
            newNode.level = newNode.parent.level + 1;
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
                    //Debug.Log($"Adding {newNode.refObject.name} to list, level {newNode.level}");
                }
            }

            if (nodes.Count <= 0) break;
            currentNode = nodes.Pop();
        }
    }
    
}
