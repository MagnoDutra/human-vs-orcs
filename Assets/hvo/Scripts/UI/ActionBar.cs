using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    private Color originalBackgroundColor;

    void Awake()
    {
        originalBackgroundColor = backgroundImage.color;
        Hide();
    }

    public void Show()
    {
        backgroundImage.color = originalBackgroundColor;
    }

    public void Hide()
    {
        backgroundImage.color = new Color(0, 0, 0, 0);
    }
}
