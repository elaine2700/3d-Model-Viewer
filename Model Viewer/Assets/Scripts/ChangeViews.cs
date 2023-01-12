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

    private void Awake()
    {
        modelView = FindObjectOfType<ModelView>();
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
        modelView.ChangeToXRayView();
    }

    private void ShadedView()
    {
        Debug.Log("ShadedView");
        modelView.ChangeToShadedView();
    }

    private void TransparentView()
    {
        Debug.Log("Changing to Transparent View");
        modelView.ChangeToTransparentView();
    }
}
