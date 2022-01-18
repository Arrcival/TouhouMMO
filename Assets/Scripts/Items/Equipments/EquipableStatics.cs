using Assets.Scripts.Attacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.Items.Equipments
{
    public static class EquipableStatics
    {
        public const float COMMON_CHANCES = 0.4f;
        public const float UNCOMMON_CHANCES = 0.3f;
        public const float RARE_CHANCES = 0.2f;

        public enum EquipableType
        {
            WEAPON, BOOK, ARMOR, NECKLACE, BRACELET, RING
        }
        public enum Rarity
        {
            COMMON, UNCOMMON, RARE, EPIC, UNIQUE
        }

        public enum ArmorType
        {
            PLATE, TUNIC, ROBE
        }
        public enum StatType
        {
            HP, MP, REGEN, DEFENSE, CRIT, CRITDMG, ATK, POWER, NULL
        }

        public static Equipable GenerateEquipment(int tier, int seed)
        {
            EquipableType equipmentType = GetEquipmentType(seed);

            switch (equipmentType)
            {
                case (EquipableType.WEAPON):
                    return new Weapon(tier, seed);
                case (EquipableType.BOOK):
                    return new Book(tier, seed);
                case (EquipableType.ARMOR):
                    return new Armor(tier, seed);
                case (EquipableType.NECKLACE):
                    return new Necklace(tier, seed);
                case (EquipableType.BRACELET):
                    return new Bracelet(tier, seed);
                case (EquipableType.RING):
                    return new Ring(tier, seed);

                default:
                    Debug.Log("Something exploded in EquipmentStatics");
                    return null;
            }
        }

        public static Item GenerateItem(int id)
        {
            // Check if ID is unique or no
            return new Item(id);
        }

        public static EquipableType GetEquipmentType(int seed)
        {
            Random.InitState(seed);
            int number = Random.Range(0, 6);
            return (EquipableType)number;
        }

        public static Rarity GetRarity(int seed)
        {
            Random.InitState(seed);
            float roll = Random.Range(0f, 1f);
            if (roll <= COMMON_CHANCES)
                return Rarity.COMMON;
            if (roll <= UNCOMMON_CHANCES + COMMON_CHANCES)
                return Rarity.UNCOMMON;
            if (roll <= RARE_CHANCES + COMMON_CHANCES + UNCOMMON_CHANCES)
                return Rarity.RARE;
            return Rarity.EPIC;
        }

        public static EquipableStat GetRandomStat(int seed, int tier, List<StatType> exceptions)
        {
            Random.InitState(seed);
            StatType stat = StatType.NULL;

            while (stat == StatType.NULL || exceptions.Contains(stat))
            {
                int number = Random.Range(0, 8);
                stat = StatType.ATK;
                stat = (StatType)number;
            }

            return GetRandomFixedStat(stat, seed, tier);
        }

        public static EquipableStat GetRandomFixedStat(StatType type, int seed, int tier, float weight = 1f)
        {
            Random.InitState(seed);
            StatRange statRange = null;

            switch (type)
            {
                case (StatType.ATK):
                    statRange = TierGenerator.GetAtk(seed, tier);
                    break;
                case (StatType.HP):
                    statRange = TierGenerator.GetHP(seed, tier, weight);
                    break;
                case (StatType.MP):
                    statRange = TierGenerator.GetMP(seed, tier);
                    break;
                case (StatType.DEFENSE):
                    statRange = TierGenerator.GetDefense(seed, tier, weight);
                    break;
                case (StatType.CRIT):
                    statRange = TierGenerator.GetCrit(seed, tier);
                    break;
                case (StatType.CRITDMG):
                    statRange = TierGenerator.GetCritDMG(seed, tier);
                    break;
                case (StatType.POWER):
                    statRange = TierGenerator.GetPower(seed, tier);
                    break;
                case (StatType.REGEN):
                    statRange = TierGenerator.GetRegen(seed, tier);
                    break;
                default:
                    Debug.Log("Something broke in GetRandomFixedStat");
                    break;


            }
            return new EquipableStat(type, statRange);
        }

        public static Projectile GetRandomWeaponProjectile(int seed)
        {
            //Get the path of the Levels folder from Resources
            string AssetsFolderPath = Application.dataPath;
            string ResourcesFolder = "/Resources/WeaponProjectiles";
            string levelFolder = AssetsFolderPath + ResourcesFolder;

            DirectoryInfo dir = new DirectoryInfo(levelFolder);
            FileInfo[] info = dir.GetFiles("*.prefab");
            int fileCount = info.Length;

            Random.InitState(seed);
            int roll = Random.Range(0, fileCount);

            string s = "WeaponProjectiles/" + info[roll].Name.Split('.')[0];
            return Resources.Load<Projectile>(s);
        }



        #region Sprites getters
        public static Sprite GetItemSpriteEquipment(string name, int tier)
        {
            Sprite sprite = Resources.Load<Sprite>("Items/Equipments/" + name + tier);
            if (sprite != null)
                return sprite;

            return Resources.Load<Sprite>("Items/Equipments/Default");
        }

        public static Sprite GetItemSprite(int id)
        {
            Sprite sprite = Resources.Load<Sprite>("Items/Item" + id);
            if (sprite != null)
                return sprite;

            return Resources.Load<Sprite>("Items/ItemDefault");
        }

        #endregion
    }
}