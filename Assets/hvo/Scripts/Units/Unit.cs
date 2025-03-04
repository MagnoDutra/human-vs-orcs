using UnityEngine;

public abstract class Unit : MonoBehaviour
{
  [SerializeField] private Material highlightMaterial;
  public bool IsMoving { get; protected set; }
  public bool isTargeted;

  protected Animator animator;
  protected AIPawn aiPawn;
  protected SpriteRenderer spriteRenderer;

  protected Material originalMaterial;

  protected void Awake()
  {
    if (TryGetComponent<Animator>(out Animator anim))
    {
      animator = anim;
    }

    if (TryGetComponent<AIPawn>(out AIPawn AI))
    {
      aiPawn = AI;
    }

    if (TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
    {
      spriteRenderer = sr;
    }

    originalMaterial = spriteRenderer.material;
  }

  public void MoveTo(Vector3 destination)
  {
    Vector3 direction = (destination - transform.position).normalized;
    spriteRenderer.flipX = direction.x < 0;

    aiPawn.SetDestination(destination);
  }

  public void Select()
  {
    isTargeted = true;
    Highlight();
  }

  public void Deselect()
  {
    isTargeted = false;
    Unhighlight();
  }

  private void Highlight()
  {
    spriteRenderer.material = highlightMaterial;
  }

  private void Unhighlight()
  {
    spriteRenderer.material = originalMaterial;
  }
}
