using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class subscribes to the buttons on the main bar.
/// When their onClick event is invoked, it changes to a new view: xRay, shaded, or transparent.
/// </summary>
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
        selectScript.canMove = false;
        modelView.ChangeToXRayView();
    }

    private void ShadedView()
    {
        selectScript.canMove = false;
        modelView.ChangeToShadedView();
    }

    private void TransparentView()
    {
        selectScript.canMove = false;
        modelView.ChangeToTransparentView();
    }
}
