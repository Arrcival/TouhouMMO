using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class LifeOrb : Orb
    {
        void Start()
        {
            color = Color.red;
            ApplyToSprite();
        }

        public override void AddToStatus(PlayerStatus status)
        {
            status.InstantHP(value);
        }
    }
}
