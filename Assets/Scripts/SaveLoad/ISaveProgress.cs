using System.Collections;
using Data;

namespace SaveLoad
{
    public interface ISaveProgressReader
    {
        void LoadProgress(WorldProgress worldProgress);
    }

    public interface ISaveProgress : ISaveProgressReader
    {
        void UpdateProgress(WorldProgress worldProgress);
    }
}