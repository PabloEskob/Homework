using System;
using System.Collections.Generic;
using Homework.Homework_v2.Scripts.Components;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Enemy
{
    public sealed class EnemyPool : MonoBehaviour
    {
        public Transform Container => _container;
        
        [Header("Pool")] 
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> _enemyPool = new();

        private Func<EnemyFireComponent, Transform, EnemyFireComponent> _enemyFactory;

        [Inject]
        private void Construct(Func<EnemyFireComponent, Transform, EnemyFireComponent> enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        private void Awake()
        {
            for (var i = 0; i < 7; i++)
            {
                var enemy = _enemyFactory(_prefab.GetComponent<EnemyFireComponent>(), _container);
                _enemyPool.Enqueue(enemy.gameObject);
            }
        }

        public Queue<GameObject> GetEnemyPool()
        {
            return _enemyPool;
        }
    }
}