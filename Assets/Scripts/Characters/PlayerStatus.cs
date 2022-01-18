using Assets.Scripts.Items;
using Assets.Scripts.Items.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.Characters
{
    [RequireComponent(typeof(Player))]
    public class PlayerStatus : MonoBehaviour
    {
        [SerializeField] public Image HealthBar;
        [SerializeField] public Image ManaBar;

        Equipment equipment;
        //readonly
        [ShowOnly] public float HP;
        [Rename("HP max")]
        public float HPmax = 100;

        [ShowOnly] public float Mana;
        [Rename("MP max")]
        public float Manamax = 50;

        public float WeaponAtk = 0f;
        public float BookPower = 0f;
        public float atk_bonus = 0f;
        public float atk_bonus_per = 0f;
        public float crit_rate = 0f;
        public float crit_dmg = 0f;
        public float regen = 0f;
        public float defense = 0f;
        public float power = 0f;

        public float GetDamages
        {
            get
            {
                return (WeaponAtk + atk_bonus) * (100 + atk_bonus_per) / 100;
            }
        }
        public float GetPower
        {
            get
            {
                return BookPower * (100 + power) / 100;
            }
        }

        public List<IStatutable> StatusBonuses = new List<IStatutable>();
        public UnityEvent<bool> UpdateStatus;
        public UnityEvent UpdateStatScreen;

        [ShowOnly] public int XPNeededForNextLevel;


        public int Level = 1;
        // does not get to 0 on levelup    
        public int XP;


        // debug purposes
        public float DEBUG_DAMAGES = 5f;

        private void Start()
        {
            UpdateStatus.AddListener(UpdateStats);
            equipment = GetComponent<Equipment>();
            XPNeededForNextLevel = GetXPNeededForNextLevel();
        }

        private void Update()
        {
            PassiveRegen();
        }


        public DealtAttack GetDealtAttack()
        {
            float roll = UnityEngine.Random.Range(0f, 100f);
            if (equipment.Weapon != null)
            {
                float damages = equipment.Weapon.Damages.FinalValue * (atk_bonus / 100);
                if (roll <= crit_rate)
                    return new DealtAttack(damages * (crit_dmg / 100));
                return new DealtAttack(damages);
            }
            return new DealtAttack(DEBUG_DAMAGES);

        }

        void PassiveRegen()
        {
            bool hasUpdated = false;
            if (HP < HPmax && regen > 0f)
            {
                HP += regen * Time.deltaTime;
                if (HP > HPmax)
                    HP = HPmax;
                hasUpdated = true;
            }
            if (Mana < Manamax && Statics.MANA_REGEN > 0f)
            {
                Mana += Statics.MANA_REGEN * Time.deltaTime;
                if (Mana > Manamax)
                    Mana = Manamax;
                hasUpdated = true;
            }
            if (hasUpdated)
            {
                UpdateBars();
                UpdateStatScreen.Invoke();
            }
        }
        public void OnHit(DealtAttack attack)
        {
            HP -= Mathf.Max(attack.Damages - defense, 0f);
            UpdateBars();
            // Effects
        }

        public void UpdateBars()
        {
            if (HealthBar == null)
                Debug.Log("Healthbar? null");
            HealthBar.fillAmount = HP / HPmax;
            ManaBar.fillAmount = Mana / Manamax;
        }

        public void LootOrb(Orb orb)
        {
            orb.AddToStatus(this);
        }

        public void UpdateStats(bool firstInit)
        {
            HPmax = Statics.BASE_HP + (Level - 1) + StatusBonuses.Sum(s => s.HPBonus);
            if (HP > HPmax)
                HP = HPmax;
            Manamax = Statics.BASE_HP + (Level - 1) + StatusBonuses.Sum(s => s.ManaBonus);
            if (Mana > Manamax)
                Mana = Manamax;
            crit_rate = Statics.BASE_CRIT + StatusBonuses.Sum(s => s.CritBonus);
            crit_dmg = Statics.BASE_CRITDMG + StatusBonuses.Sum(s => s.CritDmgBonus);
            regen = Statics.BASE_REGEN + (Level - 1) * 0.01f + StatusBonuses.Sum(s => s.RegenBonus);

            defense = StatusBonuses.Sum(s => s.DefBonus);
            power = Statics.BASE_POWER + (Level - 1) * 0.1f + StatusBonuses.Sum(s => s.PowBonusPercentage);
            atk_bonus = StatusBonuses.Sum(s => s.AtkBonus);
            atk_bonus_per = StatusBonuses.Sum(s => s.AtkBonusPercentage);

            if (firstInit)
            {
                HP = HPmax;
                Mana = Manamax;
            }
            UpdateBars();
            UpdateStatScreen.Invoke();
        }

        #region InstantEffects
        public void InstantHP(float amount)
        {
            HP = Math.Min(HP + amount, HPmax);
        }

        public void InstantMana(float amount)
        {
            Mana = Math.Min(Mana + amount, Manamax);
        }
        #endregion

        #region XP & Level
        public void GiveXP(int value)
        {
            XP += value;
            while (XP >= XPNeededForNextLevel)
            {
                // Level up !
                Level++;
                XPNeededForNextLevel = GetXPNeededForNextLevel();
                UpdateStatus.Invoke(false);
            }
        }
        public int GetXPNeededForNextLevel()
        {
            return (int)(Consts.XP_FOR_LEVEL_ONE * Mathf.Pow(Level, 2.5f));
        }

        #endregion

    }
}
