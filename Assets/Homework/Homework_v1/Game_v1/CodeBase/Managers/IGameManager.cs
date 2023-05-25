using Game_v1.CodeBase.Services.ServiceLocator;

namespace Game_v1.CodeBase.Managers
{
    public interface IGameManager : IService
    {
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void FinishGame();
    }
}