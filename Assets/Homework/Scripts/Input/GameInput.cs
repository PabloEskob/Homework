using UnityEngine;
using UnityEngine.InputSystem;

namespace Homework.Scripts.Input
{
    public class GameInput
    {
        private readonly InputModule _inputModule;

        public Vector3 Axis
        {
            get
            {
                Vector2 readValue = _inputModule.InputSystem.Gameplay.Move.ReadValue<Vector2>();
                return new Vector3(readValue.x, 0, readValue.y);
            }
        }

        public InputAction PressAttackButton
        {
            get
            {
                var input = _inputModule.InputSystem.Gameplay.Fire;
                return input;
            }
        }

        public InputAction PressRotateButton
        {
            get
            {
                var input = _inputModule.InputSystem.Gameplay.Turn;
                return input;
            }
        }

        public GameInput(InputModule inputModule)
        {
            _inputModule = inputModule;
        }
    }
}