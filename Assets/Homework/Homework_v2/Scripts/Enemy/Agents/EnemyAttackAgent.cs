using System;
using Homework.Homework_v2.Scripts.Components;
using UnityEngine;

namespace Homework.Homework_v2.Scripts.Enemy.Agents
{
    public sealed class EnemyAttackAgent : MonoBehaviour
    {
        public event Action<GameObject, Vector2, Vector2> OnFire;

        [SerializeField] private float _countdown = 3;

        private WeaponComponent _weaponComponent;
        private EnemyMoveAgent _moveAgent;
        private GameObject _target;
        private float _currentTime;

        private void Awake()
        {
            _weaponComponent = GetComponent<WeaponComponent>();
            _moveAgent = GetComponent<EnemyMoveAgent>();
        }

        private void FixedUpdate()
        {
            if (!_moveAgent.IsReached)
            {
                return;
            }

            if (!_target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            _currentTime -= Time.fixedDeltaTime;
            
            if (_currentTime <= 0)
            {
                Fire();
                _currentTime += _countdown;
            }
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public void Reset()
        {
            _currentTime = _countdown;
        }

        private void Fire()
        {
            var startPosition = _weaponComponent.Position;
            var vector = (Vector2)_target.transform.position - startPosition;
            var direction = vector.normalized;
            OnFire?.Invoke(gameObject, startPosition, direction);
        }
    }
}