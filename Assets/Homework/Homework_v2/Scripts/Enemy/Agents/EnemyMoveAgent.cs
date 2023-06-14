using Homework.Homework_v2.Scripts.Character.Move;
using UnityEngine;

namespace Homework.Homework_v2.Scripts.Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public bool IsReached => _isReached;

        private IMove _moveComponent;
        private Vector2 _destination;
        private bool _isReached;

        private void Awake()
        {
            _moveComponent = GetComponent<IMove>();
        }

        private void FixedUpdate()
        {
            if (_isReached)
            {
                return;
            }

            var vector = _destination - _moveComponent.GetPosition();

            if (vector.magnitude <= 0.25f)
            {
                _isReached = true;
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            _moveComponent.Move(direction);
        }

        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;
            _isReached = false;
        }
    }
}