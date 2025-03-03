using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    void Update()
    {
        Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;

        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            DetectClick(inputPosition);
        }
    }

    void DetectClick(Vector2 inputPos)
    {
        Debug.Log(inputPos);
    }
}