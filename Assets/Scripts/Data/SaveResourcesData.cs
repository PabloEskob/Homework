using System;
using Other;

namespace Data
{
    [Serializable]
    public class SaveResourcesData : UniqueId
    {
        public Vector3Data Position;
        public QuaternionData Rotation;
        public int Count;

        public SaveResourcesData(string uniqueId, ResourceType typeId)
        {
            Id = uniqueId;
            TypeId = (int)typeId;
        }
    }
}