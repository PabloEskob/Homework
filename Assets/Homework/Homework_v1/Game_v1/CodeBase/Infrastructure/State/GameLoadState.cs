using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Managers;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.UI;
using Homework.Homework_v1.Game_v1.CodeBase.Player.Observer;
using UnityEngine;

namespace Homework.Homework_v1.Game_v1.CodeBase.Infrastructure.State
{
    public sealed class GameLoadState : IState
    {
        private const string InitialPointTag = "InitialPoint";
        private const string TagUi = "UI";
        private readonly IGameFactory _gameFactory;
        private Hud _hud;
        private Entity _player;
        private PlayerDeathObserver _playerDeathObserver;
        private IGameManager _gameManager;

        public GameLoadState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            OnLoaded();
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            _player = _gameFactory
                .CreatePlayer(GameObject.FindWithTag(InitialPointTag).transform.position).GetComponent<Entity>();
            _hud = _gameFactory.CreateHud(GameObject.FindWithTag(TagUi).transform).GetComponent<Hud>();
            _gameManager = AllServices.Container.Single<IGameManager>();
            _playerDeathObserver = new PlayerDeathObserver(_player, _gameManager);
        }
    }
}