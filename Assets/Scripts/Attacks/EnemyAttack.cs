using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    [System.Serializable]
    public class PatternInfo
    {
        public Pattern pattern;
        public float Cooldown = 1f;
        public float WaitToStart = 0f;

        [Range(0.0f, 1.0f)]
        public float MinHPToAttack = 0f;
        [Range(0.0f, 1.0f)]
        public float MaxHPToAttack = 1f;
        [HideInInspector] public float waited = 0f;
        [HideInInspector] public float cooldownTime = 0f;

    }

    [RequireComponent(typeof(Enemy))]
    public class EnemyAttack : MonoBehaviour
    {
        Enemy enemy;
        [SerializeField] public PatternInfo[] AttackPatterns;


        [HideInInspector] public List<Pattern> PatternsExisting = new List<Pattern>();

        void Start()
        {
            enemy = GetComponent<Enemy>();
            enemy.On_Death.AddListener(EnemyDied);
        }

        void Update()
        {
            for (int i = 0; i < AttackPatterns.Length; i++)
            {
                PatternInfo info = AttackPatterns[i];
                if (info.cooldownTime > 0f)
                    info.cooldownTime -= Time.deltaTime;

                if (enemy.PlayerSpotted)
                {
                    float enemyHP = enemy.GetHPPercentage();
                    if (info.waited >= info.WaitToStart)
                    {
                        if (enemyHP <= info.MaxHPToAttack && enemyHP > info.MinHPToAttack)
                        {
                            if (info.cooldownTime <= 0f)
                            {
                                if (enemyHP <= info.MaxHPToAttack && enemyHP > info.MinHPToAttack)
                                {
                                    Pattern pattern = Instantiate(info.pattern, Statics.EnemiesBulletHolder.transform);
                                    pattern.AttackDirection = Statics.Angle(enemy.GetAngleTowardPlayer()) - Consts.ANGLE_FOR_BULLETS;
                                    pattern.StartingPosition = transform.position;
                                    pattern.EnemyAttack = this;
                                    PatternsExisting.Add(pattern);
                                }
                                info.cooldownTime = info.Cooldown;
                            }
                        }
                    }
                    else
                        info.waited += Time.deltaTime;
                }
            }
        }

        void EnemyDied()
        {
            PatternsExisting.Where(a => a != null).ToList().ForEach(a => a.DestroyPattern());
        }
    }

}
