﻿using Game_v1.CodeBase.Infastructure;
using Game_v1.CodeBase.Player.Components;
using Game_v1.CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private PlayerMove _playerMove;

        private IInputService _inputService;

        private void Awake()
        {
            _inputService = Game.InputService;
        }

        private void OnEnable()
        {
            _inputService.GameInput.Gameplay.Movement.performed += OnMoved;
        }

        private void OnDisable()
        {
            _inputService.GameInput.Gameplay.Movement.performed -= OnMoved;
        }

        private void OnMoved(InputAction.CallbackContext obj)
        {
            _playerMove.Move(_inputService.GameInput.Gameplay.Movement.ReadValue<Vector2>());
        }
    }
}