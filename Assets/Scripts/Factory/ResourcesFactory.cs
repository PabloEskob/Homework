using System.Threading.Tasks;
using AssetManagement;
using Other;
using StaticData;
using UnityEngine;

namespace Factory
{
    public class ResourcesFactory: GameFactory<ResourceObject,ResourceType>
    {
        private const string ResourcesTag = "Resources";

        public ResourcesFactory(StaticDataService staticDataService, IAssetProvider assetProvider) : base(staticDataService, assetProvider)
        {
        }

        protected override async Task<GameObject> LoadUnitFromAssetProvider(ResourceType typeId)
        {
            ResourcesStaticData data = StaticDataService.ForResources(typeId);
            return await AssetProvider.Load<GameObject>(data.Prefab);
        }

        protected override void SetParent(ResourceObject createdUnit, ResourceType typeId)
        {
            createdUnit.ResourceType= typeId;
            createdUnit.transform.parent = GameObject.FindGameObjectWithTag(ResourcesTag).transform;
        }
    }
}