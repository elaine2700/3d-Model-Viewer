using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    [SerializeField] Image helpPicture;
    [SerializeField] Sprite helpSign;
    [SerializeField] Sprite toCloseSprite;

    Button helpButton;
    bool open = false;

    private void Awake()
    {
        helpButton = GetComponent<Button>();
    }

    private void Start()
    {
        DisplayHelpImage(open);
    }

    private void OnEnable()
    {
        helpButton.onClick.AddListener(() => DisplayHelpImage(!open));
    }

    private void OnDisable()
    {
        helpButton.onClick.RemoveAllListeners();
    }

    private void DisplayHelpImage(bool show)
    {
        open = show;
        helpPicture.gameObject.SetActive(show);
        if (open)
        {
            helpButton.image.sprite = toCloseSprite;
        }
        else
        {
            helpButton.image.sprite = helpSign;
        }
    }
}
