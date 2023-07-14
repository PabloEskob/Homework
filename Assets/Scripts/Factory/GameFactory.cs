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
        private readonly UnitSaveLoadManager _unitSaveLoadManager;
        
        public GameFactory(StaticDataService staticDataService, IAssetProvider assetProvider,
            UnitSaveLoadManager unitSaveLoadManager)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
            _unitSaveLoadManager = unitSaveLoadManager;
        }

        public async Task<UnitObject> CreateUnit(UnitTypeId unitTypeId, Vector3 position, Quaternion rotation)
        {
            GameObject downloadedUnit = await LoadUnitFromAssetProvider(unitTypeId);
            UnitObject createdUnit = Object.Instantiate(downloadedUnit, position, rotation).GetComponent<UnitObject>();
            createdUnit.UnitTypeId = unitTypeId;
            createdUnit.transform.parent = GameObject.FindGameObjectWithTag(Units).transform;
            _unitSaveLoadManager.RegisterProgressWatchers(createdUnit.gameObject);
            return createdUnit;
        }
        
        public void CleanUp()
        {
            _unitSaveLoadManager.Clear();
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