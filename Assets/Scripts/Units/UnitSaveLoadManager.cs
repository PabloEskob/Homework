using System.Collections.Generic;
using SaveLoad;
using UnityEngine;

namespace Units
{
    public class UnitSaveLoadManager
    {
        public List<ISaveLoadProgress> SaveLoad { get; } = new();
        
        public void Clear()
        {
            SaveLoad.Clear();
        }

        public void RegisterProgressWatchers(GameObject createUnit)
        {
            foreach (ISaveLoadProgress saveLoad in createUnit.GetComponentsInChildren<ISaveLoadProgress>())
            {
                Register(saveLoad);
            }
        }

        public void Remove(GameObject unit)
        {
            SaveLoad.Remove(unit.GetComponentInChildren<ISaveLoadProgress>());
        }

        private void Register(ISaveLoadProgress saveLoad)
        {
            SaveLoad.Add(saveLoad);
        }
    }
}