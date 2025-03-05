using UnityEngine;

public class PointToClick : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AnimationCurve scaleCurve;

    private Vector3 initialScale;

    private float timer;

    void Start()
    {
        initialScale = transform.localScale;
        transform.localScale *= 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        float scaleMultiplier = scaleCurve.Evaluate(timer);
        transform.localScale = initialScale * scaleMultiplier;

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

