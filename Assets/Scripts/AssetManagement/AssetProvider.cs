using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCache = new();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles = new();

        public async Task<T> Load<T>(AssetReference assetReference) where T : class
        {
            if (_completedCache.TryGetValue(assetReference.AssetGUID, out var completedHandle))
            {
                return completedHandle.Result as T;
            }

            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetReference);

            handle.Completed += h => { _completedCache[assetReference.AssetGUID] = h; };

            AddHandle(assetReference.AssetGUID, handle);

            return await handle.Task;
        }

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> resourcesHandles in _handles.Values)
            {
                foreach (AsyncOperationHandle handle in resourcesHandles)
                {
                    Addressables.Release(handle);
                }
            }
        }

        public void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class
        {
            if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourcesHandles))
            {
                resourcesHandles = new List<AsyncOperationHandle>();
                _handles[key] = resourcesHandles;
            }

            resourcesHandles.Add(handle);
        }
    }
}