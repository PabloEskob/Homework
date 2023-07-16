using System.Collections.Generic;
using System.Threading.Tasks;
using AssetManagement;
using StaticData;
using UnityEngine;

namespace Factory
{
    public abstract class GameFactory<TData, TTypeId>
    {
        protected readonly StaticDataService StaticDataService;
        protected readonly IAssetProvider AssetProvider;
        public List<TData> ListData { get; set; } = new();

        protected GameFactory(StaticDataService staticDataService, IAssetProvider assetProvider)
        {
            StaticDataService = staticDataService;
            AssetProvider = assetProvider;
        }

        public async Task<TData> Create(TTypeId typeId, Vector3 position, Quaternion rotation)
        {
            GameObject downloadedUnit = await LoadUnitFromAssetProvider(typeId);
            TData createdUnit = Object.Instantiate(downloadedUnit, position, rotation).GetComponent<TData>();
            SetParent(createdUnit, typeId);
            ListData.Add(createdUnit);
            return createdUnit;
        }

        public void CleanUp()
        {
            ListData.Clear();
            AssetProvider.CleanUp();
        }

        protected abstract Task<GameObject> LoadUnitFromAssetProvider(TTypeId typeId);
        
        protected abstract void SetParent(TData createdUnit, TTypeId typeId);
    }
}