using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private ActionButton actionButtonPrefab;

    private Color originalBackgroundColor;
    private List<ActionButton> actionButtons = new();

    void Awake()
    {
        originalBackgroundColor = backgroundImage.color;
    }

    public void RegisterAction()
    {
        var actionButton = Instantiate(actionButtonPrefab, transform);
        actionButtons.Add(actionButton);
    }

    public void ClearActions()
    {
        for (int i = actionButtons.Count - 1; i >= 0; i--)
        {
            Destroy(actionButtons[i].gameObject);
            actionButtons.RemoveAt(i);
        }
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
