using Assets.Scripts.Items.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Others
{
    public class Container : MonoBehaviour
    {
        [ShowOnly] public bool Displayed = false;
        public List<AnyItem> ItemList = new List<AnyItem>();



        public void AddItems(List<AnyItem> items)
        {
            // first items are deleted if full
            if (ItemList.Count + items.Count >= Statics.MAX_ITEM_IN_CONTAINER)
                ItemList.RemoveRange(0, ItemList.Count + items.Count - Statics.MAX_ITEM_IN_CONTAINER);


            ItemList.AddRange(items);

            // update display ui if displayed
            if (Displayed)
                Statics.UIManager.RefreshCurrentContainer();
        }

        public void Update()
        {
            float distance = Vector2.Distance(transform.position, Statics.MainPlayer.transform.position);

            if (Displayed)
            {
                if (distance > Statics.MAX_DISTANCE_FOR_CONTAINER)
                {
                    Statics.UIManager.RemoveContainer();
                    Displayed = false;
                }
            }
            else
            {
                if (!Statics.UIManager.DisplayedContainer && distance <= Statics.MAX_DISTANCE_FOR_CONTAINER)
                {
                    Statics.UIManager.DisplayContainer(this);
                    Displayed = true;
                }
            }
        }

        public void Loot(int slot)
        {
            ItemList.RemoveAt(slot);
            if (ItemList.Count == 0)
            {
                Statics.Containers.Remove(gameObject);
                if (Displayed)
                    Statics.UIManager.RemoveContainer();

                Destroy(gameObject);
            }
        }
    }

}
