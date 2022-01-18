using Assets.Scripts.Items.Equipments;
using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UIEquipments : MonoBehaviour
    {
        public Equipment PlayerEquipment = null;

        public GameObject Weapon;
        public GameObject Book;
        public GameObject Armor;
        public GameObject Necklace;
        public GameObject Bracelet;
        public GameObject Ring;

        // Start is called before the first frame update
        void Start()
        {
            PlayerEquipment.UpdateEquipmentUI.AddListener(UpdateEquipment);
        }

        void UpdateEquipment()
        {
            UIManager.ResetImage(Weapon.GetComponent<Image>(), Weapon.GetComponent<Outline>());
            UIManager.ResetImage(Book.GetComponent<Image>(), Book.GetComponent<Outline>());
            UIManager.ResetImage(Armor.GetComponent<Image>(), Armor.GetComponent<Outline>());
            UIManager.ResetImage(Necklace.GetComponent<Image>(), Necklace.GetComponent<Outline>());
            UIManager.ResetImage(Bracelet.GetComponent<Image>(), Bracelet.GetComponent<Outline>());
            UIManager.ResetImage(Ring.GetComponent<Image>(), Ring.GetComponent<Outline>());
            PlayerEquipment?.Weapon?.SetSprite(Weapon.GetComponent<Image>(), Weapon.GetComponent<Outline>());
            PlayerEquipment?.Book?.SetSprite(Book.GetComponent<Image>(), Book.GetComponent<Outline>());
            PlayerEquipment?.Armor?.SetSprite(Armor.GetComponent<Image>(), Armor.GetComponent<Outline>());
            PlayerEquipment?.Necklace?.SetSprite(Necklace.GetComponent<Image>(), Necklace.GetComponent<Outline>());
            PlayerEquipment?.Bracelet?.SetSprite(Bracelet.GetComponent<Image>(), Bracelet.GetComponent<Outline>());
            PlayerEquipment?.Ring?.SetSprite(Ring.GetComponent<Image>(), Ring.GetComponent<Outline>());
        }

        public AnyItem GetEquipable(int slot)
        {
            switch (slot)
            {
                case (0):
                    return PlayerEquipment?.Weapon;
                case (1):
                    return PlayerEquipment?.Book;
                case (2):
                    return PlayerEquipment?.Armor;
                case (3):
                    return PlayerEquipment?.Necklace;
                case (4):
                    return PlayerEquipment?.Bracelet;
                case (5):
                    return PlayerEquipment?.Ring;
                default:
                    return null;

            }
        }
    }

}
