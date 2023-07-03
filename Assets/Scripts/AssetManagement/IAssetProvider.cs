using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AssetManagement
{
    public interface IAssetProvider
    {
        Task<T> Load<T>(AssetReference assetReference) where T : class;
        void CleanUp();
        void AddHandle<T>(string key, AsyncOperationHandle<T> handle) where T : class;
    }
}