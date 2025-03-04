using UnityEngine;

public abstract class Unit : MonoBehaviour
{
  public bool IsMoving { get; protected set; }

  protected Animator animator;
  protected AIPawn aiPawn;
  protected SpriteRenderer spriteRenderer;

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
  }

  public void MoveTo(Vector3 destination)
  {
    Vector3 direction = (destination - transform.position).normalized;
    spriteRenderer.flipX = direction.x < 0;

    aiPawn.SetDestination(destination);
  }
}
