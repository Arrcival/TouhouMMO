using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DealtAttack
{
    // Will contain stuff to affect character+status on collision

    public List<Effect> Effects;
    public float Damages;

    public DealtAttack(float damageAmount)
    {
        Damages = damageAmount;
    }

}
