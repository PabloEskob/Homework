using System;
using Game_v1.CodeBase.Managers;
using Game_v1.CodeBase.Player.Components;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.System;

namespace Homework.Homework_v1.Game_v1.CodeBase.Player.Observer
{
    public sealed class PlayerDeathObserver : IGameStartListener, IGameFinishListener
    {
        private readonly PlayerDeath _playerDeath;
        private readonly IGameManager _gameManager;
        private readonly Action<IGameListener> _register;

        public PlayerDeathObserver(Entity entity, IGameManager gameManager)
        {
            _register = AllServices.Container.Single<IGameStateManagement>().Register;
            _register(this);
            _playerDeath = entity.Get<PlayerDeath>();
            _gameManager = gameManager;
        }

        public void OnStartGame()
        {
            _playerDeath.Died += OnPlayerDied;
        }

        public void OnFinishGame()
        {
            _playerDeath.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            _gameManager.FinishGame();
        }
    }
}