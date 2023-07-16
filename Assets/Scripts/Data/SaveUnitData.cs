using System;
using Units;

namespace Data
{
    [Serializable]
    public class SaveUnitData: UniqueId
    {
        public Vector3Data Position;
        public QuaternionData Rotation;
        public int HitPoint;
        public int Damage;
        public int Speed;

        public SaveUnitData(string uniqueId, UnitTypeId unitTypeId)
        {
            Id = uniqueId;
            TypeId = (int)unitTypeId;
        }
    }
}