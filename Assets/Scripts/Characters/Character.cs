using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public abstract void OnHit(DealtAttack attack);
}