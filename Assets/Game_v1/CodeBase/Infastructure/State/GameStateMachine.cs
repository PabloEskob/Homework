using System;
using System.Collections.Generic;
using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.ServiceLocator;

namespace Game_v1.CodeBase.Infastructure.State
{
    public sealed class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(AllServices services)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(this,services.Single<IGameStateManagement>(),
                    services.Single<IGameFactory>()),
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _activeState?.Exit();
            IState state = _states[typeof(TState)];
            _activeState = state;
            state.Enter();
        }
    }
}