using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class Necklace : Equipable
    {
        EquipableStat DefStat;
        public Necklace(int tier, int seed) : base(tier, seed)
        {

            equipmentType = EquipableType.NECKLACE;
            Id = 4;
            DefStat = GetRandomFixedStat(StatType.DEFENSE, seed, tier);
            Sprite = GetItemSpriteEquipment("n", tier);
        }

        public override List<EquipableStat> GetAllStats()
        {
            List<EquipableStat> stats = new List<EquipableStat>(SubStats);
            stats.Add(DefStat);
            return stats;
        }
        public override string ToString()
        {
            string text = $"Necklace Tier {tier} {rarity}" + Environment.NewLine;
            text += DefStat.StatType + " : " + DefStat.GetValue + Environment.NewLine;
            for (int i = 0; i < SubStats.Count; i++)
            {
                text += SubStats[i].StatType + " : " + SubStats[i].GetValue + Environment.NewLine;
            }
            return text;
        }

        public override string DisplayTop()
        {
            return $"Defense : {DefStat.GetValue}";
        }
    }
}