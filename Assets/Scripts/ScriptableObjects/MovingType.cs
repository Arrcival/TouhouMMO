using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy moving type", menuName = "Game/New moving type")]
    public class MovingType : ScriptableObject
    {
        public bool FollowsPlayer;
        public float Speed;
        [Range(0.0f, 1.0f)]
        public float HPMin = 0f;
        [Range(0.0f, 1.0f)]
        public float HPMax = 1f;

        public Vector2 MovementDirection = Vector2.zero;

        public float CooldownTime = 0f;
        public float LengthToPlay = 5f;
        public float WaitTillPlay = 0f;
        float waitedTime = 0f;
        float playedTime = 0f;
        float cooldown = 0f;

        public Vector2 GetMovement(Enemy enemy, Vector2 player, float deltaTime)
        {
            if (waitedTime >= WaitTillPlay)
            {
                if (CooldownTime == 0f || cooldown <= 0f)
                {
                    if (playedTime < LengthToPlay)
                    {
                        playedTime += deltaTime;
                        float enemyHP = enemy.GetHPPercentage();

                        if (enemyHP <= HPMax && enemyHP > HPMin)
                        {
                            if (FollowsPlayer)
                                return ((player - (Vector2)enemy.transform.position)).normalized * Speed;
                            else
                            {
                                return MovementDirection.normalized * Speed;
                            }
                        }
                    }
                    else
                    {
                        playedTime = 0f;
                        cooldown = CooldownTime;
                    }

                }
                else
                    cooldown -= deltaTime;
            }
            else
                waitedTime += deltaTime;

            return Vector2.zero;
        }
    }
}