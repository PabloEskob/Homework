using Game_v1.CodeBase.Logic;
using UnityEngine;

namespace Game_v1.CodeBase.Player.Components
{
    public sealed class PlayerMove : Movement
    {
        private const float LimitX = 2;

        public override void Move(Vector3 axis)
        {
            var position = _characterController.transform.position;
            Vector3 newPosition = position + axis * _movementSpeed;
            newPosition.x = Mathf.Clamp(newPosition.x, -LimitX, LimitX);
            _characterController.Move(newPosition - position);
        }
    }
}