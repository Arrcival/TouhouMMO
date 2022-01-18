using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GeneralManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Statics.ContainerObject = Resources.Load("Container") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
