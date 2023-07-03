using System.Collections.Generic;
using System.Linq;
using Units;
using UnityEngine;

namespace StaticData
{
    public sealed class StaticDataService
    {
        private const string Path = "SO";

        private Dictionary<UnitTypeId, UnitStaticData> _units;

        public StaticDataService()
        {
            LoadUnits();
        }

        public UnitStaticData ForUnit(UnitTypeId unitTypeId)
        {
            return _units.TryGetValue(unitTypeId, out UnitStaticData staticData) ? staticData : null;
        }

        private void LoadUnits()
        {
            _units = Resources.LoadAll<UnitStaticData>(Path).ToDictionary(x => x._type, x => x);
        }
    }
}