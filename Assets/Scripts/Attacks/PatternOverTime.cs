using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts.Attacks
{
    [System.Serializable]
    public class ProjectileAngle
    {
        public float Angle;
        public float Time;
    }
    public class PatternOverTime : Pattern
    {
        float Lifespan = 0f;

        public ProjectileAngle[] ProjectileAngles = new ProjectileAngle[0];

        // Update is called once per frame
        void Update()
        {
            if (ProjectileAngles.Length <= 0)
                DestroyPattern();
            else
            {
                while (true)
                {
                    if (ProjectileAngles.Length == 0)
                        break;
                    if (Lifespan >= ProjectileAngles[0].Time)
                    {
                        GenerateProjectile(ProjectileAngles[0].Angle);
                        ProjectileAngles = ProjectileAngles.Skip(1).ToArray();
                    }
                    else
                        break;
                }

                Lifespan += Time.deltaTime;
            }
        }
    }

}
