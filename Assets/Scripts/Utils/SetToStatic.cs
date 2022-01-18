using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class SetToStatic : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Statics.EnemiesBulletHolder = gameObject;
        }
    }

}
