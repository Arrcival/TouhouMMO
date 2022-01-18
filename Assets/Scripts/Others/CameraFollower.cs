using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] public Player player;

        public void Update()
        {
            Vector3 pos = player.transform.position;
            pos.z = Consts.CAMERA_Z;
            transform.position = pos;
        }
    }

}
