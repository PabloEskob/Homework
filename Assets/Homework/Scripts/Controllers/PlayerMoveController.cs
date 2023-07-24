using Homework.Scripts.Input;
using Homework.Scripts.Models;
using UnityEngine;
using VContainer.Unity;

namespace Homework.Scripts.Controllers
{
    public class PlayerMoveController : IFixedTickable
    {
        private readonly GameInput _gameInput;
        private readonly PlayerModelMove _playerModelMove;

        public PlayerMoveController(GameInput gameInput, PlayerModel playerModel)
        {
            _playerModelMove = playerModel.PlayerModelCore.PlayerModelMove;
            _gameInput = gameInput;
        }

        public void FixedTick()
        {
            _playerModelMove.MoveEngine.Move(direction: _gameInput.Axis * Time.fixedDeltaTime);
        }
    }
}