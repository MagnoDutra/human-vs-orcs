using UnityEngine;

public class PointToClick : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration * 0.9f)
        {
            float fadeProgress = (timer - duration * 0.9f) / (duration * 0.1f);
            spriteRenderer.color = new Color(1, 1, 1, 1 - fadeProgress);
        }

        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}

