using UnityEngine;
using Utils;

public class HumanoidUnit : Unit
{
    private Vector2 velocity;
    private Vector3 lastPosition;

    public float CurrentSpeed => velocity.magnitude;

    protected void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime;

        lastPosition = transform.position;
        IsMoving = velocity.magnitude > 0;

        animator.SetFloat(Constants.Animation.SPEED, CurrentSpeed);
    }
}
