using Game_v1.CodeBase.Services;
using Homework.Homework_v1.Game_v1.CodeBase.Infrastructure.State;
using UnityEngine;

namespace Game_v1.CodeBase.Managers
{
    public sealed class GameManager : IGameManager
    {
        public GameState CurrentState { get; private set; } = GameState.Idle;

        private readonly IGameStateManagement _gameStateManagement;

        public GameManager(IGameStateManagement gameStateManagement)
        {
            _gameStateManagement = gameStateManagement;
        }

        public void StartGame()
        {
            if (CurrentState != GameState.Idle)
            {
                Debug.LogWarning($"Expected state {GameState.Idle}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Playing;

            _gameStateManagement.StartGame();
        }


        public void PauseGame()
        {
            if (CurrentState != GameState.Playing)
            {
                Debug.LogWarning($"Expected state {GameState.Playing}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Pause;

            _gameStateManagement.PauseGame();
        }


        public void ResumeGame()
        {
            if (CurrentState != GameState.Pause)
            {
                Debug.LogWarning($"Expected state {GameState.Pause}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Playing;

            _gameStateManagement.ResumeGame();
        }


        public void FinishGame()
        {
            if (CurrentState != GameState.Playing)
            {
                Debug.LogWarning($"Expected state {GameState.Playing}, but actual state is {CurrentState}");
                return;
            }

            CurrentState = GameState.Finished;

            _gameStateManagement.FinishGame();
        }
    }
}