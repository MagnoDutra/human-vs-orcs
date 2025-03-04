using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    public Unit activeUnit;
    private Vector2 initialTouchPoisition = Vector2.zero;

    void Update()
    {
        // Posicao mouse ou touch
        Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;

        // checa se cliquei ou toquei a tela e marca onde isso ocorreu
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            initialTouchPoisition = inputPosition;
        }

        // checa se soltei o clique ou parei de tocar na tela
        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            // Verifica tipo um threshold até onde eu posso arrastar que ainda vai ser considerado click
            if (Vector2.Distance(initialTouchPoisition, inputPosition) < 10)
            {
                DetectClick(inputPosition);
            }
        }
    }

    void DetectClick(Vector2 inputPos)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(inputPos);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (HasClickOnUnit(hit, out Unit unit))
        {
            HandleClickOnUnit(unit);
        }
        else
        {
            HandleClickOnGround(worldPoint);
        }

    }

    bool HasClickOnUnit(RaycastHit2D hit, out Unit unit)
    {
        if (hit.collider != null && hit.collider.TryGetComponent<Unit>(out Unit clickedUnit))
        {
            unit = clickedUnit;
            return true;
        }

        unit = null;
        return false;
    }

    void HandleClickOnGround(Vector2 worldPoint)
    {
        activeUnit.MoveTo(worldPoint);
    }

    void HandleClickOnUnit(Unit unit)
    {
        SelectNewUnit(unit);
    }

    void SelectNewUnit(Unit unit)
    {
        activeUnit = unit;
    }
}