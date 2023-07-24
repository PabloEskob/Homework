using System;
using Atomic;
using Declarative;
using UnityEngine;

namespace Homework.Scripts.Models
{
    [Serializable]
    public class PlayerModelMove
    {
        [SerializeField] private AtomicVariable<float> _speed;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private AtomicVariable<float> _smoothRotationTime;

        public MoveEngine MoveEngine { get; } = new();
        public RotateEngine RotateEngine { get; } = new();
        
        [Construct]
        public void Init()
        {
            MoveEngine.Construct(_characterController, _speed);
            RotateEngine.Construct(_characterController.transform,_smoothRotationTime);
        }
    }
}