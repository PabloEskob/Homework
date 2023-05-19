using Game_v1.CodeBase.System;

namespace Game_v1.CodeBase.Services.Input
{
    public sealed class InputService :
        IInputService,
        IGameStartListener,
        IGameFinishListener,
        IGamePauseListener,
        IGameResumeListener
    {
        public GameInput GameInput { get; }

        public InputService(GameInput gameInput, IGameStateManagement gameStateManagement)
        {
            GameInput = gameInput;
            gameStateManagement.Register(this);
        }

        public void OnStartGame()
        {
            GameInput.Enable();
        }

        public void OnFinishGame()
        {
            GameInput.Disable();
        }

        public void OnPauseGame()
        {
            GameInput.Disable();
        }

        public void OnResumeGame()
        {
            GameInput.Enable();
        }
    }
}