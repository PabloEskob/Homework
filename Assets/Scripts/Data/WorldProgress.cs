using System;

namespace Data
{
    [Serializable]
    public class WorldProgress
    {
        public WorldData WorldData;

        public WorldProgress()
        {
            WorldData = new WorldData();
        }
    }
}