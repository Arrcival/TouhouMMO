using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    protected Color color;

    public void ApplyToSprite()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
            sr.color = color;
    }
}