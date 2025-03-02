using UnityEngine;

public class HumanoidUnit : Unit
{
    private Vector2 velocity;
    private Vector3 lastPosition;

    protected void Update()
    {
        velocity = (transform.position - lastPosition) / Time.deltaTime;

        lastPosition = transform.position;
        IsMoving = velocity.magnitude > 0;
    }
}
