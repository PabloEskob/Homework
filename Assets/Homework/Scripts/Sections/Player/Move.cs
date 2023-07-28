using System;
using Atomic;
using Declarative;
using UnityEngine;

namespace Homework.Scripts.Sections.Player
{
    [Serializable]
    public class Move
    {
        [Section] [SerializeField] public TurnEngine TurnEngine;
        [Section] [SerializeField] public MoveEngine MoveEngine;

        [SerializeField] private CharacterController _characterController;

        [Construct]
        public void Construct(Life life)
        {
            TurnEngine.Construct(life,_characterController);
            MoveEngine.Construct(life, _characterController);
        }
    }
}