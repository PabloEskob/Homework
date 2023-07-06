using Data;

namespace Infrastructure
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        WorldProgress LoadProgress();
    }
}