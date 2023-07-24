using UnityEngine;

namespace Atomic
{
    public class MoveEngine
    {
        public bool MoveRequired => _moveRequired;

        private CharacterController _characterController;
        private Vector3 _direction;
        private IAtomicValue<float> _speed;
        private bool _moveRequired;

        public void Construct(CharacterController characterController, IAtomicValue<float> speed)
        {
            _characterController = characterController;
            _speed = speed;
        }

        public void Move(Vector3 direction)
        {
            _direction = direction;
            
            if (_direction == Vector3.zero)
            {
                _moveRequired = false;
            }
            else
            {
                _moveRequired = true;
                _characterController.Move(_direction * _speed.Value);
            }
        }
    }
}