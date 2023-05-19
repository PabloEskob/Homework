using System.Collections.Generic;
using Game_v1.CodeBase.System;

namespace Game_v1.CodeBase.Services
{
    public sealed class GameStateManagementService : IGameStateManagement
    {
        private readonly List<IGameListener> _gameListeners = new();

        public void Register(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);
        }

        public void UnRegister(IGameListener gameListener)
        {
            _gameListeners.Remove(gameListener);
        }


        public void StartGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }
        }


        public void PauseGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGamePauseListener startListener)
                {
                    startListener.OnPauseGame();
                }
            }
        }


        public void ResumeGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameResumeListener startListener)
                {
                    startListener.OnResumeGame();
                }
            }
        }


        public void FinishGame()
        {
            foreach (var gameListener in _gameListeners)
            {
                if (gameListener is IGameFinishListener startListener)
                {
                    startListener.OnFinishGame();
                }
            }
        }
    }
}