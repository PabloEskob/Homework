using System;
using Atomic;
using Declarative;
using UnityEngine;

namespace Homework.Scripts.Models
{
    [Serializable]
    public class PlayerModelView
    {
        private static readonly int State = Animator.StringToHash("State");
        
        [SerializeField] private Animator _animator;
        
        private LateUpdateEngine _lateUpdate = new();
        private MoveEngine _moveEngine;

        [Construct]
        public void Init(PlayerModelCore playerModelCore)
        {
            _moveEngine = playerModelCore.PlayerModelMove.MoveEngine;
            
            _lateUpdate.OnUpdate(_ =>
            {
                if (_moveEngine.MoveRequired)
                {
                    _animator.SetInteger(State, 1);
                }
                else
                {
                    _animator.SetInteger(State, 0);
                }
            });
        }
    }
}