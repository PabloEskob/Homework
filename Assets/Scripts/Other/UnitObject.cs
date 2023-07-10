using Data;
using SaveLoad;
using Units;
using UnityEngine;

namespace Other
{
    public sealed class UnitObject : MonoBehaviour, ISaveLoadProgress
    {
        [SerializeField] public int _hitPoints;
        [SerializeField] public int _speed;
        [SerializeField] public int _damage;
        public UnitTypeId UnitTypeId { get; set; }

        private UniqueId _uniqueId;
        private SaveUnitData _saveUnitData;

        private void Start()
        {
            _uniqueId = GetComponent<UniqueId>();
            _saveUnitData = new SaveUnitData(_uniqueId.Id, UnitTypeId);
        }

        public void UpdateProgress(WorldProgress worldProgress)
        {
            _saveUnitData.Position = transform.position.AsVectorData();
            _saveUnitData.Rotation = transform.rotation.AsQuaternionData();
            worldProgress.WorldData.AddToList(_saveUnitData);
        }

        public void LoadProgress(WorldProgress worldProgress)
        {
            SaveUnitData saveUnit = worldProgress.WorldData.FindById(_uniqueId.Id);
            transform.position = saveUnit.Position.AsUnityVector();
            Debug.Log(saveUnit.Rotation.AsUnityQuaternion());
            transform.rotation = saveUnit.Rotation.AsUnityQuaternion();
        }
    }
}