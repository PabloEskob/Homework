using System;

namespace Data
{
    [Serializable]
    public class WorldData
    {
        public Vector3Data Position;

        public WorldData()
        {
            Position = new Vector3Data();
        }
    }
}