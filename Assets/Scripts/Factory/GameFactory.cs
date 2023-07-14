using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement;
using Other;
using StaticData;
using Units;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factory
{
    public class GameFactory : IGameFactory
    {
        private const string Units = "Units";

        private readonly StaticDataService _staticDataService;
        private readonly IAssetProvider _assetProvider;

        public List<UnitObject> UnitObjects { get; set; } = new();

        public GameFactory(StaticDataService staticDataService, IAssetProvider assetProvider)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        public async Task<UnitObject> CreateUnit(UnitTypeId unitTypeId, Vector3 position, Quaternion rotation)
        {
            GameObject downloadedUnit = await LoadUnitFromAssetProvider(unitTypeId);
            UnitObject createdUnit = Object.Instantiate(downloadedUnit, position, rotation).GetComponent<UnitObject>();
            createdUnit.UnitTypeId = unitTypeId;
            createdUnit.transform.parent = GameObject.FindGameObjectWithTag(Units).transform;
            UnitObjects.Add(createdUnit);
            return createdUnit;
        }

        public void CleanUp()
        {
            UnitObjects.Clear();
            _assetProvider.CleanUp();
        }

        private async Task<GameObject> LoadUnitFromAssetProvider(UnitTypeId unitTypeId)
        {
            UnitStaticData unit = _staticDataService.ForUnit(unitTypeId);
            GameObject prefab = await _assetProvider.Load<GameObject>(unit._prefab);
            return prefab;
        }
    }
}