using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public abstract class Equipable : AnyItem
    {
        public EquipableType equipmentType;

        public Rarity rarity;

        public int tier;

        int seed;


        public List<EquipableStat> SubStats = new List<EquipableStat>();



        public Equipable(int aTier, int aSeed) : base()
        {
            tier = aTier;
            seed = aSeed;
            rarity = GetRarity(seed);

            if (rarity != Rarity.COMMON && rarity != Rarity.UNIQUE && equipmentType != EquipableType.BOOK)
                GenerateSubStats(tier, seed);
        }

        public void GenerateSubStats(int tier, int seed)
        {
            int stats = (int)rarity;
            UnityEngine.Random.InitState(seed);

            for (int i = 1; i <= stats; i++)
            {

                SubStats.Add(
                    GetRandomStat(
                        seed,
                        tier,
                        SubStats.Select(o => o.StatType).ToList()
                        )
                    );
            }
        }

        public virtual List<EquipableStat> GetAllStats()
        {
            return SubStats;
        }

        public void Equip(Equipment e)
        {
            List<EquipableStat> stats = GetAllStats();
            e.HPBonus += stats.Sum(p => p.GetHP());
            e.ManaBonus += stats.Sum(p => p.GetMP());
            e.AtkBonusPercentage += stats.Sum(p => p.GetATK());
            e.DefBonus += stats.Sum(p => p.GetDefense());
            e.PowBonusPercentage += stats.Sum(p => p.GetPower());
            e.CritBonus += stats.Sum(p => p.GetCrit());
            e.CritDmgBonus += stats.Sum(p => p.GetCritDmg());
            e.RegenBonus += stats.Sum(p => p.GetRegen());
        }

        public void Unequip(Equipment e)
        {
            List<EquipableStat> stats = GetAllStats();
            e.HPBonus -= stats.Sum(p => p.GetHP());
            e.ManaBonus -= stats.Sum(p => p.GetMP());
            e.AtkBonusPercentage -= stats.Sum(p => p.GetATK());
            e.DefBonus -= stats.Sum(p => p.GetDefense());
            e.PowBonusPercentage -= stats.Sum(p => p.GetPower());
            e.CritBonus -= stats.Sum(p => p.GetCrit());
            e.CritDmgBonus -= stats.Sum(p => p.GetCritDmg());
            e.RegenBonus -= stats.Sum(p => p.GetRegen());
        }

        public override Color GetOutlineColor()
        {
            switch (rarity)
            {
                case (Rarity.UNCOMMON):
                    return Color.gray;
                case (Rarity.RARE):
                    return Color.blue;
                case (Rarity.EPIC):
                    return Color.magenta;
                case (Rarity.UNIQUE):
                    return Color.yellow;
                default:
                    return new Color(0f, 0f, 0f, 0f);

            }
        }
        public override Color GetWritingColor()
        {
            switch (rarity)
            {
                case (Rarity.UNCOMMON):
                    return Color.white;
                case (Rarity.RARE):
                    return Color.blue;
                case (Rarity.EPIC):
                    return Color.magenta;
                case (Rarity.UNIQUE):
                    return Color.yellow;
                default:
                    return Color.grey;

            }
        }
        public override string DisplayName()
        {
            return $"{rarity} {equipmentType} T{tier}";
        }

        public override string DisplayBottom()
        {
            string s = "";
            for (int i = 0; i < SubStats.Count; i++)
            {
                s += SubStats[i].StatType + " : " + SubStats[i].GetValue + Environment.NewLine;
            }
            return s;
        }
    }
}

