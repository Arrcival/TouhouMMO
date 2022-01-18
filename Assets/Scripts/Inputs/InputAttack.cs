using Assets.Scripts.Attacks;
using Assets.Scripts.Characters;
using Assets.Scripts.Items.Equipments;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.Statics;

namespace Assets.Scripts.Inputs
{
    [RequireComponent(typeof(Player), typeof(PlayerStatus), typeof(Inventory))]
    public class InputAttack : MonoBehaviour
    {
        [SerializeField] Projectile autoAttack;
        float autoAttackCD; public float autoAttackCDMax;

        [SerializeField] GameObject bulletsHolder;
        Player player;

        private void Start()
        {

            player = GetComponent<Player>();
            if (player == null || player.Status == null)
                Destroy(this);

            autoAttackCD = 0f;
        }



        void Update()
        {
            UpdateAllCooldowns(Time.deltaTime);
            if (Input.GetMouseButton(0))
            {
                //player middle position
                CastAutoAttack(player.transform.position, player.getCursorDirection());
            }
        }

        void UpdateAllCooldowns(float deltaTime)
        {
            if (autoAttackCD > 0f)
                autoAttackCD -= Time.deltaTime;
        }


        void CastAutoAttack(Vector2 positionStart, Vector2 attackDirection)
        {
            if (autoAttackCD <= 0f && autoAttack != null)
            {
                LaunchAndRotate(positionStart, autoAttack, attackDirection);
                autoAttackCD = autoAttackCDMax;
            }
        }

        void LaunchAndRotate(Vector2 positionStart, Projectile gameObject, Vector2 attackDirection)
        {
            Projectile projectile = Instantiate(gameObject, bulletsHolder.transform);
            projectile.transform.position = positionStart;
            projectile.Attack = player.Status.GetDealtAttack();
            projectile.Side = Side.Player;
            projectile.Cast(attackDirection);
        }
    }
}
