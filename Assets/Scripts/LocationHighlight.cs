using UnityEngine;

public class LocationHighlight : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color highlightColor = Color.green;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void SetHighlight(bool highlighted)
    {
        spriteRenderer.color = highlighted ? highlightColor : originalColor;
    }
}
