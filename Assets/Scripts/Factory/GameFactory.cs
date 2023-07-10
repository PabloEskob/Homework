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
        private const string UnitsTag = "Units";
        private readonly StaticDataService _staticDataService;
        private readonly IAssetProvider _assetProvider;
        private readonly UnitSaveLoadManager _unitSaveLoadManager;
        

        public GameFactory(StaticDataService staticDataService, IAssetProvider assetProvider,UnitSaveLoadManager unitSaveLoadManager)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
            _unitSaveLoadManager = unitSaveLoadManager;
        }

        public async Task<GameObject> CreateUnit(UnitTypeId unitTypeId, Vector3 position,Quaternion rotation)
        {
            UnitStaticData unit = _staticDataService.ForUnit(unitTypeId);
            GameObject prefab = await _assetProvider.Load<GameObject>(unit._prefab);
            GameObject createUnit = Object.Instantiate(prefab, position, rotation);
            createUnit.transform.parent = GameObject.FindGameObjectWithTag(UnitsTag).transform;
            createUnit.GetComponent<UnitObject>().UnitTypeId = unitTypeId;
            _unitSaveLoadManager.RegisterProgressWatchers(createUnit);
            return createUnit;
        }
        
        public void CleanUp()
        {
            _unitSaveLoadManager.Clear();
            _assetProvider.CleanUp();
        }
    }
}