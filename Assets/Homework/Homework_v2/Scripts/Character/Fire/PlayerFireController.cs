using Homework.Homework_v2.Scripts.Components;
using Homework.Homework_v2.Scripts.Input;
using UnityEngine;
using VContainer;

namespace Homework.Homework_v2.Scripts.Character.Fire
{
    public sealed class PlayerFireController : MonoBehaviour
    {
        private InputSystem _inputSystem;
        private FireComponent _fireComponent;

        [Inject]
        private void Construct(InputSystem inputSystem,FireComponent fireComponent)
        {
            _inputSystem = inputSystem;
            _fireComponent = fireComponent;
        }

        private void Start()
        {
            _inputSystem.AttackButtonUp.performed += _fireComponent.OnFlyBullet;
        }

        private void OnDisable()
        {
            _inputSystem.AttackButtonUp.performed -= _fireComponent.OnFlyBullet;
        }
    }
}