using System;
using Units;

namespace Data
{
    [Serializable]
    public class SaveUnitData
    {
        public string UniqueIdId;
        public Vector3Data Position;
        public int UnitTypeId;
        public QuaternionData Rotation;

        public SaveUnitData(string uniqueIdId,UnitTypeId unitTypeId)
        {
            UniqueIdId = uniqueIdId;
            UnitTypeId = (int)unitTypeId;
        }
    }
}