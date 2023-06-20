using System;
using Homework.Homework_v2.Scripts.Common;
using Homework.Homework_v2.Scripts.Components;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Enemy
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [Header("Pool")] [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count;

        private ObjectPool<EnemyFireComponent> _enemyPool;

        private Func<EnemyFireComponent, Transform, EnemyFireComponent> _enemyFactory;

        [Inject]
        private void Construct(Func<EnemyFireComponent, Transform, EnemyFireComponent> enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Awake()
        {
            _enemyPool = new ObjectPool<EnemyFireComponent>();

            for (var i = 0; i < _count; i++)
            {
                var enemy = _enemyFactory(_prefab.GetComponent<EnemyFireComponent>(), _container);
                _enemyPool.Add(enemy);
            }
        }

        public EnemyFireComponent GetEnemy()
        {
            return _enemyPool.GetFreeElement();
        }
    }
}