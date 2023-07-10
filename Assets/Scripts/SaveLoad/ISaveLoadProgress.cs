using Data;

namespace SaveLoad
{
    public interface ISaveLoadProgress 
    {
        void UpdateProgress(WorldProgress worldProgress);
        void LoadProgress(WorldProgress worldProgress);
    }
}