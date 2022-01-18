using Assets.Scripts.Characters;
using UnityEngine;
namespace Assets.Scripts.Items
{
    public class ExpOrb : Orb
    {
        void Start()
        {
            color = Color.green;
            ApplyToSprite();
        }

        public override void AddToStatus(PlayerStatus status)
        {
            status.GiveXP((int)value);
        }
    }
}