using Assets.Scripts.Characters;
using Assets.Scripts.Items.Equipments;
using UnityEngine;


namespace  Assets.Scripts.Items
{
    [RequireComponent(typeof(PlayerStatus), typeof(Inventory))]
    class CollectibleMagnet : MonoBehaviour
    {
        public float MagneticFieldDistance = 10f;
        public float PickupDistance = 2f;
        public float PickupSpeed = 1f;


        PlayerStatus status = null;
        Inventory inventory = null;

        void Start()
        {
            status = GetComponent<PlayerStatus>();
            inventory = GetComponent<Inventory>();

        }

        public void Pick(Collectible aCollectible)
        {
            if (aCollectible is DrawableItem)
            {
                DrawableItem di = aCollectible as DrawableItem;
                Item itemGot = di.heldItem;
                //inventory.Loot(itemGot);
            }
            else if (aCollectible is Orb)
                status.LootOrb(aCollectible as Orb);

            Destroy(aCollectible.gameObject);
        }
    }
}
