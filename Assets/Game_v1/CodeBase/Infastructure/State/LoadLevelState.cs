using Game_v1.CodeBase.Factory;
using UnityEngine;

namespace Game_v1.CodeBase.Infastructure.State
{
    public sealed class LoadLevelState : IState
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
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
            var player = _gameFactory
                .CreatePlayer(GameObject.FindWithTag(InitialPointTag).transform.position);
            
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}