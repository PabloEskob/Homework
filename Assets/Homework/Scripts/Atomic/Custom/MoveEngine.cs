using System;
using Homework.Scripts.Sections.Player;
using UnityEngine;

namespace Atomic
{
    [Serializable]
    public class MoveEngine
    {
        public AtomicVariable<float> Speed = new();
        
        [HideInInspector] public AtomicVariable<bool> MoveRequired = new();
        [HideInInspector] public AtomicVariable<Vector3> MoveDirection = new();
        [HideInInspector] public AtomicEvent<Vector3> OnMove = new();

        [SerializeField] private MeshRenderer _groundBounds;

        private FixedUpdateMechanics _fixedUpdateMechanics = new();

        public void Construct(Life life, CharacterController characterController)
        {
            AtomicVariable<bool> isDeath = life.IsDeath;

            OnMove += direction =>
            {
                if (isDeath.Value)
                {
                    return;
                }

                MoveDirection.Value = direction;
                MoveRequired.Value = true;
            };

            _fixedUpdateMechanics.Do(deltaTime =>
            {
                if (MoveRequired.Value)
                {
                    MoveDirection.Value *= Speed.Value * deltaTime;
                    Vector3 clampedPosition = ClampedPosition(characterController);
                    characterController.Move(clampedPosition - characterController.transform.position);
                    MoveRequired.Value = false;
                }
            });
        }

        private Vector3 ClampedPosition(CharacterController characterController)
        {
            var bounds = _groundBounds.bounds;
            var position = characterController.transform.position;
            float clampedX = Mathf.Clamp(position.x + MoveDirection.Value.x,
                bounds.min.x, bounds.max.x);
            var bounds1 = _groundBounds.bounds;
            float clampedZ = Mathf.Clamp(position.z + MoveDirection.Value.z,
                bounds1.min.z, bounds1.max.z);
            Vector3 clampedPosition = new Vector3(clampedX, position.y, clampedZ);
            return clampedPosition;
        }
    }
}