using UnityEngine;

public class PointToClick : MonoBehaviour
{
    [SerializeField] private float duration = 1f;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
