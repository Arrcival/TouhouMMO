using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class Ring : Equipable
    {
        EquipableStat offensiveStat;
        public Ring(int tier, int seed) : base(tier, seed)
        {
            equipmentType = EquipableType.RING;
            Id = 6;
            offensiveStat = GetRandomStat(
                seed,
                tier,
                new List<StatType>()
                {
                StatType.HP,
                StatType.MP,
                StatType.REGEN,
                StatType.DEFENSE,
                });
            Sprite = GetItemSpriteEquipment("r", tier);
        }

        public override List<EquipableStat> GetAllStats()
        {
            List<EquipableStat> stats = new List<EquipableStat>(SubStats);
            stats.Add(offensiveStat);
            return stats;
        }
        public override string ToString()
        {
            string text = $"Ring Tier {tier} {rarity}" + Environment.NewLine;
            text += offensiveStat.StatType + " : " + offensiveStat.GetValue + Environment.NewLine;
            for (int i = 0; i < SubStats.Count; i++)
            {
                text += SubStats[i].StatType + " : " + SubStats[i].GetValue + Environment.NewLine;
            }
            return text;
        }

        public override string DisplayTop()
        {
            return $"{offensiveStat.StatType} : {offensiveStat.GetValue}";
        }
    }
}
