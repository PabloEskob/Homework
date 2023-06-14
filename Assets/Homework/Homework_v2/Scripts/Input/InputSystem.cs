using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework.Homework_v2.Scripts.Input
{
    public class InputSystem
    {
        private readonly InputModule _inputModule;

        public Vector2 Axis
        {
            get
            {
                Vector2 readValue = _inputModule.InputSystem.Player.Move.ReadValue<Vector2>();
                return readValue;
            }
        }

        public InputAction AttackButtonUp
        {
            get
            {
                var input = _inputModule.InputSystem.Player.Fire;
                return input;
            }
        }

        public InputSystem(InputModule inputModule)
        {
            _inputModule = inputModule;
        }
    }
}