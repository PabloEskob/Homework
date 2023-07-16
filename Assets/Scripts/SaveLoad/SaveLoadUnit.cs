using Data;
using Factory;
using Other;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadUnit : SaveLoader<UnitData, UnitFactory>
    {
        private readonly UnitFactory _gameFactory;

        public SaveLoadUnit(UnitFactory service) : base(service)
        {
            _gameFactory = service;
        }

        protected override UnitData ConvertToData(UnitFactory service)
        {
            UnitData unitData = new UnitData();

            foreach (UnitObject unit in _gameFactory.ListData)
            {
                var saveUnitData = new SaveUnitData(unit.Id, unit.UnitTypeId)
                {
                    HitPoint = unit.HitPoints,
                    Speed = unit.Speed,
                    Damage = unit.Damage,
                    Id = unit.Id,
                    Position = unit.transform.position.AsVectorData(),
                    Rotation = unit.transform.rotation.AsQuaternionData()
                };
                unitData.AddToList(saveUnitData);
            }

            return unitData;
        }

        protected override void SetupData(UnitFactory service, UnitData data)
        {
            foreach (var unitObject in _gameFactory.ListData)
            {
                SaveUnitData saveUnit = data.FindById(unitObject.Id);

                if (saveUnit != null)
                {
                    unitObject.HitPoints = saveUnit.HitPoint;
                    unitObject.Speed = saveUnit.Speed;
                    unitObject.Damage = saveUnit.Damage;
                    unitObject.transform.position = saveUnit.Position.AsUnityVector();
                    unitObject.transform.rotation = saveUnit.Rotation.AsUnityQuaternion();
                }
            }
        }

        protected override void SetupByDefault(UnitFactory service)
        {
            Debug.Log("No Data");
        }
    }
}