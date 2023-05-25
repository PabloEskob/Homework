using Game_v1.CodeBase.Controllers;
using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Managers;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.Input;
using Game_v1.CodeBase.Services.ServiceLocator;

namespace Homework.Homework_v1.Game_v1.CodeBase.Infrastructure.State
{
    public sealed class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;
        private IGameStateManagement _gameStateManagement;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = services;

            RegisterServices();
        }

        public void Enter()
        {
            _gameStateMachine.Enter<GameLoadState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<GameInput>(new GameInput());
            _allServices.RegisterSingle<IGameStateManagement>(new GameStateManagementService());
            _gameStateManagement = _allServices.Single<IGameStateManagement>();
            _allServices.RegisterSingle<IInputService>(new InputService(AllServices.Container.Single<GameInput>(), _gameStateManagement));
            _allServices.RegisterSingle<IGameFactory>(new GameFactory());
            _allServices.RegisterSingle<IGameManager>(new GameManager(_gameStateManagement));
            _allServices.RegisterSingle<ISceneController>(new SceneController());
        }
    }
}