using Game_v1.CodeBase.Services;

namespace Game_v1.CodeBase.Infastructure.State
{
    public sealed class GameLoopState : IState
    {
        private readonly IGameStateManagement _gameStateManagementService;

        public GameLoopState(GameStateMachine gameStateMachine, IGameStateManagement gameStateManagementService)
        {
            _gameStateManagementService = gameStateManagementService;
        }

        public void Enter()
        {
            _gameStateManagementService.PauseGame();
        }

        public void Exit()
        {
        }
    }
}