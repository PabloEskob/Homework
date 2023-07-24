using UnityEngine;

namespace Atomic
{
    public class RotateEngine
    {
        private IAtomicValue<float> _smoothRotationTime;
        private Transform _transform;
        private Vector3 _direction;

        public void Construct(Transform transform,IAtomicValue<float> smoothRotationTime)
        {
            _smoothRotationTime = smoothRotationTime;
            _transform = transform;
        }

        public void Rotate(Vector3 direction)
        {
            var currentVelocity = _smoothRotationTime.Value;
            
            if (direction != Vector3.zero)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref currentVelocity, currentVelocity);
                _transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }
    }
}