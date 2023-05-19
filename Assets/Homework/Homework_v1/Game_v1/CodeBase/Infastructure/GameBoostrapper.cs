using Game_v1.CodeBase.Infastructure.State;
using Game_v1.CodeBase.Services.ServiceLocator;
using UnityEngine;

namespace Game_v1.CodeBase.Infastructure
{
    public sealed class GameBoostrapper : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;

        private void Awake()
        {
            _gameStateMachine = new GameStateMachine(AllServices.Container);
            _gameStateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}