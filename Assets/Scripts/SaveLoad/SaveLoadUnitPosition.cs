using Data;
using Other;
using Units;

namespace SaveLoad
{
    public class SaveLoadUnitPosition: ISaveLoadProgress
    {
        private UnitSaveLoadManager _unitSaveLoadManager;
        
        public void UpdateProgress(WorldProgress worldProgress)
        {
            foreach (UnitObject unit in _unitSaveLoadManager.UnitObjects)
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
            foreach (var unitObject in _unitSaveLoadManager.UnitObjects)
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