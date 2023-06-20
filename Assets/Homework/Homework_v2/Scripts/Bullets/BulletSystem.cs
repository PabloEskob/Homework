using System.Collections.Generic;
using Homework.Homework_v2.Scripts.Level;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Bullets
{
    public sealed class BulletSystem : MonoBehaviour
    {
        [SerializeField] private LevelBounds _levelBounds;

        private BulletPool _bulletPool;
        private List<Bullet> _bullets;

        [Inject]
        private void Construct(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        private void Start()
        {
            _bullets = _bulletPool.GetAllBullets();
        }

        private void FixedUpdate()
        {
            for (int i = 0, count = _bullets.Count; i < count; i++)
            {
                var bullet = _bullets[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = _bulletPool.GetActiveBullet();

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.Damage = args.damage;
            bullet.IsPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);

            bullet.OnCollisionEntered += OnBulletCollision;
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.OnCollisionEntered -= OnBulletCollision;
            bullet.gameObject.SetActive(false);
        }

        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}