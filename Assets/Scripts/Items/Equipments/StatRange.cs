using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items.Equipments
{
    public class StatRange
    {
        public float FinalValue;
        float minRange;
        float maxRange;
        float step;

        public StatRange(float min, float max, float aStep, int seed)
        {
            minRange = min;
            maxRange = max;
            step = aStep;

            Random.InitState(seed);

            float value = Random.Range(min, max + step);
            float numSteps = Mathf.Floor(value / step);
            FinalValue = numSteps * step;

            // SOFT CHECK
            if (FinalValue > max)
                FinalValue = min;

        }
    }

}
