using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.Input;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class PlayerMoveController : MonoBehaviour,
        IGameStartListener,
        IGameFinishListener,
        IGameResumeListener,
        IGamePauseListener
    {
        [SerializeField] private Movement _playerMove;

        private IInputService _inputService;
        private InputAction _gameplayMovement;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _gameplayMovement = _inputService.GameInput.Gameplay.Movement;
            AllServices.Container.Single<IGameStateManagement>().Register(this);
        }

        public void OnStartGame()
        {
            _gameplayMovement.performed += OnMoved;
        }

        public void OnFinishGame()
        {
            _gameplayMovement.performed -= OnMoved;
        }

        public void OnResumeGame()
        {
            _gameplayMovement.performed += OnMoved;
        }

        public void OnPauseGame()
        {
            _gameplayMovement.performed -= OnMoved;
        }

        private void OnMoved(InputAction.CallbackContext obj)
        {
            _playerMove.Move(_gameplayMovement.ReadValue<Vector2>());
        }
    }
}