using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    [Header("UI")]
    [SerializeField] private PointToClick pointToClickPrefab;
    [SerializeField] private ActionBar actionBar;

    private Unit activeUnit;
    private Vector2 initialTouchPoisition = Vector2.zero;

    public bool HasActiveUnit => activeUnit != null;

    void Start()
    {
        ClearActionBarUI();
    }

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
        if (HasActiveUnit && IsHumanoid(activeUnit))
        {
            activeUnit.MoveTo(worldPoint);
            DisplayClickEffect(worldPoint);
        }
    }

    void HandleClickOnUnit(Unit unit)
    {
        if (HasActiveUnit)
        {
            if (HasClickedOnActiveUnit(unit))
            {
                CancelActiveUnit();
                return;
            }
        }
        SelectNewUnit(unit);
    }

    private void CancelActiveUnit()
    {
        activeUnit.Deselect();
        activeUnit = null;
    }

    void SelectNewUnit(Unit unit)
    {
        if (HasActiveUnit)
        {
            activeUnit.Deselect();
        }

        activeUnit = unit;
        activeUnit.Select();
        ShowUnitActions();
    }

    bool HasClickedOnActiveUnit(Unit clickedUnit) => clickedUnit == activeUnit;

    bool IsHumanoid(Unit unit) => unit is HumanoidUnit;

    void DisplayClickEffect(Vector2 worldPoint)
    {
        Instantiate(pointToClickPrefab, (Vector3)worldPoint, Quaternion.identity);
    }

    void ShowUnitActions()
    {
        ClearActionBarUI();

        var hardcodedActions = 2;

        for (int i = 0; i < hardcodedActions; i++)
        {
            actionBar.RegisterAction();
        }

        actionBar.Show();

    }

    void ClearActionBarUI()
    {
        actionBar.ClearActions();
        actionBar.Hide();
    }
}