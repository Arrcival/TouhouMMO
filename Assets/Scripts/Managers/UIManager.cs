using Assets.Scripts.Items.Equipments;
using Assets.Scripts.Others;
using Assets.Scripts.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        // Start is called before the first frame update

        public GameObject UIContainer = null;
        [HideInInspector] public Container CurrentContainer = null;
        [ShowOnly] public bool DisplayedContainer = false;

        public GameObject UIInventory = null;

        public Inventory Inventory;
        public TooltipAnyItem Tooltip;

        public UIEquipments Equipments = null;

        void Start()
        {
            Statics.UIManager = this;
            Inventory.RefreshUI.AddListener(RefreshInventory);
        }

        #region Tooltip manager
        // called by hover
        public void HoverContainer(int slot)
        {
            if (Tooltip != null && CurrentContainer != null && DisplayedContainer && CurrentContainer.ItemList.Count > slot)
            {
                Tooltip.Display(CurrentContainer.ItemList[slot]);
            }
        }
        public void HoverInventory(int slot)
        {
            if (Tooltip != null && Inventory != null && Inventory.hotbar[slot] != null)
            {
                Tooltip.Display(Inventory.hotbar[slot]);
            }
        }

        public void HoverEquipable(int slot)
        {
            if (Tooltip != null && Equipments != null)
            {
                Tooltip.Display(Equipments.GetEquipable(slot));
            }
        }

        public void StopHovering()
        {
            if (Tooltip != null)
            {
                Tooltip.ClearDisplay();
            }
        }
        #endregion

        #region Manage Inventory
        public void RefreshInventory()
        {
            StopHovering();
            int j = 0;
            for (int i = 0; i < UIInventory.transform.childCount; i++)
            {
                Transform child = UIInventory.transform.GetChild(i);
                if (child.name.StartsWith("Slot"))
                {
                    AnyItem item = Inventory.hotbar[j];
                    Image img = child.GetComponent<Image>();
                    Outline ol = child.GetComponent<Outline>();
                    //Debug.Log(child.name);
                    if (item != null && item.Sprite != null)
                    {
                        item.SetSprite(img, ol);
                    }
                    else
                        ResetImage(img, ol);
                    //else
                    //Debug.Log("No sprite found");
                    j++;
                }
            }
        }
        #endregion

        #region Manage Container

        public void RefreshCurrentContainer()
        {
            StopHovering();
            if (CurrentContainer != null && DisplayedContainer)
            {
                ClearSlots();
                if (CurrentContainer.ItemList.Count > 0)
                    DisplayContainer(CurrentContainer);
            }
        }

        public void DisplayContainer(Container container)
        {
            CurrentContainer = container;
            List<AnyItem> temp = new List<AnyItem>(container.ItemList);
            DisplayedContainer = true;
            UIContainer?.SetActive(true);

            // temp.ForEach(t => Debug.Log(t));

            for (int i = 0; i < UIContainer.transform.childCount; i++)
            {
                if (temp.Count == 0)
                    break;
                Transform child = UIContainer.transform.GetChild(i);
                if (child.name.StartsWith("Slot"))
                {

                    //Debug.Log(child.name);
                    if (temp[0].Sprite != null)
                    {
                        temp[0].SetSprite(child.GetComponent<Image>(), child.GetComponent<Outline>());
                        temp.RemoveAt(0);
                    }
                }
            }
        }


        public void RemoveContainer()
        {
            CurrentContainer = null;
            DisplayedContainer = false;
            UIContainer?.SetActive(false);
            ClearSlots();
        }

        void ClearSlots()
        {
            if (UIContainer != null)
            {
                for (int i = 0; i < UIContainer.transform.childCount; i++)
                {
                    Transform child = UIContainer.transform.GetChild(i);
                    if (child.name.StartsWith("Slot"))
                    {
                        ResetImage(child.GetComponent<Image>(), child.GetComponent<Outline>());
                    }
                }
            }
        }
        #endregion

        public static void ResetImage(Image img, Outline outline = null)
        {
            img.sprite = null;
            img.color = new Color(1f, 1f, 1f, 0f);
            if (outline != null)
                outline.effectColor = new Color(1f, 1f, 1f, 0f);
        }
    }
}