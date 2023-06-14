using UnityEngine;

namespace Homework.Homework_v2.Scripts.Input
{
    public class InputModule : MonoBehaviour
    {
        public NewInputSystem InputSystem { get; private set; }

        private void Awake()
        {
            InputSystem = new NewInputSystem();
            InputSystem.Enable();
        }
    }
}