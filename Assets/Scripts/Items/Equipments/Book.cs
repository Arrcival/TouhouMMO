using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class Book : Equipable
    {
        // Contains Spell (right click)

        public float Power = 50f;
        public Book(int tier, int seed) : base(tier, seed)
        {

            equipmentType = EquipableType.BOOK;
            Id = 2;
            // Random get for book and sprite

            Sprite = EquipableStatics.GetItemSpriteEquipment("t", tier);
        }
        public override string ToString()
        {
            string text = $"Book Tier {tier} {rarity}" + Environment.NewLine;
            text += "Power : " + Power + Environment.NewLine;
            return text;
        }

        public override string DisplayTop()
        {
            return $"Power : {Power}";
        }
    }
}