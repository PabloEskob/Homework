using Game_v1.CodeBase.Controllers;
using Game_v1.CodeBase.Factory;
using Game_v1.CodeBase.Managers;
using Game_v1.CodeBase.Player.Components;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.UI;
using UnityEngine;

namespace Game_v1.CodeBase.Infastructure.State
{
    public sealed class GameLoopState : IState
    {
        private const string InitialPointTag = "InitialPoint";
        private const string TagUi = "UI";
        private readonly IGameStateManagement _gameStateManagementService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private Hud _hud;
        private Entity _player;
        private PlayerLoss _playerLoss;


        public GameLoopState(GameStateMachine gameStateMachine, IGameStateManagement gameStateManagementService,
            IGameFactory gameFactory)
        {
            _gameStateManagementService = gameStateManagementService;
            _gameFactory = gameFactory;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            OnLoaded();
            _hud.OnClosed += StartGame;
            _hud.OnClick += Pause;
            _playerLoss.OnLoss += FinishGame;
        }

        public void Exit()
        {
            _hud.OnClosed -= StartGame;
            _hud.OnClick -= Pause;
            _playerLoss.OnLoss -= FinishGame;
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

        private void FinishGame()
        {
            _gameStateManagementService.FinishGame();
        }

        private void OnLoaded()
        {
           _player = _gameFactory
                .CreatePlayer(GameObject.FindWithTag(InitialPointTag).transform.position).GetComponent<Entity>();
           _playerLoss = _player.Get<PlayerLoss>();
            _hud = _gameFactory.CreateHud(GameObject.FindWithTag(TagUi).transform).GetComponent<Hud>();
        }
    }
}