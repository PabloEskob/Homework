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

        private void OnEnable()
        {
            AllServices.Container.Single<IGameStateManagement>().Register(this);
        }

        private void OnDisable()
        {
            AllServices.Container.Single<IGameStateManagement>().UnRegister(this);
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
            Debug.Log("!@!!");
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