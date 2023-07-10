using Data;
using SaveLoad;

namespace Infrastructure
{
    public interface ISaveLoadService
    {
        void SaveProgress(SavePaths savePath);
        WorldProgress LoadProgress(SavePaths savePath);
    }
}