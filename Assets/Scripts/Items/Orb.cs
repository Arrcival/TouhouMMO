using Assets.Scripts.Characters;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public abstract class Orb : Collectible
    {
        public float value;
        public abstract void AddToStatus(PlayerStatus status);

    }
}
