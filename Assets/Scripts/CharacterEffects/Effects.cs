using System.Collections.Generic;
using UnityEngine;
public class Effects
{
    List<Effect> effects;

    public Effects(params Effect[] extraEff)
    {
        effects = new List<Effect>();
        for(int i = 0; i < extraEff.Length; i++)
            AddEffect(extraEff[i]);
    }

    public void AddEffect(Effect eff)
    {
        Effect existingOne = IsEffectExisiting(eff);
        if (existingOne != null)
            existingOne.AddSameEffect(eff);
        else
            effects.Add(eff);
    }

    public Effect IsEffectExisiting(Effect eff)
    {
        if (effects.Count <= 0)
            return null;
        foreach(Effect effect in effects)
        {
            if (effect.GetType() == eff.GetType())
                return effect;
        }
        return null;
    }
}