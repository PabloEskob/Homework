using System.Collections.Generic;
using Other;
using SaveLoad;
using UnityEngine;

namespace Units
{
    public class UnitSaveLoadManager
    {
        public List<ISaveLoadProgress> ListSaveLoad { get; } = new();
        public List<UnitObject> UnitObjects { get; } = new();

        public void Clear()
        {
            ListSaveLoad.Clear();
        }

        public void RegisterProgressWatchers(GameObject createUnit)
        {
            foreach (ISaveLoadProgress saveLoad in createUnit.GetComponentsInChildren<ISaveLoadProgress>())
            {
                Register(saveLoad);
                UnitObjects.Add(createUnit.GetComponent<UnitObject>());
            }
        }

        public void Remove(GameObject unit)
        {
            ListSaveLoad.Remove(unit.GetComponentInChildren<ISaveLoadProgress>());
        }

        private void Register(ISaveLoadProgress saveLoad)
        {
            ListSaveLoad.Add(saveLoad);
        }
    }
}