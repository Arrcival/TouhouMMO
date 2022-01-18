using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class ManaOrb : Orb
    {
        void Start()
        {
            color = Color.blue;
            ApplyToSprite();
        }

        public override void AddToStatus(PlayerStatus status)
        {
            status.InstantMana(value);
        }
    }
}