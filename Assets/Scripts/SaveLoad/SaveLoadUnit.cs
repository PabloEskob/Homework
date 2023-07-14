using Data;
using Factory;
using Other;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadUnit: ISaveLoadProgress
    {
        private readonly IGameFactory _gameFactory;

        public SaveLoadUnit(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void UpdateProgress(WorldProgress worldProgress)
        {
            foreach (UnitObject unit in _gameFactory.UnitObjects)
            {
               var saveUnitData = new SaveUnitData(unit.Id, unit.UnitTypeId)
               {
                   HitPoint = unit.HitPoints,
                   Speed = unit.Speed,
                   Damage = unit.Damage,
                   UniqueId = unit.Id,
                   Position = unit.transform.position.AsVectorData(),
                   Rotation = unit.transform.rotation.AsQuaternionData()
               };
               worldProgress.WorldData.AddToList(saveUnitData);
            }
        }

        public void LoadProgress(WorldProgress worldProgress)
        {
            foreach (var unitObject in _gameFactory.UnitObjects)
            {
                SaveUnitData saveUnit = worldProgress.WorldData.FindById(unitObject.Id);
                
                if (saveUnit!=null)
                {
                    unitObject.HitPoints = saveUnit.HitPoint;
                    unitObject.Speed = saveUnit.Speed;
                    unitObject.Damage = saveUnit.Damage;
                    unitObject.transform.position = saveUnit.Position.AsUnityVector();
                    unitObject.transform.rotation = saveUnit.Rotation.AsUnityQuaternion();
                }
            }
        }
    }
}