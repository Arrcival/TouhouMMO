using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Attacks
{
    public class Pattern : MonoBehaviour // Maybe not idk 
    {
        // Does NOT manage if it follows the enemy or the place it's sent

        [HideInInspector] public Vector3 StartingPosition;
        [HideInInspector] public EnemyAttack EnemyAttack;

        public int DebugDamages = 5;

        // Holds a list of projectiles

        //Holds ONE projectile
        public Projectile Projectile;

        public bool TargetsPlayer = true;

        //creates it
        // left is default direction in DEGREEs, right is time to be sent, it's removed on sent
        // super ugly solution

        [ShowOnly] public float AttackDirection;



        public void GenerateProjectile(float direction)
        {
            Projectile projectile = Instantiate(Projectile, Statics.EnemiesBulletHolder.transform);
            projectile.transform.position = StartingPosition;
            projectile.Side = Statics.Side.Enemy;
            projectile.Attack = new DealtAttack(DebugDamages);


            if (TargetsPlayer)
                projectile.Cast(Statics.DegreeToVector2(-AttackDirection + direction).normalized);
            else
                projectile.Cast(Statics.DegreeToVector2(direction).normalized);
        }

        public void DestroyPattern()
        {
            EnemyAttack.PatternsExisting.Remove(this);
            Destroy(gameObject);
        }
    }

}
