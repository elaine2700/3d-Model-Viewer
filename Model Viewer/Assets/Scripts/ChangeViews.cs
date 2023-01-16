using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeViews : MonoBehaviour
{
    [SerializeField] Button resetButton;
    [SerializeField] Button xRayButton;
    [SerializeField] Button transparentButton;
    [SerializeField] Button shadedButton;

    ModelView modelView;
    Select selectScript;

    private void Awake()
    {
        modelView = FindObjectOfType<ModelView>();
        selectScript = FindObjectOfType<Select>();
    }

    private void OnEnable()
    {
        resetButton.onClick.AddListener(ResetView);
        xRayButton.onClick.AddListener(XRayView);
        transparentButton.onClick.AddListener(TransparentView);
        shadedButton.onClick.AddListener(ShadedView);
    }

    private void OnDisable()
    {
        resetButton.onClick.RemoveListener(ResetView);
        xRayButton.onClick.RemoveListener(XRayView);
        transparentButton.onClick.RemoveListener(TransparentView);
        shadedButton.onClick.RemoveListener(ShadedView);
    }

    private void ResetView()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void XRayView()
    {
        Debug.Log("Changing to XrayView");
        selectScript.canMove = false;
        modelView.ChangeToXRayView();
    }

    private void ShadedView()
    {
        Debug.Log("ShadedView");
        selectScript.canMove = false;
        modelView.ChangeToShadedView();
    }

    private void TransparentView()
    {
        Debug.Log("Changing to Transparent View");
        selectScript.canMove = false;
        modelView.ChangeToTransparentView();
    }
}
