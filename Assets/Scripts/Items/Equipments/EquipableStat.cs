using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class EquipableStat
    {
        StatRange statRange;

        public StatType StatType;

        public EquipableStat(StatType type, StatRange aRange)
        {
            StatType = type; statRange = aRange;
        }

        public float GetValue
        {
            get
            {
                return statRange.FinalValue;
            }
        }

        #region Getters for stats
        public float GetATK()
        {
            if (StatType == StatType.ATK)
                return statRange.FinalValue;
            return 0;
        }
        public float GetPower()
        {
            if (StatType == StatType.POWER)
                return statRange.FinalValue;
            return 0;
        }
        public float GetCrit()
        {
            if (StatType == StatType.CRIT)
                return statRange.FinalValue;
            return 0;
        }
        public float GetCritDmg()
        {
            if (StatType == StatType.CRITDMG)
                return statRange.FinalValue;
            return 0;
        }
        public float GetHP()
        {
            if (StatType == StatType.HP)
                return statRange.FinalValue;
            return 0;
        }
        public float GetMP()
        {
            if (StatType == StatType.MP)
                return statRange.FinalValue;
            return 0;
        }
        public float GetRegen()
        {
            if (StatType == StatType.REGEN)
                return statRange.FinalValue;
            return 0;
        }
        public float GetDefense()
        {
            if (StatType == StatType.DEFENSE)
                return statRange.FinalValue;
            return 0;
        }

        #endregion
    }
}