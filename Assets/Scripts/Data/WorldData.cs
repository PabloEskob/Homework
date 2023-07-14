using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    [Serializable]
    public class WorldData
    {
        public List<SaveUnitData> SavedUnitData = new();

        public SaveUnitData FindById(string id)
        {
            return SavedUnitData.FirstOrDefault(saveUnitData => saveUnitData.UniqueId == id);
        }

        public void AddToList(SaveUnitData saveUnitData)
        {
            SavedUnitData.RemoveAll(unitData => unitData.UniqueId == saveUnitData.UniqueId);
            SavedUnitData.Add(saveUnitData);
        }
    }
}