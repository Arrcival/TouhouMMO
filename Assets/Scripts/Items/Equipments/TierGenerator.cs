using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items.Equipments
{
    public class TierGenerator : MonoBehaviour
    {
        // generate StatRange depending on what asked

        public static StatRange GetDefense(int seed, int tier, float weight)
        {
            float tierValue = 0.25f;
            float min = 1f;
            float max = 2f;
            float step = 0.1f;
            return new StatRange((min + tier * tierValue) * weight, (max + tier * tierValue) * weight, step, seed);
        }

        public static StatRange GetPower(int seed, int tier)
        {
            float tierValue = 1f;
            float min = 5f;
            float max = 10f;
            float step = 1f;

            return new StatRange(min + tier * tierValue, max + tier * tierValue, step, seed);
        }

        public static StatRange GetCrit(int seed, int tier)
        {
            float tierValue = 0.5f;
            float min = 3f;
            float max = 5f;
            float step = 0.05f;

            return new StatRange(min + tier * tierValue, max + tier * tierValue, step, seed);
        }

        public static StatRange GetCritDMG(int seed, int tier)
        {
            float tierValue = 0.5f;
            float min = 5f;
            float max = 8f;
            float step = 1f;

            return new StatRange(min + tier * tierValue, max + tier * tierValue, step, seed);
        }

        public static StatRange GetRegen(int seed, int tier)
        {
            float tierValue = 0.05f;
            float min = 0.1f;
            float max = 0.15f;
            float step = 0.05f;

            return new StatRange(min + tier * tierValue, max + tier * tierValue, step, seed);
        }
        public static StatRange GetAtk(int seed, int tier)
        {
            float tierValue = 1f;
            float min = 5f;
            float max = 10f;
            float step = 1f;

            return new StatRange(min + tier * tierValue, max + tier * tierValue, step, seed);
        }

        public static StatRange GetHP(int seed, int tier, float weight)
        {
            float tierValue = 1f;
            float min = 3f;
            float max = 7f;
            float step = 0.5f;

            return new StatRange((min + tier * tierValue) * weight, (max + tier * tierValue) * weight, step, seed);
        }
        public static StatRange GetMP(int seed, int tier)
        {
            float tierValue = 1f;
            float min = 3f;
            float max = 7f;
            float step = 0.5f;

            return new StatRange(min + tier * tierValue, max + tier * tierValue, step, seed);
        }


        public static StatRange GetATKDamages(int seed, int tier, float rangeWeight)
        {
            float tierValue = 5f;
            float min = 100f;
            float max = 120f;
            float step = 2f;

            return new StatRange((min + tier * tierValue) / rangeWeight, (max + tier * tierValue) / rangeWeight, step, seed);
        }

    }
}