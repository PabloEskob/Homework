using Other;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ResourcesData", menuName = "StaticData/Resources")]
    public class ResourcesStaticData : ScriptableObject
    {
        public ResourceType Type;
         public AssetReferenceGameObject Prefab;
    }
}