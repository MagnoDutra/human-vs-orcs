using UnityEngine;

public abstract class Unit : MonoBehaviour
{
  public bool IsMoving { get; protected set; }

  protected Animator animator;

  protected void Awake()
  {
    animator = GetComponent<Animator>();

    if (TryGetComponent<Animator>(out Animator anim))
    {
      animator = anim;
    }
  }
}
