using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] public MovingType[] MovingTypes;
        Enemy enemy;
        private void Start()
        {
            enemy = GetComponent<Enemy>();
        }
        // Update is called once per frame
        void Update()
        {
            if (MovingTypes.Length > 0)
            {
                if (enemy.PlayerSpotted)
                {
                    Vector2 movement = Vector2.zero;
                    for (int i = 0; i < MovingTypes.Length; i++)
                    {
                        movement += MovingTypes[i].GetMovement(enemy, Statics.MainPlayer.transform.position, Time.deltaTime);
                    }
                    enemy.rb.velocity = movement * Consts.OVERALL_MOVING_SPEED;
                }
                else
                {
                    enemy.rb.velocity = Vector2.zero;
                }
            }
        }
    }

}
