using Assets.Scripts.Characters;
using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Statics
    {
        public static Player MainPlayer;
        public static UIManager UIManager;


        public static GameObject EnemiesBulletHolder;
        public static GameObject ContainerObject;
        public static List<GameObject> Containers = new List<GameObject>();

        public const int SEED_MAX = 1000000;
        public const int MAX_ITEM_IN_CONTAINER = 9;
        public const int MAX_DISTANCE_FOR_CONTAINER = 2;

        public const float BASE_HP = 100f;
        public const float BASE_MP = 100f;
        public const float BASE_CRIT = 0f;
        public const float BASE_CRITDMG = 150f;
        public const float BASE_REGEN = 1f;
        public const float BASE_POWER = 0f;

        public const float MANA_REGEN = 1f;


        public enum Side
        {
            Player, Enemy
        }
        public static float Angle(Vector2 p_vector2)
        {
            if (p_vector2.x < 0)
            {
                return 360 - (Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg * -1);
            }
            else
            {
                return Mathf.Atan2(p_vector2.x, p_vector2.y) * Mathf.Rad2Deg;
            }
        }
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }
        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }


        public static Vector2 GetCursorPos()
        {
            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos = UnityEngine.Camera.main.ScreenToWorldPoint(mouse_pos);
            mouse_pos.z = 0f;
            return mouse_pos;
        }
    }
}
