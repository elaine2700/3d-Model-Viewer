using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SideBar : MonoBehaviour
{
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
        bool setDisplay = !sideBar.gameObject.activeSelf;
        sideBar.gameObject.SetActive(setDisplay);
        if (setDisplay)
        {
            // todo Change the image button
            toogleSideBarButton.GetComponentInChildren<TextMeshProUGUI>().text = "^";
        }
        else
        {
            // todo Change the image button
            toogleSideBarButton.GetComponentInChildren<TextMeshProUGUI>().text = "v";
        }
    }
}
