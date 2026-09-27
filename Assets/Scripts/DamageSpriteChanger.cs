using UnityEngine;

public class DamageSpriteChanger : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite damageLayer1;
    [SerializeField] private Sprite damageLayer2;
    [SerializeField] private Sprite damageLayer3;
    [SerializeField] private Sprite damageLayer4;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (normalSprite != null)
            spriteRenderer.sprite = normalSprite;
    }

    public void UpdateDamageSprite(int totalHits)
    {
        if (totalHits >= 15)
        {
            spriteRenderer.sprite = damageLayer4;
        }
        else if (totalHits >= 12)
        {
            spriteRenderer.sprite = damageLayer3;
        }
        else if (totalHits >= 7)
        {
            spriteRenderer.sprite = damageLayer2;
        }
        else if (totalHits >= 3)
        {
            spriteRenderer.sprite = damageLayer1;
        }
        else
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}