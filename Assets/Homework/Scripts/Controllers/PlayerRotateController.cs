using Homework.Scripts.Components;
using Homework.Scripts.Entities;
using Homework.Scripts.Input;
using Homework.Scripts.Models.Player;
using UnityEngine;
using VContainer.Unity;

namespace Homework.Scripts.Controllers
{
    public class PlayerRotateController : IStartable, ITickable
    {
        private readonly GameInput _gameInput;
        private ITurnComponent _turnComponent;
        private readonly Entity _entity;

        public PlayerRotateController(GameInput gameInput, PlayerModel playerModel)
        {
            _entity = playerModel.PlayerModelComponents.Entity;
            _gameInput = gameInput;
        }

        public void Start()
        {
            if (_entity.TryGet(out ITurnComponent turnComponent))
            {
                _turnComponent = turnComponent;
            }
        }
        
        public void Tick()
        {
            if (_gameInput.PressRotateButton.IsPressed())
            {
                _turnComponent.MouseTurn();
            }
            else
            {
                if (_gameInput.Axis == Vector3.zero)
                {
                    return;
                }

                _turnComponent.Turn(_gameInput.Axis);
            }
           
        }
    }
}