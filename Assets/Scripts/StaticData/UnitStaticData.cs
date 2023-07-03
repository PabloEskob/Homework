using Units;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace StaticData
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "StaticData/Unit")]
    public class UnitStaticData : ScriptableObject
    {
        public UnitTypeId _type;
        public AssetReferenceGameObject _prefab;
    }
}