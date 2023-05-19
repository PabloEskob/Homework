using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.Input;
using Game_v1.CodeBase.Services.ServiceLocator;

namespace Game_v1.CodeBase.Infastructure.State
{
    public sealed class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly AllServices _allServices;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services)
        {
            _gameStateMachine = gameStateMachine;
            _allServices = services;

            RegisterServices();
        }

        public void Enter()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<GameInput>(new GameInput());
            _allServices.RegisterSingle<IGameStateManagement>(new GameStateManagementService());
            _allServices.RegisterSingle<IInputService>(
                new InputService(AllServices.Container.Single<GameInput>(),
                    _allServices.Single<IGameStateManagement>()));
            _allServices.RegisterSingle<IGameFactory>(new GameFactory());
        }
    }
}