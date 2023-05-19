using Game_v1.CodeBase.Services.ServiceLocator;
using Game_v1.CodeBase.System;

namespace Game_v1.CodeBase.Services
{
    public interface IGameStateManagement : IService
    {
        public void Register(IGameListener gameListener);
        public void UnRegister(IGameListener gameListener);

        public void StartGame();
        public void PauseGame();
        public void ResumeGame();
        public void FinishGame();
    }
}