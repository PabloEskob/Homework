using System;
using System.Collections.Generic;
using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Services.ServiceLocator;

namespace Homework.Homework_v1.Game_v1.CodeBase.Infrastructure.State
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
                [typeof(GameLoadState)] = new GameLoadState(this,
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