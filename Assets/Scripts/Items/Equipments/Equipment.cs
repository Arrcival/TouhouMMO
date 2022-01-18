using Assets.Scripts.Characters;
using Assets.Scripts.Items.Equipments;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Items.Equipments
{
    [RequireComponent(typeof(PlayerStatus), typeof(Inventory))]
    public class Equipment : MonoBehaviour, IStatutable
    {
        // To invoke on unequip/equip
        public UnityEvent UpdateEquipmentUI;

        // Equipped stuff
        public Weapon Weapon;
        public Book Book;
        public Armor Armor;
        public Necklace Necklace;
        public Bracelet Bracelet;
        public Ring Ring;

        // Will be showonly
        public float HPBonus { get; set; }
        public float ManaBonus { get; set; }

        // STAYS 0
        public float AtkBonus { get; set; }
        public float AtkBonusPercentage { get; set; }
        public float PowBonusPercentage { get; set; }
        public float DefBonus { get; set; }
        public float RegenBonus { get; set; }
        public float CritBonus { get; set; }
        public float CritDmgBonus { get; set; }

        PlayerStatus status;
        Inventory inv;

        private void Start()
        {
            DefBonus = 3f;
            status = GetComponent<PlayerStatus>();
            status.StatusBonuses.Add(this);
            status.UpdateStatus.Invoke(true);
            inv = GetComponent<Inventory>();
            inv.EquippingItem.AddListener(EquipEquipable);
        }

        // called from UI
        public void Unequip(int slot)
        {
            if (!inv.IsInventoryFull())
            {
                switch (slot)
                {
                    case (0):
                        inv.Loot(Weapon);
                        EquipWeapon(null);
                        break;
                    case (1):
                        inv.Loot(Book);
                        EquipBook(null);
                        break;
                    case (2):
                        inv.Loot(Armor);
                        EquipArmor(null);
                        break;
                    case (3):
                        inv.Loot(Necklace);
                        EquipNecklace(null);
                        break;
                    case (4):
                        inv.Loot(Bracelet);
                        EquipBracelet(null);
                        break;
                    case (5):
                        inv.Loot(Ring);
                        EquipRing(null);
                        break;
                    default:
                        break;
                }
            }
        }
        public void EquipEquipable(Equipable equipable)
        {
            if (equipable is Weapon)
            {
                inv.Loot(Weapon);
                EquipWeapon(equipable as Weapon);
            }
            if (equipable is Book)
            {
                inv.Loot(Book);
                EquipBook(equipable as Book);
            }
            if (equipable is Armor)
            {
                inv.Loot(Armor);
                EquipArmor(equipable as Armor);
            }
            if (equipable is Necklace)
            {
                inv.Loot(Necklace);
                EquipNecklace(equipable as Necklace);
            }
            if (equipable is Bracelet)
            {
                inv.Loot(Bracelet);
                EquipBracelet(equipable as Bracelet);
            }
            if (equipable is Ring)
            {
                inv.Loot(Ring);
                EquipRing(equipable as Ring);
            }
        }

        #region Equip specific
        public void EquipWeapon(Weapon newWep)
        {
            Weapon?.Unequip(this);
            newWep?.Equip(this);
            Weapon = newWep;
            status.WeaponAtk = Weapon.Damages.FinalValue;
            RefreshGameState();
        }
        public void EquipBook(Book newBook)
        {
            Book?.Unequip(this);
            newBook?.Equip(this);
            Book = newBook;
            status.BookPower = Book.Power;
            RefreshGameState();
        }
        public void EquipArmor(Armor newArmor)
        {
            Armor?.Unequip(this);
            newArmor?.Equip(this);
            Armor = newArmor;
            RefreshGameState();
        }
        public void EquipNecklace(Necklace newNeck)
        {
            Necklace?.Unequip(this);
            newNeck?.Equip(this);
            Necklace = newNeck;
            RefreshGameState();
        }
        public void EquipBracelet(Bracelet newBrac)
        {
            Bracelet?.Unequip(this);
            newBrac?.Equip(this);
            Bracelet = newBrac;
            RefreshGameState();
        }

        public void EquipRing(Ring newRing)
        {
            Ring?.Unequip(this);
            newRing?.Equip(this);
            Ring = newRing;
            RefreshGameState();
        }

        public void RefreshGameState()
        {
            UpdateEquipmentUI.Invoke();
            inv.RefreshUI.Invoke();
            status.UpdateStatus.Invoke(false);
        }
        #endregion

    }
}