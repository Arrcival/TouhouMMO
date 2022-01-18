using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class Bracelet : Equipable
    {
        EquipableStat defensiveStat;
        public Bracelet(int tier, int seed) : base(tier, seed)
        {
            equipmentType = EquipableType.BRACELET;
            Id = 5;
            defensiveStat = GetRandomStat(
                seed,
                tier,
                new List<StatType>()
                {
                StatType.ATK,
                StatType.CRIT,
                StatType.CRITDMG,
                StatType.POWER,
                });
            Sprite = GetItemSpriteEquipment("b", tier);
        }

        public override List<EquipableStat> GetAllStats()
        {
            List<EquipableStat> stats = new List<EquipableStat>(SubStats);
            stats.Add(defensiveStat);
            return stats;
        }

        public override string ToString()
        {
            string text = $"Bracelet Tier {tier} {rarity}" + Environment.NewLine;
            text += defensiveStat.StatType + " : " + defensiveStat.GetValue + Environment.NewLine;
            for (int i = 0; i < SubStats.Count; i++)
            {
                text += SubStats[i].StatType + " : " + SubStats[i].GetValue + Environment.NewLine;
            }
            return text;
        }


        public override string DisplayTop()
        {
            return $"{defensiveStat.StatType} : {defensiveStat.GetValue}";
        }
    }
}