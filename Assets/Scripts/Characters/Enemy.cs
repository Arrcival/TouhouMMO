using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : Character
    {
        UnityEvent On_Hit;
        [HideInInspector] public UnityEvent On_Death; // that's where the loot begins :D
                                                      // drops orbs
                                                      // might be movable to EnemyMovement
        [HideInInspector] public Rigidbody2D rb;
        [ShowOnly, SerializeField] float HP = 100;

        [Rename("HP max")]
        public float HPmax = 100;
        [ShowOnly] public bool PlayerSpotted = false;
        public float DetectionRadius = 2;

        public int XPOnDeath = 5;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            HP = HPmax;
        }
        public override void OnHit(DealtAttack attack)
        {
            HP -= attack.Damages;
            CheckDeath();
        }
        public void Update()
        {
            PlayerSpotted = Vector2.Distance(transform.position, Statics.MainPlayer.transform.position) <= DetectionRadius;
        }

        public void CheckDeath()
        {
            if (HP <= 0)
            {
                On_Death.Invoke();
                Statics.MainPlayer.On_Enemy_Death.Invoke(this);
                Destroy(gameObject);
            }
        }

        public float GetHPPercentage()
        {
            return HP / HPmax;
        }

        public Vector2 GetAngleTowardPlayer()
        {
            Vector3 angleTowardsPlayer = Statics.MainPlayer.transform.position - transform.position;
            angleTowardsPlayer.z = 0f;
            Vector2 newAngle = angleTowardsPlayer;
            return newAngle.normalized;
        }
    }
}
