using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 10.0f;

    Actions inputActions;
    Vector2 rotationInput;
    bool canRotate = false;

    private void Awake()
    {
        inputActions = new Actions();
        inputActions.Interactions.Rotate.performed += _ => canRotate = true;
        inputActions.Interactions.Rotate.canceled += _ => canRotate = false;

        inputActions.Interactions.MouseMovement.performed += cntxt => rotationInput = cntxt.ReadValue<Vector2>();
        inputActions.Interactions.MouseMovement.canceled += _ => rotationInput = Vector2.zero;

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
        if (canRotate)
        {
            RotateModel();
        }
    }

    private void RotateModel()
    {
        Debug.Log("Rotating model");
        Debug.Log($"Rotation input {rotationInput.normalized}");
        Vector3 rotDir = new Vector3(0, -rotationInput.x, rotationInput.y).normalized;
        target.Rotate(rotDir * speed * Time.deltaTime);
    }

}
