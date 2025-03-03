using UnityEngine;

public abstract class Unit : MonoBehaviour
{
  public bool IsMoving { get; protected set; }

  protected Animator animator;
  protected AIPawn aiPawn;

  protected void Awake()
  {
    if (TryGetComponent<Animator>(out Animator anim))
    {
      animator = anim;
    }

    if (TryGetComponent<AIPawn>(out AIPawn aiPawn))
    {
      this.aiPawn = aiPawn;
    }
  }

  public void MoveTo(Vector3 destination)
  {
    aiPawn.SetDestination(destination);
  }
}
