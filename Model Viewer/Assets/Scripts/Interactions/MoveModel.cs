using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveModel : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Transform target;

    Actions inputActions;
    bool canMove = false;
    Vector2 mouseMovementInput;

    private void Awake()
    {
        inputActions = new Actions();
        inputActions.Interactions.MoveAll.performed += _ => canMove = true;
        inputActions.Interactions.MoveAll.canceled += _ => canMove = false;

        inputActions.Interactions.MouseMovement.performed += cntxt => mouseMovementInput = cntxt.ReadValue<Vector2>();
        inputActions.Interactions.MouseMovement.canceled += _ => mouseMovementInput = Vector2.zero;

    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        if (canMove)
        {
            MovingModel();
        }
    }

    private void MovingModel()
    {
        Vector3 direction = new Vector3(mouseMovementInput.x, mouseMovementInput.y, 0).normalized;
        target.position += direction * speed * Time.deltaTime;
    }
}
