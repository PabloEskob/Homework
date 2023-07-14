using Data;
using Factory;
using Other;
using UnityEngine;

namespace SaveLoad
{
    public class SaveLoadUnitPosition: ISaveLoadProgress
    {
        private readonly IGameFactory _gameFactory;

        public SaveLoadUnitPosition(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public void UpdateProgress(WorldProgress worldProgress)
        {
            Debug.Log("Save!");
            foreach (UnitObject unit in _gameFactory.UnitObjects)
            {
               var saveUnitData = new SaveUnitData(unit.Id, unit.UnitTypeId)
               {
                   UniqueId = unit.Id,
                   Position = unit.transform.position.AsVectorData(),
                   Rotation = unit.transform.rotation.AsQuaternionData()
               };
               worldProgress.WorldData.AddToList(saveUnitData);
            }
        }

        public void LoadProgress(WorldProgress worldProgress)
        {
            Debug.Log("Load");
            foreach (var unitObject in _gameFactory.UnitObjects)
            {
                SaveUnitData saveUnit = worldProgress.WorldData.FindById(unitObject.Id);
                
                if (saveUnit!=null)
                {
                    unitObject.transform.position = saveUnit.Position.AsUnityVector();
                    unitObject.transform.rotation = saveUnit.Rotation.AsUnityQuaternion();
                }
            }
        }
    }
}