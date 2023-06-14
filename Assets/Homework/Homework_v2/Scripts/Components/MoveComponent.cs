using Homework.Homework_v2.Scripts.Character.Move;
using UnityEngine;

namespace Homework.Homework_v2.Scripts.Components
{
    public sealed class MoveComponent : MonoBehaviour, IMove
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed = 5.0f;

        public void Move(Vector2 vector2)
        {
            var nextPosition = _rigidbody2D.position + vector2 * _speed;
            _rigidbody2D.MovePosition(nextPosition);
        }

        public Vector2 GetPosition()
        {
            return gameObject.transform.position;
        }
    }
}