using System.Collections.Generic;
using Homework.Homework_v2.Scripts.Common;
using UnityEngine;

namespace Homework.Homework_v2.Scripts.Bullets
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private int _initialCount = 50;
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _prefab;

        private ObjectPool<Bullet> _bulletPool;

        private void Awake()
        {
            _bulletPool = new ObjectPool<Bullet>(_prefab, _initialCount, _container);
        }

        public Bullet GetActiveBullet()
        {
            return _bulletPool.GetFreeElement();
        }

        public List<Bullet> GetAllBullets()
        {
            return _bulletPool.Pool;
        }
    }
}