using Homework.Scripts.Input;
using Homework.Scripts.Models;
using VContainer.Unity;

namespace Homework.Scripts.Controllers
{
    public class PlayerRotateController : ITickable
    {
        private readonly GameInput _gameInput;
        private readonly PlayerModelMove _playerModelMove;

        public PlayerRotateController(GameInput gameInput,PlayerModel playerModel)
        {
            _gameInput = gameInput;
            _playerModelMove = playerModel.PlayerModelCore.PlayerModelMove;
        }
        
        public void Tick()
        {
            _playerModelMove.RotateEngine.Rotate(_gameInput.Axis);
        }
    }
}