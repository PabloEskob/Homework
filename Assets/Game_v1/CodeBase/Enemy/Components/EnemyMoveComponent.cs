using Game_v1.CodeBase.Logic;
using UnityEngine;

namespace Game_v1.CodeBase.Enemy.Components
{
    public sealed class EnemyMoveComponent : Movement
    {
        public override void Move(Vector3 axis)
        {
            _characterController.Move(axis * (_movementSpeed * Time.fixedDeltaTime));
        }
    }
}