using UnityEngine;

public class AIPawn : MonoBehaviour
{
  public Vector3? Destination { get; private set; }
  [SerializeField] private float speed = 5f;

  void Update()
  {
    if (Destination.HasValue)
    {
      Vector3 direction = Destination.Value - transform.position;
      transform.position += speed * Time.deltaTime * direction.normalized;

      float distanceToDestination = Vector3.Distance(transform.position, Destination.Value);
      if (distanceToDestination < 0.01f)
      {
        Destination = null;
      }
    }
  }

  public void SetDestination(Vector3 destination)
  {
    Destination = destination;
  }
}
