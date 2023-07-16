using System.Threading.Tasks;
using AssetManagement;
using Other;
using StaticData;
using Units;
using UnityEngine;

namespace Factory
{
    public class UnitFactory : GameFactory<UnitObject, UnitTypeId>
    {
        private const string UnitsTag = "Units";

        public UnitFactory(StaticDataService staticDataService, IAssetProvider assetProvider) : base(staticDataService,
            assetProvider)
        {
        }

        protected override async Task<GameObject> LoadUnitFromAssetProvider(UnitTypeId typeId)
        {
            UnitStaticData data = StaticDataService.ForUnit(typeId);
            return await AssetProvider.Load<GameObject>(data.Prefab);
        }

        protected override void SetParent(UnitObject createdUnit, UnitTypeId typeId)
        {
            createdUnit.UnitTypeId = typeId;
            createdUnit.transform.parent = GameObject.FindGameObjectWithTag(UnitsTag).transform;
        }
    }
}