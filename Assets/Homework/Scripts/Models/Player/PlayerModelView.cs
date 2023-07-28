using System;
using Atomic;
using Declarative;
using UnityEngine;

namespace Homework.Scripts.Models.Player
{
    [Serializable]
    public class PlayerModelView
    {
        private static readonly int State = Animator.StringToHash("State");

        [SerializeField] private Animator _animator;

        private LateUpdateEngine _lateUpdate = new();


        [Construct]
        public void Init(PlayerModelCore playerModelCore)
        {
            var move = playerModelCore.Move.MoveEngine;

            _lateUpdate.Do(_ =>
            {
                if (move.MoveRequired.Value)
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