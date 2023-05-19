using Game_v1.CodeBase.Logic;
using Game_v1.CodeBase.Services;
using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.System;
using UnityEngine;

namespace Game_v1.CodeBase.Controllers
{
    public sealed class EnemyMoveController : MonoBehaviour,
        IGameStartListener,
        IGamePauseListener,
        IGameResumeListener,
        IGameFinishListener
    {
        [SerializeField] private Movement _movement;

        private IGameStateManagement _gameStateManagement;

        private void Awake()
        {
            _gameStateManagement = AllServices.Container.Single<IGameStateManagement>();
            _gameStateManagement.Register(this);
        }

        private void FixedUpdate()
        {
            _movement.Move(Vector3.back);
        }
        
        public void OnStartGame()
        {
            enabled = true;
        }

        public void OnPauseGame()
        {
            enabled = false;
        }

        public void OnResumeGame()
        {
            enabled = true;
        }

        public void OnFinishGame()
        {
            enabled = false;
        }
    }
}