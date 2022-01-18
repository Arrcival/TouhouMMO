using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class Armor : Equipable
    {
        public List<EquipableStat> MainStats = new List<EquipableStat>();
        public Armor(int tier, int seed) : base(tier, seed)
        {

            equipmentType = EquipableType.ARMOR;
            Id = 3;
            string name = "";
            float roll = UnityEngine.Random.Range(0, 3);
            if (roll == 0)
            {
                name = "ahp";
                MainStats.Add(GetRandomFixedStat(StatType.HP, seed, tier));
            }
            else if (roll == 1)
            {
                name = "aduo";
                MainStats.Add(GetRandomFixedStat(StatType.HP, seed, tier, 0.5f));
                MainStats.Add(GetRandomFixedStat(StatType.DEFENSE, seed, tier, 0.5f));
            }
            else
            {
                name = "adef";
                MainStats.Add(GetRandomFixedStat(StatType.DEFENSE, seed, tier));
            }

            Sprite = GetItemSpriteEquipment(name, tier);
        }

        public override List<EquipableStat> GetAllStats()
        {
            List<EquipableStat> stats = new List<EquipableStat>(SubStats);
            stats.AddRange(MainStats);
            return stats;
        }

        public override string ToString()
        {
            string text = $"Armor Tier {tier} {rarity}" + Environment.NewLine;
            for (int i = 0; i < MainStats.Count; i++)
            {
                text += MainStats[i].StatType + " : " + MainStats[i].GetValue + Environment.NewLine;
            }
            for (int i = 0; i < SubStats.Count; i++)
            {
                text += SubStats[i].StatType + " : " + SubStats[i].GetValue + Environment.NewLine;
            }
            return text;
        }
        public override string DisplayTop()
        {
            string s = "";
            for (int i = 0; i < MainStats.Count; i++)
            {
                s += MainStats[i].StatType + " : " + MainStats[i].GetValue + Environment.NewLine;
            }
            return s;
        }

    }

}
