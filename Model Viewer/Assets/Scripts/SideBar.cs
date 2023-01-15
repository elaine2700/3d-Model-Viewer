using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            // todo Change the image button
            imageToChange.sprite = openSprite;
            //toogleSideBarButton.GetComponentInChildren<TextMeshProUGUI>().text = "^";
        }
        else
        {
            // todo Change the image button
            imageToChange.sprite = closedSprite;
            //toogleSideBarButton.GetComponentInChildren<TextMeshProUGUI>().text = "v";
        }
    }
}
