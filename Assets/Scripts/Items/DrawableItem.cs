// For inventory stuff

using Assets.Scripts.Items.Equipments;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class DrawableItem : Collectible
    {
        public Item heldItem;

        void Start()
        {
            color = Color.yellow;
            ApplyToSprite();
        }

    }
}
