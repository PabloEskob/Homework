using Game_v1.CodeBase.Logic;
using UnityEngine;

namespace Game_v1.CodeBase.Player.Components
{
    public sealed class PlayerMove : Movement
    {
        public override void Move(Vector3 axis)
        {
            _characterController.Move(axis * _movementSpeed);
        }
    }
}