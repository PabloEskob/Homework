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
            return SavedUnitData.FirstOrDefault(saveUnitData => saveUnitData.UniqueIdId == id);
        }

        public void AddToList(SaveUnitData saveUnitData)
        {
            if (SavedUnitData.Contains(saveUnitData))
            {
                SavedUnitData.Remove(saveUnitData);
            }

            SavedUnitData.Add(saveUnitData);
        }
    }
}