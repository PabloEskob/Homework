using Units;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "StaticData/Unit")]
    public class UnitStaticData : ScriptableObject
    {
        public UnitTypeId Type;
        public AssetReferenceGameObject Prefab;
    }
}