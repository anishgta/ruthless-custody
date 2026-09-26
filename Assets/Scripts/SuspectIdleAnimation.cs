using UnityEngine;

public class SuspectIdleAnimation : MonoBehaviour
{
    [Header("Two suspect sprites")]
    [SerializeField] private Sprite spriteA;
    [SerializeField] private Sprite spriteB;

    [Header("Seconds between swaps")]
    [SerializeField] private float animationInterval = 0.1f;

    private SpriteRenderer spriteRenderer;
    private bool isAnimating = true;
    private bool showingA = true;
    private float timer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (spriteRenderer != null && spriteA != null)
        {
            spriteRenderer.sprite = spriteA;
        }
    }

    private void Update()
    {
        if (!isAnimating || spriteRenderer == null)
            return;

        timer += Time.deltaTime;

        if (timer >= animationInterval)
        {
            timer = 0f;
            showingA = !showingA;

            spriteRenderer.sprite = showingA ? spriteA : spriteB;
        }
    }

    public void StopAnimation()
    {
        isAnimating = false;
    }
}