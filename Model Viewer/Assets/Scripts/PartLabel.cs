using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PartLabel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameField;
    [SerializeField] Vector2 offset;

    Select selectScript;
    Part currentPart;

    private void Awake()
    {
        selectScript = FindObjectOfType<Select>();
    }

    private void Update()
    {
        MoveLabel();
    }

    private void OnEnable()
    {
        selectScript.changedSelection.AddListener(ChangeNameText);
    }

    private void OnDisable()
    {
        selectScript.changedSelection.RemoveAllListeners();
    }

    private void ChangeNameText(Part currentSelection)
    {
        gameObject.SetActive(true);
        nameField.text = currentSelection.PartName;
        currentPart = currentSelection;
    }

    private void MoveLabel()
    {
        if (currentPart == null) return;
        Vector3 objectInScreenPos = Camera.main.WorldToScreenPoint(currentPart.transform.position);
        Vector3 labelPos = new Vector3(
            objectInScreenPos.x + offset.x,
            objectInScreenPos.y + offset.y,
            objectInScreenPos.z);
        transform.position = labelPos;
    }
}
