using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    public class PatternOneTime : Pattern
    {
        public float[] ProjectileAngles = new float[0];


        // Update is called once per frame
        private void Update()
        {
            if (ProjectileAngles.Length <= 0)
                DestroyPattern();

            for (int i = 0; i < ProjectileAngles.Length; i++)
            {
                GenerateProjectile(ProjectileAngles[i]);
            }
            DestroyPattern();
        }
    }

}
