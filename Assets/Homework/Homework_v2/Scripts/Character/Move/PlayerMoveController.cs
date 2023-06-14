using Homework.Homework_v2.Scripts.Input;
using UnityEngine;
using VContainer.Unity;

namespace Homework.Homework_v2.Scripts.Character.Move
{
    public class PlayerMoveController : IFixedTickable
    {
        private readonly IMove _move;
        private readonly InputSystem _inputSystem;

        public PlayerMoveController(IMove move, InputSystem inputSystem)
        {
            _move = move;
            _inputSystem = inputSystem;
        }
        
        public void FixedTick()
        {
            _move.Move(_inputSystem.Axis * Time.deltaTime);
        }
    }
}