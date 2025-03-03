using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    public Unit activeUnit;
    private Vector2 initialTouchPoisition;

    void Update()
    {
        Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;

        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            initialTouchPoisition = inputPosition;
        }

        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (Vector2.Distance(initialTouchPoisition, inputPosition) < 10)
            {
                DetectClick(inputPosition);
            }
        }
    }

    void DetectClick(Vector2 inputPos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(inputPos);
        HandleClickOnGround(worldPoint);
    }

    void HandleClickOnGround(Vector2 worldPoint)
    {
        activeUnit.MoveTo(worldPoint);
    }
}