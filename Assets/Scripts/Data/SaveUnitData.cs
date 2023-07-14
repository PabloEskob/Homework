using System;
using Units;

namespace Data
{
    [Serializable]
    public class SaveUnitData
    {
        public string UniqueId;
        public Vector3Data Position;
        public int UnitTypeId;
        public QuaternionData Rotation;
        public int HitPoint;
        public int Damage;
        public int Speed;

        public SaveUnitData(string uniqueId, UnitTypeId unitTypeId)
        {
            UniqueId = uniqueId;
            UnitTypeId = (int)unitTypeId;
        }
    }
}