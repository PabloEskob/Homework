using UnityEngine;

namespace Game_v1.CodeBase.Logic
{
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField] protected float _movementSpeed;
        [SerializeField] protected CharacterController _characterController;

        public abstract void Move(Vector3 axis);
    }
}