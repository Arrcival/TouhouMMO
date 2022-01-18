using Assets.Scripts.Attacks;
using System;
using System.IO;
using UnityEngine;
using static Assets.Scripts.Items.Equipments.EquipableStatics;

namespace Assets.Scripts.Items.Equipments
{
    public class Weapon : Equipable
    {
        int IDProjectile;

        float range;
        // WeaponType ?

        Projectile projectile;


        public StatRange Damages;

        public Weapon(int tier, int seed) : base(tier, seed)
        {
            equipmentType = EquipableType.WEAPON;
            Id = 1;


            projectile = GetRandomWeaponProjectile(seed);
            range = projectile.GetComponent<Rangespan>().MaxRange;
            Damages = TierGenerator.GetATKDamages(seed, tier, range);


            Sprite = GetItemSpriteEquipment("w", tier);
        }

        public override string ToString()
        {
            string text = $"Weapon Tier {tier} {rarity}" + Environment.NewLine;
            text += "Damages : " + Damages.FinalValue + Environment.NewLine;
            for (int i = 0; i < SubStats.Count; i++)
            {
                text += SubStats[i].StatType + " : " + SubStats[i].GetValue + Environment.NewLine;
            }
            return text;
        }


        /*
        FileInfo[] GetWeaponProjectilesAmount()
        {
            //I needed to get a count of my all level prefabs from my
            //Resources folder so I hashed together this frankenstein code:

            //Get the path of the Levels folder from Resources
            string AssetsFolderPath = Application.dataPath;
            string levelFolder = AssetsFolderPath + "/Resources/WeaponProjectiles";

            Debug.Log("dataPath : " + levelFolder);

            //////////////////////

            //DirectoryInfo needs "using System.IO"
            DirectoryInfo dir = new DirectoryInfo(levelFolder);
            FileInfo[] info = dir.GetFiles("*.prefab");
            int fileCount = info.Length;

            Debug.Log("Level Count: " + fileCount);
            if (info.Length > 0)
            {
                Debug.Log(info[0].Name);

            }

            //Clear array to save space, needs "using System"
            return info;
        }*/

        public override string DisplayTop()
        {
            return $"Damages : {Damages.FinalValue}";
        }
    }
}