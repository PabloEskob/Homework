using UnityEngine;

namespace Game_v1.CodeBase.Player.Components
{
    public sealed class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeedHorizontal = 2;
        [SerializeField] private float _movementSpeedForward=3;

        private void FixedUpdate()
        {
            _characterController.Move(Vector3.forward * (_movementSpeedForward * Time.fixedDeltaTime));
        }

        public void Move(Vector2 axis)
        {
            _characterController.Move(axis * _movementSpeedHorizontal);
        }
    }
}