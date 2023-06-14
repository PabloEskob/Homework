using Homework.Homework_v2.Scripts.Components;
using UnityEngine;

namespace Homework.Homework_v2.Scripts.Bullets
{
    internal static class BulletUtils
    {
        internal static void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent(out TeamComponent team))
            {
                return;
            }

            if (bullet.IsPlayer == team.IsPlayer)
            {
                return;
            }

            if (other.TryGetComponent(out HitPointsComponent hitPoints))
            {
                hitPoints.TakeDamage(bullet.Damage);
            }
        }
    }
}