using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Characters
{
    [RequireComponent(typeof(PlayerStatus))]
    public class Player : Character
    {
        public PlayerStatus Status;

        [ShowOnly] public UnityEvent<Enemy> On_Enemy_Death;

        public int Level = 1;

        public int XP = 0;


        public void Awake()
        {
            Status = GetComponent<PlayerStatus>();
        }

        public void Start()
        {
            Statics.MainPlayer = this;
            On_Enemy_Death.AddListener(GetStuffFromEnemyDeath);
        }

        public Vector2 getCursorDirection()
        {
            // middle position
            return (Statics.GetCursorPos() - (Vector2)transform.position).normalized;
        }

        public override void OnHit(DealtAttack attack)
        {
            Status.OnHit(attack);
        }


        public void GetStuffFromEnemyDeath(Enemy enemy)
        {
            Status.GiveXP(enemy.XPOnDeath);
        }


    }
}
