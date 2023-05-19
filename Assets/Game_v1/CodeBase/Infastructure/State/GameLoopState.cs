using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.UI;
using UnityEngine;

namespace Game_v1.CodeBase.Infastructure.State
{
    public sealed class GameLoopState : IState
    {
        private const string Tag = "UI";
        private readonly IGameStateManagement _gameStateManagementService;
        private GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private Hud _hud;


        public GameLoopState(GameStateMachine gameStateMachine, IGameStateManagement gameStateManagementService,IGameFactory gameFactory)
        {
            _gameStateManagementService = gameStateManagementService;
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _hud = _gameFactory.CreateHud(GameObject.FindWithTag(Tag).transform).GetComponent<Hud>();
            _hud.OnClosed += StartGame;
            _hud.OnClick += Pause;
        }

        public void Exit()
        {
            _hud.OnClosed -= StartGame;
            _hud.OnClick -= Pause;
        }

        private void StartGame()
        {
            _gameStateManagementService.StartGame();
        }

        private void Pause(bool pause)
        {
            if (pause)
            {
                _gameStateManagementService.PauseGame();
            }
            else
            {
                _gameStateManagementService.ResumeGame();
            }
        }
    }
}