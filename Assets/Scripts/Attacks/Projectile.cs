using Assets.Scripts.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Statics;

namespace Assets.Scripts.Attacks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        // The Attack to input on hit
        public DealtAttack Attack;
        [HideInInspector] public Side Side;
        [HideInInspector] public Vector2 AttackDirection;
        public float ProjectileSpeed = 1;

        Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            //transform.position += Vector3.right * Mathf.Sin(lifeSpan);

            //transform.position += (Vector3)AttackDirection * ProjectileSpeed * Time.deltaTime * Consts.OVERALL_MOVING_SPEED;

            rb.velocity = AttackDirection * ProjectileSpeed * Consts.OVERALL_MOVING_SPEED;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject hitObject = collision.gameObject;
            Character character = hitObject.GetComponent<Character>();
            if (character != null)
            {
                if (character is Enemy && Side == Side.Player)
                {
                    character.OnHit(Attack);
                    Destroy(gameObject);
                }
                if (character is Player && Side == Side.Enemy)
                {
                    character.OnHit(Attack);
                    Destroy(gameObject);
                }
            }
            if (collision.gameObject.layer == Consts.OBSTACLES_LAYER)
            {
                // Hits an obstacle
                Destroy(gameObject);
            }
        }

        public void Cast(Vector2 attackDirection)
        {
            AttackDirection = attackDirection;
            //gameObject.transform.eulerAngles = Vector3.forward * Angle(attackDirection);
        }

    }
}

