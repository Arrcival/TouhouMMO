using Assets.Scripts.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UIShowStats : MonoBehaviour
    {
        public GameObject StatMenu;
        public PlayerStatus status;
        public Text Level;
        public Text XP;
        public Text HP;
        public Text MP;
        public Text Atk;
        public Text Power;
        public Text Def;
        public Text Crit;
        public Text CritDMG;
        public Text Regen;

        bool isDisplayed = false;

        private void Start()
        {
            status.UpdateStatScreen.AddListener(UpdateTexts);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                isDisplayed = !isDisplayed;
                if (isDisplayed)
                    UpdateTexts();
                StatMenu.gameObject.SetActive(isDisplayed);
            }
        }

        void UpdateTexts()
        {
            Level.text = status.Level.ToString();
            XP.text = status.XP + " / " + status.GetXPNeededForNextLevel().ToString();
            HP.text = $"{Math.Round(status.HP, 1)} / {Math.Round(status.HPmax, 1)}";
            MP.text = $"{Math.Round(status.Mana, 1)} / {Math.Round(status.Manamax, 1)}";
            Atk.text = Mathf.Round(status.GetDamages).ToString();
            Power.text = Mathf.Round(status.GetPower).ToString();
            Crit.text = Math.Round(status.crit_rate, 1).ToString() + " %";
            CritDMG.text = Math.Round(status.crit_dmg, 1).ToString() + " %";
            Regen.text = $"{Math.Round(status.regen, 2).ToString()}/s";

        }
    }

}
