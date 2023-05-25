using Game_v1.CodeBase.Services.ServiceLocator;
using Homework.Homework_v1.Game_v1.CodeBase.Infrastructure.State;
using UnityEngine;

namespace Homework.Homework_v1.Game_v1.CodeBase.Infrastructure
{
    public sealed class GameBoostrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = new GameStateMachine(AllServices.Container);
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}