using UnityEngine;
using TMPro;

/// <summary>
/// A pop up small window that shows the name of the current selection.
/// It moves on the screen with the current selection's position.
/// </summary>
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

    /// <summary>
    /// Function called when the current selection changes.
    /// </summary>
    /// <param name="currentSelection"></param>
    private void ChangeNameText(Part currentSelection)
    {
        currentPart = currentSelection;
        if (currentSelection == null) return;
        gameObject.SetActive(true);
        nameField.text = currentSelection.PartName;
    }

    private void MoveLabel()
    {
        if (currentPart == null)
        {
            transform.position = new Vector3(-100.0f, 0.0f, 0f);
            return;
        }
        else
        {
            Vector3 objectInScreenPos = Camera.main.WorldToScreenPoint(currentPart.transform.position);
            Vector3 labelPos = new Vector3(
                objectInScreenPos.x + offset.x,
                objectInScreenPos.y + offset.y,
                objectInScreenPos.z);
            transform.position = labelPos;
        }
    }
}
