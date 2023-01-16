using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Hides/Display the side bar.
/// </summary>
public class SideBar : MonoBehaviour
{
    [SerializeField] Sprite openSprite;
    [SerializeField] Sprite closedSprite;
    [SerializeField] Image imageToChange;

    [SerializeField] Button toogleSideBarButton;
    [SerializeField] RectTransform sideBar;

    private void OnEnable()
    {
        toogleSideBarButton.onClick.AddListener(DisplaySideBar);
    }

    private void OnDisable()
    {
        toogleSideBarButton.onClick.RemoveListener(DisplaySideBar);
    }

    private void DisplaySideBar()
    {
        bool openSideBar = !sideBar.gameObject.activeSelf;
        sideBar.gameObject.SetActive(openSideBar);
        if (openSideBar)
        {
            imageToChange.sprite = openSprite;
        }
        else
        {
            imageToChange.sprite = closedSprite;
        }
    }
}
