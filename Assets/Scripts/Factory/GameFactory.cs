using System.Threading.Tasks;
using AssetManagement;
using StaticData;
using Units;
using UnityEngine;

namespace Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly StaticDataService _staticDataService;
        private readonly IAssetProvider _assetProvider;

        public GameFactory(StaticDataService staticDataService, IAssetProvider assetProvider)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateUnit(UnitTypeId unitTypeId, Transform transform)
        {
            UnitStaticData unit = _staticDataService.ForUnit(unitTypeId);
            GameObject prefab = await _assetProvider.Load<GameObject>(unit._prefab);
            GameObject createUnit = Object.Instantiate(prefab, transform.position, Quaternion.identity);
            return createUnit;
        }

        public void CleanUp()
        {
            _assetProvider.CleanUp();
        }
    }
}