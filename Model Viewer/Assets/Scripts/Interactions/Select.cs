using UnityEngine;
using UnityEngine.EventSystems;

public class Select : MonoBehaviour
{
    Actions inputActions;
    Hover hover;
    Part currentSelection;
    bool canMove;
    Vector2 mouseInput;

    private void Awake()
    {
        hover = GetComponent<Hover>();
        inputActions = new Actions();
        inputActions.Interactions.Select.performed += _ => SelectPart();
        inputActions.Interactions.Select.performed += _ => canMove = true;
        inputActions.Interactions.Select.canceled += _ => canMove = false;

        inputActions.Interactions.MouseMovement.performed += cntxt => mouseInput = cntxt.ReadValue<Vector2>();
        inputActions.Interactions.MouseMovement.canceled += _ => mouseInput = Vector2.zero;
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

    private void SelectPart()
    {
        Part part = hover.GetHighlightedPart();
        if (part == null)
        {
            return;
        }
        canMove = true;
        // change current selection, to change highlight.
        if (currentSelection != null)
            currentSelection.ExitSelection();
        part.EnterSelection();
        currentSelection = part;
    }

    private void MovePart()
    {
        if (currentSelection == null) return;
        if (!canMove) return;
        //if (!EventSystem.current.IsPointerOverGameObject(0))
            //return;

        Vector3 mousePos = Input.mousePosition;
        //Debug.Log(mousePos);
        float zDistance = Mathf.Abs(currentSelection.transform.position.z - Camera.main.transform.position.z);
        currentSelection.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
        
    }
}
