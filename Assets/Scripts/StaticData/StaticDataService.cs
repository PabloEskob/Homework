using System;
using System.Collections.Generic;
using System.Linq;
using Other;
using Units;
using UnityEngine;

namespace StaticData
{
    public sealed class StaticDataService
    {
        private const string Path = "SO";

        private Dictionary<UnitTypeId, UnitStaticData> _units=new();
        private Dictionary<ResourceType, ResourcesStaticData> _resources=new();

        public StaticDataService()
        {
            LoadUnits();
            LoadResources();
        }
        
        public UnitStaticData ForUnit(UnitTypeId unitTypeId)
        {
            return _units.TryGetValue(unitTypeId, out UnitStaticData staticData) ? staticData : null;
        }
        
        public ResourcesStaticData ForResources(ResourceType resourceType)
        {
            return _resources.TryGetValue(resourceType, out ResourcesStaticData staticData) ? staticData : null;
        }

        private void LoadUnits()
        {
            _units = Resources.LoadAll<UnitStaticData>(Path).ToDictionary(x => x.Type, x => x);
        }

        private void LoadResources()
        {
            _resources=Resources.LoadAll<ResourcesStaticData>(Path).ToDictionary(x => x.Type, x => x);
        }
    }
}