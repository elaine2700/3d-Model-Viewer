using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class SelectionEvent : UnityEvent<Part> { }

/// <summary>
/// Manages the interaction with the model individual parts.
/// It can select and move every part.
/// </summary>
public class Select : MonoBehaviour
{
    public SelectionEvent changedSelection;

    [SerializeField] Vector3 partOffset = Vector3.zero;

    Actions inputActions;
    Hover hover;
    Part currentSelection;
    public bool canMove;
    

    private void Awake()
    {
        hover = GetComponent<Hover>();
        inputActions = new Actions();
        inputActions.Interactions.Select.performed += _ => SelectPart(hover.GetHighlightedPart());
        inputActions.Interactions.Select.performed += _ => canMove = true;
        inputActions.Interactions.Select.canceled += _ => canMove = false;
    }

    private void Start()
    {
        if (changedSelection == null)
            changedSelection = new SelectionEvent();
    }

    private void Update()
    {
        MovePart();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void SelectPart(Part part)
    {
        // change current selection, to change highlight.
        if (currentSelection != null)
            currentSelection.ExitSelection();
        if (part == null)
        {
            currentSelection = null;
            changedSelection.Invoke(null);
            return;
        }
        // Get offset of new selection
        partOffset = part.transform.position - hover.GetHitPosition();
        part.EnterSelection();
        currentSelection = part;
        changedSelection.Invoke(currentSelection);
    }

    private void MovePart()
    {
        if (currentSelection == null) return;
        if (!canMove) return;
        //if (!EventSystem.current.IsPointerOverGameObject(0))
            //return;

        Vector3 mousePos = Input.mousePosition;
        float zDistance = Mathf.Abs(currentSelection.transform.position.z - Camera.main.transform.position.z);
        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
        partOffset.z = 0;
        currentSelection.transform.position = screenPos + partOffset;

    }
}
