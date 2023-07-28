using Homework.Scripts.Components;
using Homework.Scripts.Entities;
using Homework.Scripts.Input;
using Homework.Scripts.Models.Player;
using UnityEngine;
using VContainer.Unity;

namespace Homework.Scripts.Controllers
{
    public class PlayerMoveController : ITickable, IStartable
    {
        private readonly GameInput _gameInput;
        private IMoveComponent _moveComponent;
        private readonly Entity _entity;

        public PlayerMoveController(GameInput gameInput, PlayerModel playerModel)
        {
            _entity = playerModel.PlayerModelComponents.Entity;
            _gameInput = gameInput;
        }

        public void Start()
        {
            if (_entity.TryGet(out IMoveComponent moveComponent))
            {
                _moveComponent = moveComponent;
            }
        }

        public void Tick()
        {
            if (_gameInput.Axis == Vector3.zero)
            {
                return;
            }

            _moveComponent.Move(_gameInput.Axis);
        }
    }
}