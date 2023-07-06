using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement;
using Other;
using SaveLoad;
using StaticData;
using Units;
using UnityEngine;

namespace Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly StaticDataService _staticDataService;
        private readonly IAssetProvider _assetProvider;
        private readonly Func<UnitObject, Vector3, UnitObject> _unitFactory;
        public List<ISaveProgressReader> SaveProgressReaders { get; } = new();
        public List<ISaveProgress> ProgressWriters { get; } = new();

        public GameFactory(StaticDataService staticDataService, IAssetProvider assetProvider,
            Func<UnitObject, Vector3, UnitObject> unitFactory)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
            _unitFactory = unitFactory;
        }

        public async Task<GameObject> CreateUnit(UnitTypeId unitTypeId, Transform transform)
        {
            UnitStaticData unit = _staticDataService.ForUnit(unitTypeId);
            GameObject prefab = await _assetProvider.Load<GameObject>(unit._prefab);
            UnitObject createUnit = _unitFactory.Invoke(prefab.GetComponent<UnitObject>(), transform.position);
           return createUnit.gameObject;
        }

        public void CleanUp()
        {
            SaveProgressReaders.Clear();
            ProgressWriters.Clear();
            _assetProvider.CleanUp();
        }
    }
}