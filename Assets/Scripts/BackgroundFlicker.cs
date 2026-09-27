using UnityEngine;

public class BackgroundFlicker : MonoBehaviour
{
    [Header("Background Sprites")]
    [SerializeField] private Sprite bulbOffSprite;
    [SerializeField] private Sprite bulbOnSprite;

    [Header("Flicker Settings")]
    [SerializeField] private float flickerInterval = 0.1f;
    [SerializeField] private float flickerDuration = 1f;

    private SpriteRenderer spriteRenderer;
    private float timer = 0f;
    private float flickerTimer = 0f;
    private bool isFlickering = true;
    private bool showingOnSprite = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (bulbOffSprite != null)
        {
            spriteRenderer.sprite = bulbOffSprite;
        }
    }

    private void Update()
    {
        if (!isFlickering)
            return;

        // Count total flicker time
        timer += Time.deltaTime;

        // Change sprite at the chosen interval
        flickerTimer += Time.deltaTime;

        if (flickerTimer >= flickerInterval)
        {
            flickerTimer = 0f;

            showingOnSprite = !showingOnSprite;

            if (showingOnSprite)
                spriteRenderer.sprite = bulbOnSprite;
            else
                spriteRenderer.sprite = bulbOffSprite;
        }

        // Stop flickering after the duration
        if (timer >= flickerDuration)
        {
            isFlickering = false;

            // Final state: bulb ON
            spriteRenderer.sprite = bulbOnSprite;
        }
    }
}