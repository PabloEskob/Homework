using Game_v1.CodeBase.Player.Components;
using Game_v1.CodeBase.Services.Input;
using Game_v1.CodeBase.Services.OtherServices;
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
            _inputService = AllServices.Container.Single<IInputService>();
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