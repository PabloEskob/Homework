using Repository;

namespace SaveLoad
{
    public interface ISaveLoadProgress
    {
        void UpdateProgress(IGameRepository gameRepository);
        void LoadProgress(IGameRepository gameRepository);
    }
}