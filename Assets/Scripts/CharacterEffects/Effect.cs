using UnityEngine;
public abstract class Effect
{
    float duration;
    // Used to draw on the UI
    float displayValue;
    // must have a method for effect ADDITION


    public abstract void AddSameEffect(Effect sameEffect);
}