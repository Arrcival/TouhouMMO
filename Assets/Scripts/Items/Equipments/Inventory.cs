using Assets.Scripts.Others;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Items.Equipments
{

    [RequireComponent(typeof(Character))]
    public class Inventory : MonoBehaviour
    {
        public AnyItem[] hotbar = new AnyItem[10];

        public UnityEvent RefreshUI;

        public UnityEvent<Equipable> EquippingItem;

        // Called from click on ui
        public void LootItemFromContainer(int slot)
        {
            #region Tests before looting
            if (!Statics.UIManager.DisplayedContainer || Statics.UIManager.CurrentContainer == null)
            {
                Debug.Log("There is no container...");
                return;
            }

            int i = getFirstSlotEmpty();
            if (IsInventoryFull() || i == -1)
            {
                Debug.Log("Inventory full !");
                return;
            }
            Container c = Statics.UIManager.CurrentContainer;

            if (c.ItemList.Count < slot)
            {
                Debug.Log("Un problème :(");
                return;
            }
            if (c.ItemList[slot] == null)
            {
                Debug.Log("L'objet n'existe pas");
                return;
            }
            #endregion


            hotbar[i] = c.ItemList[slot];
            Statics.UIManager.CurrentContainer.Loot(slot);

            Statics.UIManager.RefreshCurrentContainer();
            RefreshUI.Invoke();
        }

        public void EquipItem(int slot)
        {
            if (hotbar[slot] == null)
            {
                Debug.Log("there's no item...");
                return;
            }
            AnyItem item = hotbar[slot];
            hotbar[slot] = null;
            if (item is Equipable)
            {
                EquippingItem.Invoke(item as Equipable);
                RefreshUI.Invoke();
                return;
            }
            else if (item is Item)
            {
                return;
            }
        }

        public void Loot(AnyItem anItem)
        {
            int i = getFirstSlotEmpty();
            hotbar[i] = anItem;
            RefreshUI.Invoke();
        }

        public bool IsInventoryFull()
        {
            for (int i = 0; i < hotbar.Length; i++)
                if (hotbar[i] == null)
                    return false;
            return true;
        }

        int countItems()
        {
            int c = 0;
            for (int i = 0; i < hotbar.Length; i++)
                if (hotbar[i] != null)
                    c++;
            return c;
        }

        int getFirstSlotEmpty()
        {
            for (int i = 0; i < hotbar.Length; i++)
                if (hotbar[i] == null)
                    return i;
            return -1;

        }
    }
}