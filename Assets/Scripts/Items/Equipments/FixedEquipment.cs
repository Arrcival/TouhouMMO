using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class UniqueEquipment : Item
    {
        EquipableType equipmentType;

        Rarity rarity;


        public UniqueEquipment(int id)
        {
            Sprite = GetItemSprite(id);
            rarity = Rarity.UNIQUE;
        }

        public string GetRarity()
        {
            return rarity.ToString();
        }
    }
}